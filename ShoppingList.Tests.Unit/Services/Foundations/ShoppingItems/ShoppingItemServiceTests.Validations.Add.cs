// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using Moq;
using ShoppingList.ConsoleApp.Models.ShoppingItems;
using ShoppingList.ConsoleApp.Models.ShoppingItems.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xeptions;
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

    }
}
