// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using ShoppingList.ConsoleApp.Brokers.Loggings;
using ShoppingList.ConsoleApp.Brokers.Storages;
using ShoppingList.ConsoleApp.Models.ShoppingItems;

namespace ShoppingList.ConsoleApp.Services.Foundations.ShoppingItems
{
    public partial class ShoppingItemService : IShoppingItemService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        public ShoppingItemService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }
        /*public ShoppingItem AddShoppingItem(ShoppingItem shoppingItem)
        {
            if(shoppingItem == null)
            {
                var exception = new ShoppingItemValidationException(new NullShoppingItemException());
                this.loggingBroker.LogError(exception);
                throw exception;
            }
            return this.storageBroker.InsertShoppingItem(shoppingItem);
        }*/

        public ShoppingItem AddShoppingItem(ShoppingItem shoppingItem) =>
        TryCatch(() =>
        {
            ValidateShoppingItem(shoppingItem);

            return this.storageBroker.InsertShoppingItem(shoppingItem);
        });
    }
}
