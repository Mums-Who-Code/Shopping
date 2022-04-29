// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using Xeptions;

namespace ShoppingList.ConsoleApp.Models.ShoppingItems.Exceptions
{
    public class NullShoppingItemException : Xeption
    {
        public NullShoppingItemException()
            : base(message: "Shopping item is null.")
        {
        }
    }
}