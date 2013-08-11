using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
                new DropCreateDatabaseIfModelChangesWithSeed<LinkToolbarContext>());

            try
            {
                using (var context = new LinkToolbarContext())
                {
                    if (!context.Database.Exists())
                    {
                        // Create the SimpleMembership database without Entity Framework migration schema
                        ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                    }
                }

                WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
            }
        }
    }

    public class DropCreateDatabaseIfModelChangesWithSeed<T> : DropCreateDatabaseIfModelChanges<T> where T : LinkToolbarContext
    {
        protected override void Seed(T context)
        {
            foreach (Link link in createLinks())
            {
                context.Links.Add(link);
            }

            context.SaveChanges();
            base.Seed(context);
        }

        private IList<Link> createLinks()
        {
            IList<Link> seeds = new List<Link>();
            const string googleHref = "http://google.com";
            for (int i = 0; i < 10; i++)
            {
                var seedObject = new Link
                {
                    ImageSrc = "~/Images/heartAid.jpg",
                    Version = 1,
                    ImageAltText = "Alt" + i,
                    Name = "Name" + i,
                    Target = LinkTarget.Current,
                    TargetHref = googleHref,
                    Visibility = ToolbarVisibility.Public
                };

                if (i%2 == 0)
                {
                    seedObject.Links = createLinks();
                }

                seeds.Add(seedObject);
            }

            return seeds;
        }
    }
}