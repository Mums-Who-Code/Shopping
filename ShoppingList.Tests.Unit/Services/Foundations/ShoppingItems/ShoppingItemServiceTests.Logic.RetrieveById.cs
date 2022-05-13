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
        public void ShouldRetrieveShoppingItemById()
        {
            // given
            ShoppingItem randomShoppingItem = CreateRandomShoppingItem();
            ShoppingItem inputShoppingItem = randomShoppingItem;
            ShoppingItem storageShoppingItem = inputShoppingItem;
            ShoppingItem expectedShoppingItem = storageShoppingItem.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.SelectShoppingItemById(inputShoppingItem.Id))
                    .Returns(storageShoppingItem);

            // when
            ShoppingItem actualShoppingItem =
                this.shoppingItemService.RetrieveShoppingItemById(inputShoppingItem.Id);

            // then
            actualShoppingItem.Should().BeEquivalentTo(expectedShoppingItem);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectShoppingItemById(inputShoppingItem.Id),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}