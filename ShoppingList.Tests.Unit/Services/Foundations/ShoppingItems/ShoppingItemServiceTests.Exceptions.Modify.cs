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
        public void ShouldThrowDependencyValidationExceptionOnModifyIfValidationErrorOccursAndLogIt()
        {
            // given
            ShoppingItem someShoppingItem = CreateRandomShoppingItem();
            var argumentNullException = new ArgumentNullException();

            var nullArgumentShoppingItemException =
                new NullArgumentShoppingItemException(argumentNullException);

            var expectedShoppingItemDependencyValidationException =
                new ShoppingItemDependencyValidationException(nullArgumentShoppingItemException);

            this.storageBrokerMock.Setup(broker =>
                broker.UpdateShoppingItem(It.IsAny<ShoppingItem>()))
                    .Throws(argumentNullException);

            // when
            Action modifyShoppingItemAction = () => this.shoppingItemService.ModifyShoppingItem(someShoppingItem);

            // then
            Assert.Throws<ShoppingItemDependencyValidationException>(modifyShoppingItemAction);

            this.storageBrokerMock.Verify(broker =>
                broker.UpdateShoppingItem(It.IsAny<ShoppingItem>()),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedShoppingItemDependencyValidationException))),
                        Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}