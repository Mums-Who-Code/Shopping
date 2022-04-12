// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using Xeptions;

namespace ShoppingList.ConsoleApp.Models.ShoppingItems.Exceptions
{
    public class InvalidShoppingItemException : Xeption
    {
        public InvalidShoppingItemException()
            : base(message: "Shopping Item is invalid, fix the errors and try again.")
        { }
    }
}
