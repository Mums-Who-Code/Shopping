// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using ShoppingList.ConsoleApp.Models.ShoppingItems;

namespace ShoppingList.ConsoleApp.Services.Foundations.ShoppingItems
{
    public interface IShoppingItemService
    {
        ShoppingItem AddShoppingItem(ShoppingItem shoppingItem);
    }
}