// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System.Collections.Generic;
using ShoppingList.ConsoleApp.Models.ShoppingItems;

namespace ShoppingList.ConsoleApp.Brokers.Storages
{
    internal partial class StorageBroker : IStorageBroker
    {
        List<ShoppingItem> ShoppingItems = new List<ShoppingItem>();

        public ShoppingItem InsertShoppingItem(ShoppingItem shoppingitem)
        {
            ShoppingItems.Add(shoppingitem);

            return shoppingitem;
        }
    }
}
