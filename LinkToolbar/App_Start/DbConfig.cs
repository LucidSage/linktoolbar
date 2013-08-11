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

//            Database.SetInitializer<UsersContext>(null);
//            try
//            {
//                using (var context = new LinkToolbarContext())
//                {
//                    if (!context.Database.Exists())
//                    {
//                        ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
//                    }
//                }
//
//                WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
//            }
//            catch (Exception ex)
//            {
//                throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
//            }
        }
    }
}