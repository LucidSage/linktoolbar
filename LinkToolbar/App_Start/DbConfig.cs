using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using LinkToolbar.Migrations;
using LinkToolbar.Models;
using WebMatrix.WebData;

// ReSharper disable once CheckNamespace

namespace LinkToolbar
{
    public class DbConfig
    {
        public static void InitializeDatabase()
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<LinkToolbarContext, Configuration>());
        }
    }
}