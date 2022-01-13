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
    public class ShoppingItemValidationException : Xeption
    {
        public ShoppingItemValidationException(Xeption innerException)
            : base(message: "Shopping item validation error occured, fix the errors and try again.",innerException)
        {
        }
    }
}
