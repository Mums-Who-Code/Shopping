// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using Moq;
using ShoppingList.ConsoleApp.Models.ShoppingItems;
using ShoppingList.ConsoleApp.Models.ShoppingItems.Exceptions;
using Xunit;

namespace ShoppingList.Tests.Unit.Services.Foundations.ShoppingItems
{
    public partial class ShoppingItemServiceTests
    {
        [Fact]
        public void ShouldThrowValidationExceptionOnRetrieveByIdIfIdIsInvalidAndLogIt()
        {
            // given
            int invalidId = default;
            var invalidShoppingItemException = new InvalidShoppingItemException();

            invalidShoppingItemException.AddData(
                key: nameof(ShoppingItem.Id),
                values: "Value is required.");

            var expectedShoppingItemValidationException =
                new ShoppingItemValidationException(invalidShoppingItemException);

            // when 
            Action retrieveShoppingItemByIdAction = () =>
                this.shoppingItemService.RetrieveShoppingItemById(invalidId);

            // then
            Assert.Throws<ShoppingItemValidationException>(retrieveShoppingItemByIdAction);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedShoppingItemValidationException))),
                        Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectShoppingItemById(It.IsAny<int>()),
                    Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}