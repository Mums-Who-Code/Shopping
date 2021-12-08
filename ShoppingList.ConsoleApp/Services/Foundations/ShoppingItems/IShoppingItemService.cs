// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingList.ConsoleApp.Models.ShoppingItems;

namespace ShoppingList.ConsoleApp.Services.Foundations.ShoppingItems
{
    public interface IShoppingItemService
    {
        ShoppingItem AddShoppingItem(ShoppingItem shoppingItem);
    }
}
