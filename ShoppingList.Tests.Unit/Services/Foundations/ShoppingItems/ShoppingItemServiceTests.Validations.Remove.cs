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
        public void ShouldThrowValidationExceptionOnRemoveIfShoppingItemIsNullAndLogIt()
        {
            // given
            ShoppingItem nullShoppingItem = null;
            var nullShoppingItemException = new NullShoppingItemException();

            var expectedShoppingItemValidationException =
                new ShoppingItemValidationException(nullShoppingItemException);

            // when
            Action removeShoppingItemAction = () => this.shoppingItemService.RemoveShoppingItem(nullShoppingItem);

            // then
            Assert.Throws<ShoppingItemValidationException>(removeShoppingItemAction);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedShoppingItemValidationException))),
                        Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.DeleteShoppingItem(It.IsAny<ShoppingItem>()),
                    Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}