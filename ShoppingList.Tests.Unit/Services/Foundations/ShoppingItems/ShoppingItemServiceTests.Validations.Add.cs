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
        public void ShouldThrowValidationExceptionOnAddIfShoppingItemIsNullAndLogIt()
        {
            // given
            ShoppingItem nullShoppingItem = null;
            var nullShoppingItemException = new NullShoppingItemException();
            var expectedShoppingItemValidationException = new ShoppingItemValidationException(nullShoppingItemException);

            // when
            Action addShoppingItemTask = () => this.shoppingItemService.AddShoppingItem(nullShoppingItem);

            // then
            Assert.Throws<ShoppingItemValidationException>(addShoppingItemTask);

            this.loggingBrokerMock.Verify(broker =>
               broker.LogError(It.Is(SameExceptionAs(
                   expectedShoppingItemValidationException))),
                        Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertShoppingItem(It.IsAny<ShoppingItem>()),
                    Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void ShouldThrowValidationExceptionOnAddIfShoppingItemIsInvalidAndLogIt(
            string invalidText)
        {
            // given
            var invalidShoppingItem = new ShoppingItem
            {
                Name = invalidText
            };

            var invalidShoppingItemException = new InvalidShoppingItemException();

            invalidShoppingItemException.AddData(
                key: nameof(ShoppingItem.Id),
                values: "Value is required.");

            invalidShoppingItemException.AddData(
                key: nameof(ShoppingItem.Name),
                values: "Name is required.");

            invalidShoppingItemException.AddData(
                key: nameof(ShoppingItem.Quantity),
                values: "Value is required.");

            var expectedShoppingItemValidationException = new ShoppingItemValidationException(invalidShoppingItemException);

            // when
            Action addShoppingItemAction = () => this.shoppingItemService.AddShoppingItem(invalidShoppingItem);

            // then
            Assert.Throws<ShoppingItemValidationException>(addShoppingItemAction);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedShoppingItemValidationException))),
                        Times.Once);

            this.storageBrokerMock.Verify(broker =>
               broker.InsertShoppingItem(It.IsAny<ShoppingItem>()),
                    Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}