// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using Xeptions;

namespace ShoppingList.ConsoleApp.Models.ShoppingItems.Exceptions
{
    public class NullArgumentShoppingItemException : Xeption
    {
        public NullArgumentShoppingItemException(Exception innerException)
            : base(message: "Null argument shopping item error occurred, fix the errors and try again.",
                  innerException)
        { }
    }
}