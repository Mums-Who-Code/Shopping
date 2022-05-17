// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System.Collections.Generic;
using ShoppingList.ConsoleApp.Models.ShoppingItems;

namespace ShoppingList.ConsoleApp.Brokers.Storages
{
    public partial class StorageBroker : IStorageBroker
    {
        List<ShoppingItem> ShoppingItems = new List<ShoppingItem>();

        public ShoppingItem InsertShoppingItem(ShoppingItem shoppingitem)
        {
            ShoppingItems.Add(shoppingitem);

            return shoppingitem;
        }

        public List<ShoppingItem> SelectAllShoppingItems() => ShoppingItems;

        public ShoppingItem SelectShoppingItemById(int id) =>
            ShoppingItems.Find(shoppingItem => shoppingItem.Id == id);

        public ShoppingItem UpdateShoppingItem(ShoppingItem inputShoppingItem)
        {
            ShoppingItems.RemoveAll(shoppingItem => shoppingItem.Id == inputShoppingItem.Id);
            ShoppingItems.Add(inputShoppingItem);

            return inputShoppingItem;
        }
    }
}