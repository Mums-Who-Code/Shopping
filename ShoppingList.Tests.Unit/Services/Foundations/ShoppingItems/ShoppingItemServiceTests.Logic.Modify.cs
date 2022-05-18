// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using ShoppingList.ConsoleApp.Models.ShoppingItems;
using Xunit;

namespace ShoppingList.Tests.Unit.Services.Foundations.ShoppingItems
{
    public partial class ShoppingItemServiceTests
    { 
        [Fact]
        public void ShouldModifyShoppingItem()
        {
            // given
            ShoppingItem randomShoppingItem = CreateRandomShoppingItem();
            ShoppingItem inputShoppingItem = randomShoppingItem;
            ShoppingItem modifiedShoppingItem = inputShoppingItem;
            ShoppingItem expectedShoppingItem = modifiedShoppingItem;

            this.storageBrokerMock.Setup(broker =>
                broker.UpdateShoppingItem(inputShoppingItem))
                    .Returns(modifiedShoppingItem);   

            // when 
            ShoppingItem actualShoppingItem = this.shoppingItemService.ModifyShoppingItem(inputShoppingItem);

            // then
            actualShoppingItem.Should().BeEquivalentTo(expectedShoppingItem);

            this.storageBrokerMock.Verify(broker =>
                broker.UpdateShoppingItem(inputShoppingItem),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}