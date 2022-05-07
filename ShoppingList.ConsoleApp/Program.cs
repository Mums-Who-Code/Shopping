// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using Microsoft.Extensions.Logging;
using ShoppingList.ConsoleApp.Brokers.Loggings;
using ShoppingList.ConsoleApp.Brokers.Storages;
using ShoppingList.ConsoleApp.Models.ShoppingItems;
using ShoppingList.ConsoleApp.Services.Foundations.ShoppingItems;

namespace ShoppingList.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var storageBroker = new StorageBroker();
            var loggerFactory = new LoggerFactory();
            var logger = new Logger<LoggingBroker>(loggerFactory);
            var loggingBroker = new LoggingBroker(logger);
            var shoppingItemService = new ShoppingItemService(storageBroker, loggingBroker);

            var inputShoppingItem = new ShoppingItem
            {
                Id = 24,
                Name = "Rice",
                Quantity = 2
            };

            shoppingItemService.AddShoppingItem(inputShoppingItem);
        }
    }
}