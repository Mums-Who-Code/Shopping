// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using Xeptions;

namespace ShoppingList.ConsoleApp.Models.ShoppingItems.Exceptions
{
    public class FailedShoppingItemServiceException : Xeption
    {
        public FailedShoppingItemServiceException(Exception innerException)
            : base(message: "Failed shopping item service error occurred, contact support.",
                  innerException)
        { }
    }
}