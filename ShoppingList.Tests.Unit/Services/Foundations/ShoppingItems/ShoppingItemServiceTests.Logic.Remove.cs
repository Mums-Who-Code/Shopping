// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using FluentAssertions;
using Force.DeepCloner;
using Moq;
using ShoppingList.ConsoleApp.Models.ShoppingItems;
using Xunit;

namespace ShoppingList.Tests.Unit.Services.Foundations.ShoppingItems
{
    public partial class ShoppingItemServiceTests
    {
        [Fact]
        public void ShouldRemoveShoppingItem()
        {
            // given
            ShoppingItem randomShoppingItem = CreateRandomShoppingItem();
            ShoppingItem inputShoppingItem = randomShoppingItem;
            ShoppingItem deletedShoppingItem = inputShoppingItem;
            ShoppingItem expectedShoppingItem = deletedShoppingItem.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.DeleteShoppingItem(inputShoppingItem))
                    .Returns(deletedShoppingItem);

            // when 
            ShoppingItem actualShoppingItem = this.shoppingItemService.RemoveShoppingItem(inputShoppingItem);

            // then
            actualShoppingItem.Should().BeEquivalentTo(expectedShoppingItem);

            this.storageBrokerMock.Verify(broker =>
                broker.DeleteShoppingItem(inputShoppingItem),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}