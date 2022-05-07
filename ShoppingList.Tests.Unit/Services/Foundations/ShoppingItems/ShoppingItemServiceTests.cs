// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Moq;
using ShoppingList.ConsoleApp.Brokers.Loggings;
using ShoppingList.ConsoleApp.Brokers.Storages;
using ShoppingList.ConsoleApp.Models.ShoppingItems;
using ShoppingList.ConsoleApp.Services.Foundations.ShoppingItems;
using Tynamix.ObjectFiller;
using Xeptions;

namespace ShoppingList.Tests.Unit.Services.Foundations.ShoppingItems
{
    public partial class ShoppingItemServiceTests
    {
        private readonly IShoppingItemService shoppingItemService;
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;

        public ShoppingItemServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.shoppingItemService = new ShoppingItemService(
               storageBroker: this.storageBrokerMock.Object,
               loggingBroker: this.loggingBrokerMock.Object);
        }

        private static Expression<Func<Xeption, bool>> SameExceptionAs(Xeption expectedException)
        {
            return actualException =>
               actualException.Message == expectedException.Message
               && actualException.InnerException.Message == expectedException.InnerException.Message
               && (actualException.InnerException as Xeption).DataEquals(expectedException.InnerException.Data);
        }

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static List<ShoppingItem> CreateRandomShoppingItems() =>
            CreateShoppingItemFiller().Create(count: GetRandomNumber()).ToList();

        private static ShoppingItem CreateRandomShoppingItem() =>
            CreateShoppingItemFiller().Create();

        private static Filler<ShoppingItem> CreateShoppingItemFiller() =>
            new Filler<ShoppingItem>();
    }
}