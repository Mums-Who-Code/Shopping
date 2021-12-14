// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using ShoppingList.ConsoleApp.Brokers.Storages;
using ShoppingList.ConsoleApp.Models.ShoppingItems;

namespace ShoppingList.ConsoleApp.Services.Foundations.ShoppingItems
{
    public class ShoppingItemService : IShoppingItemService
    {
        private readonly IStorageBroker storageBroker;

        public ShoppingItemService(IStorageBroker storageBroker) =>
            this.storageBroker = storageBroker;

        public ShoppingItem AddShoppingItem(ShoppingItem shoppingItem) =>
            throw new NotImplementedException();
    }
}
