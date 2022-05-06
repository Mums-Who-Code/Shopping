// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using ShoppingList.ConsoleApp.Models.ShoppingItems.Exceptions;
using Xunit;

namespace ShoppingList.Tests.Unit.Services.Foundations.ShoppingItems
{
    public partial class ShoppingItemServiceTests
    {
        [Fact]
        public void ShoudThrowServiceExceptionOnRetrieveAllIfServiceErrorOccursAndLogIt()
        {
            // given
            var serviceException = new Exception();

            var failedShoppingItemServiceException = 
                new FailedShoppingItemServiceException(serviceException);

            var expectedShoppingItemServiceException =
                new ShoppingItemServiceException(failedShoppingItemServiceException);

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllShoppingItems())
                    .Throws(serviceException);
            // when
            Action retrieveAllAction = () => this.shoppingItemService.RetrieveAllShoppingItems();

            // then
            Assert.Throws<ShoppingItemServiceException>(retrieveAllAction);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllShoppingItems(),
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
