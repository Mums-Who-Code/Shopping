// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using ShoppingList.ConsoleApp.Models.ShoppingItems;
using ShoppingList.ConsoleApp.Models.ShoppingItems.Exceptions;

namespace ShoppingList.ConsoleApp.Services.Foundations.ShoppingItems
{
    public partial class ShoppingItemService
    {
        private static void ValidateShoppingItem(ShoppingItem shoppingItem)
        {
            if (shoppingItem == null)
            {
                throw new NullShoppingItemException();
            }
        }

    }
}
