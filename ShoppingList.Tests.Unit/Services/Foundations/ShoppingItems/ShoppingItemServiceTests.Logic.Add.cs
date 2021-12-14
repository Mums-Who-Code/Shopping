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

        public void ShouldAddShoppingItem()
        {
            // given

            ShoppingItem randomShoppingItem = CreateRandomShoppingItem();
            ShoppingItem inputShoppingItem = randomShoppingItem;
            ShoppingItem persistedShoppingItem = inputShoppingItem;
            ShoppingItem expectedShoppingItem = persistedShoppingItem.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.InsertShoppingItem(inputShoppingItem))
                    .Returns(persistedShoppingItem);

            // when
            ShoppingItem actualShoppingItem = this.shoppingItemService.AddShoppingItem(inputShoppingItem);

            // then
            actualShoppingItem.Should().BeEquivalentTo(expectedShoppingItem);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertShoppingItem(inputShoppingItem),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();


        }
    }
}
