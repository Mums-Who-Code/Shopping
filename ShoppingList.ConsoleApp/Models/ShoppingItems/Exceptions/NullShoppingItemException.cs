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
    public class NullShoppingItemException : Xeption
    {
        public NullShoppingItemException()
            : base(message: "Shopping item is null.")
        {     
        }
    }
}
