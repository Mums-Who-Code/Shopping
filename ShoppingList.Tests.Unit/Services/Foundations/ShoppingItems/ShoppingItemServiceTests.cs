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
using ShoppingList.ConsoleApp.Models.ShoppingItems;
using ShoppingList.ConsoleApp.Services.Foundations.ShoppingItems;
using Tynamix.ObjectFiller;

namespace ShoppingList.Tests.Unit.Services.Foundations.ShoppingItems
{
    public partial class ShoppingItemServiceTests
    {
        private readonly IShoppingItemService shoppingItemService;
        private readonly Mock<IStorageBroker> storageBrokerMock;

        public ShoppingItemServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();    

            this.shoppingItemService = new ShoppingItemService(
                this.storageBrokerMock.Object);   
        }

        private ShoppingItem CreateRandomShoppingItem() =>
            CreateShoppingItemFiller().Create();
       
        private static Filler<ShoppingItem> CreateShoppingItemFiller() => 
            new Filler<ShoppingItem>();

        
    }
}
