// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System.Collections.Generic;
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
        public void ShouldRetrieveAllShoppingItems()
        {
            // given
            List<ShoppingItem> randomShoppingItems = CreateRandomShoppingItems();
            List<ShoppingItem> persistedShoppingItems = randomShoppingItems;
            List<ShoppingItem> expectedShoppingItems = persistedShoppingItems.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllShoppingItems())
                    .Returns(persistedShoppingItems);

            // when
            List<ShoppingItem> actualShoppingItems =
                this.shoppingItemService.RetrieveAllShoppingItems();

            // then
            actualShoppingItems.Should().BeEquivalentTo(expectedShoppingItems);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllShoppingItems(),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
