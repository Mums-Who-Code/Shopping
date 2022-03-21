// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using ShoppingList.ConsoleApp.Brokers.Loggings;
using ShoppingList.ConsoleApp.Brokers.Storages;
using ShoppingList.ConsoleApp.Models.ShoppingItems;

namespace ShoppingList.ConsoleApp.Services.Foundations.ShoppingItems
{
    public class ShoppingItemService : IShoppingItemService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        public ShoppingItemService(
            IStorageBroker storageBroker, 
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }
        public ShoppingItem AddShoppingItem(ShoppingItem shoppingItem) =>
             this.storageBroker.InsertShoppingItem(shoppingItem);
    }
}
