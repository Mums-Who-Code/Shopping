// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System.Collections.Generic;
using ShoppingList.ConsoleApp.Models.ShoppingItems;

namespace ShoppingList.ConsoleApp.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ShoppingItem InsertShoppingItem(ShoppingItem shoppingitem);
        List<ShoppingItem> SelectAllShoppingItems();
        ShoppingItem SelectShoppingItemById(int id);
        ShoppingItem UpdateShoppingItem(ShoppingItem inputShoppingItem);
    }
}