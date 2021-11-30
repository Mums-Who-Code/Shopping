// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using ShoppingList.ConsoleApp.Models.Samples;

namespace ShoppingList.ConsoleApp.Brokers.Storages
{
    partial interface IStorageBroker
    {
        Shopping InsertShopping(Shopping shopping);
    }
}
