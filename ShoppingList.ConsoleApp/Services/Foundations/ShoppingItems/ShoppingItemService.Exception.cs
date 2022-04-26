// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
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
            catch (InvalidShoppingItemException invalidShoppingItemException)
            {
                throw CreateAndLogValidationException(invalidShoppingItemException);
            }
            catch (Exception exception)
            {
                var failedShoppingItemServiceException =
                    new FailedShoppingItemServiceException(exception);

                throw CreateAndLogServiceException(failedShoppingItemServiceException);
            }
        }

        private ShoppingItemValidationException CreateAndLogValidationException(Xeption exception)
        {
            var shoppingItemValidationException = new ShoppingItemValidationException(exception);
            this.loggingBroker.LogError(shoppingItemValidationException);

            return shoppingItemValidationException;
        }

        private ShoppingItemServiceException CreateAndLogServiceException(Xeption exception)
        {
            var shoppingItemServiceException = new ShoppingItemServiceException(exception);
            this.loggingBroker.LogError(shoppingItemServiceException);

            return shoppingItemServiceException;
        }
    }
}
