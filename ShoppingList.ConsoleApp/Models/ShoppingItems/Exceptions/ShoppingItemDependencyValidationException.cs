// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using Xeptions;

namespace ShoppingList.ConsoleApp.Models.ShoppingItems.Exceptions
{
    public class ShoppingItemDependencyValidationException : Xeption
    {
        public ShoppingItemDependencyValidationException(Xeption innerException)
            : base(message: "Shopping item dependency validation error occured, fix the errors and try again.",
                  innerException)
        { }
    }
}