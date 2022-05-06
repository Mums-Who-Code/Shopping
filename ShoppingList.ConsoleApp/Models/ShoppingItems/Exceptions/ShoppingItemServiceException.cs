// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using Xeptions;

namespace ShoppingList.ConsoleApp.Models.ShoppingItems.Exceptions
{
    public class ShoppingItemServiceException : Xeption
    {
        public ShoppingItemServiceException(Xeption innerException)
            : base(message: "Shopping item service error occurred, contact support.",
                  innerException)
        { }
    }
}