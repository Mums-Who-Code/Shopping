﻿// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;

namespace ShoppingList.ConsoleApp.Brokers.Loggings
{
    public interface ILoggingBroker
    {
        void LogError(Exception exception);
    }
}
