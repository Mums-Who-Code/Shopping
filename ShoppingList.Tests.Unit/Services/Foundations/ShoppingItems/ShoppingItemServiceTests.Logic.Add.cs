// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingList.ConsoleApp.Models.ShoppingItems;
using Xunit;

namespace ShoppingList.Tests.Unit.Services.Foundations.ShoppingItems
{
    public partial class ShoppingItemServiceTests
    {
        [Fact]

        public void ShouldAddShoppingItem()
        {
            // given

            ShoppingItem inputShoppingItem = CreateRandomShoppingItem();

            // when
            this.shoppingItemService.AddShoppingItem(inputShoppingItem);

            // then
        }
    }
}
