// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using ShoppingList.ConsoleApp.Brokers.Storages;
using ShoppingList.ConsoleApp.Services.Foundations.ShoppingItems;

namespace ShoppingList.Tests.Unit.Services.Foundations.ShoppingItems
{
    class ShoppingItemServiceTests
    {
        private readonly IShoppingItemService shoppingItemService;
        private readonly Mock<IStorageBroker> storageBrokerMock;

        public ShoppingItemServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();    

            this.shoppingItemService = new ShoppingItemService(
                this.storageBrokerMock.Object);   
        }
    }
}
