// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------
using System.Collections.Generic;
using ShoppingList.ConsoleApp.Models.Samples;

namespace ShoppingList.ConsoleApp.Brokers.Storages
{
    internal partial class StorageBroker : IStorageBroker
    {
        List<Shopping> Shoppings = new List<Shopping>();
        public Shopping InsertShopping(Shopping shopping)
        {
            Shoppings.Add(shopping);

            return shopping;
        }
    }
}
