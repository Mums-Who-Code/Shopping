// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var invalidShoppingItem = new ShoppingItem();
            var invalidShoppingItemException = new InvalidShoppingItemException();

            invalidShoppingItemException.AddData(
                key: nameof(ShoppingItem.Id),
                values: "Id is required");

            var expectedShoppingItemValidationException =
                new ShoppingItemValidationException(invalidShoppingItemException);

            // when 
            Action retrieveShoppingItemByIdAction = () => 
                this.shoppingItemService.RetrieveShoppingItemById(invalidShoppingItem.Id);

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