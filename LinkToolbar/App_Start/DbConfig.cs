using System.Collections.Generic;
using System.Data.Entity;
using LinkToolbar.Models;

// ReSharper disable once CheckNamespace

namespace LinkToolbar
{
    public class DbConfig
    {
        public static void InitializeDatabase()
        {
            Database.SetInitializer(
                new DropCreateDatabaseIfModelChanges<LinkToolbarContext>());
        }
    }

    public class DropCreateDatabaseAlwaysWithSeed<T> : DropCreateDatabaseAlways<T> where T : LinkToolbarContext
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