// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using ShoppingList.ConsoleApp.Models.ShoppingItems;
using ShoppingList.ConsoleApp.Models.ShoppingItems.Exceptions;

namespace ShoppingList.ConsoleApp.Services.Foundations.ShoppingItems
{
    public partial class ShoppingItemService
    {
        private static void ValidateShoppingItem(ShoppingItem shoppingItem)
        {
            ValidateShoppingItemIsNotNull(shoppingItem);

            Validate(
                (Rule: IsInvalid(integerValue: shoppingItem.Id), Parameter: nameof(ShoppingItem.Id)),
                (Rule: IsInvalid(name: shoppingItem.Name), Parameter: nameof(ShoppingItem.Name)),
                (Rule: IsInvalid(integerValue: shoppingItem.Quantity), Parameter: nameof(ShoppingItem.Quantity)));
        }

        private static void ValidateInput(int id) =>
            Validate((Rule: IsInvalid(integerValue: id), Parameter: nameof(ShoppingItem.Id)));

        private static dynamic IsInvalid(int integerValue) => new
        {
            condition = integerValue == default,
            Message = "Value is required.",
        };

        private static dynamic IsInvalid(string name) => new
        {
            condition = String.IsNullOrWhiteSpace(name),
            Message = "Name is required.",
        };

        private static void ValidateShoppingItemIsNotNull(ShoppingItem shoppingItem)
        {
            if (shoppingItem == null)
            {
                throw new NullShoppingItemException();
            }
        }

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidShoppingItemException = new InvalidShoppingItemException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.condition)
                {
                    invalidShoppingItemException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidShoppingItemException.ThrowIfContainsErrors();
        }
    }
}