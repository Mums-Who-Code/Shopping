// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using ShoppingList.ConsoleApp.Models.ShoppingItems;
using ShoppingList.ConsoleApp.Models.ShoppingItems.Exceptions;
using Xeptions;

namespace ShoppingList.ConsoleApp.Services.Foundations.ShoppingItems
{
    public partial class ShoppingItemService
    {
        private delegate ShoppingItem ReturningShoppingItemFunction();

        private ShoppingItem TryCatch(ReturningShoppingItemFunction returningShoppingItemFunction)
        {
            try
            {
                return returningShoppingItemFunction();
            }
            catch (NullShoppingItemException nullShoppingItemException)
            {
                throw CreateAndLogValidationException(nullShoppingItemException);
            }
        }

        private ShoppingItemValidationException CreateAndLogValidationException(Xeption exception)
        {
            var shoppingItemValidationException = new ShoppingItemValidationException(exception);
            this.loggingBroker.LogError(shoppingItemValidationException);

            throw shoppingItemValidationException;
        }
    }
}
