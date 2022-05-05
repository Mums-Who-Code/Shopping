// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using ShoppingList.ConsoleApp.Models.ShoppingItems;

namespace ShoppingList.ConsoleApp.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ShoppingItem InsertShoppingItem(ShoppingItem shoppingitem);
    }
}