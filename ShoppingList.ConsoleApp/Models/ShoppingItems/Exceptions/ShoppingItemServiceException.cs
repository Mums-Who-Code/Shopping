// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xeptions;

namespace ShoppingList.ConsoleApp.Models.ShoppingItems.Exceptions
{
    public class ShoppingItemServiceException : Xeption
    {
        public ShoppingItemServiceException(Xeption innerException)
            : base(message: "ShoppingItem service error occured, contact support.",
                  innerException)
        { } 
    }
}
