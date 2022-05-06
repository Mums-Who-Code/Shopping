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
        public void ShouldThrowServiceExceptionOnAddIfServiceErrorOccursAndLogIt()
        {
            //given
            ShoppingItem someShoppingItem = CreateRandomShoppingItem();
            var serviceException = new Exception();

            var failedShoppingItemServiceException =
                new FailedShoppingItemServiceException(serviceException);

            var expectedShoppingItemServiceException =
                new ShoppingItemServiceException(failedShoppingItemServiceException);

            this.storageBrokerMock.Setup(broker =>
                broker.InsertShoppingItem(It.IsAny<ShoppingItem>()))
                    .Throws(serviceException);

            //when
            Action addShoppingItemAction = () => this.shoppingItemService.AddShoppingItem(someShoppingItem);

            //then
            Assert.Throws<ShoppingItemServiceException>(addShoppingItemAction);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertShoppingItem(It.IsAny<ShoppingItem>()),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedShoppingItemServiceException))),
                        Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}