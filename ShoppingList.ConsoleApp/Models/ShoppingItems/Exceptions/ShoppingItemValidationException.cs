// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using Xeptions;

namespace ShoppingList.ConsoleApp.Models.ShoppingItems.Exceptions
{
    public class ShoppingItemValidationException : Xeption
    {
        public ShoppingItemValidationException(Xeption innerException)
            : base(message: "Shopping item validation error occurred, fix the errors and try again.", 
                  innerException)
        { }
    }
}