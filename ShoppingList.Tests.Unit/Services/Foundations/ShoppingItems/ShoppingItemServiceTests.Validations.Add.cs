// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using ShoppingList.ConsoleApp.Models.ShoppingItems;
using ShoppingList.ConsoleApp.Models.ShoppingItems.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }
    }
}
