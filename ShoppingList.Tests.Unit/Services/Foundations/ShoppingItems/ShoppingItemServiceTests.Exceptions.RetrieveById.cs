// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using Moq;
using ShoppingList.ConsoleApp.Models.ShoppingItems.Exceptions;
using Xunit;

namespace ShoppingList.Tests.Unit.Services.Foundations.ShoppingItems
{
    public partial class ShoppingItemServiceTests
    {
        [Fact]
        public void ShouldThrowDependencyValidationExceptionOnRetrieveByIdIfValidationErrorOccursAndLogIt()
        {
            // given  
            int someShoppingItemId = GetRandomNumber();
            var argumentNullException = new ArgumentNullException();

            var nullArgumentShoppingItemException =
                new NullArgumentShoppingItemException(argumentNullException);

            var expectedShoppingItemDependencyValidationException =
                new ShoppingItemDependencyValidationException(
                    nullArgumentShoppingItemException);

            this.storageBrokerMock.Setup(broker =>
                broker.SelectShoppingItemById(It.IsAny<int>()))
                    .Throws(argumentNullException);

            // when
            Action retrieveShoppingItemByIdAction = () =>
                this.shoppingItemService.RetrieveShoppingItemById(someShoppingItemId);

            // then
            Assert.Throws<ShoppingItemDependencyValidationException>(retrieveShoppingItemByIdAction);

            this.storageBrokerMock.Verify(broker =>
               broker.SelectShoppingItemById(It.IsAny<int>()),
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
