using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using LinkToolbar.Models;

namespace LinkToolbar.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<LinkToolbarContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LinkToolbarContext context)
        {
            //  This method will be called after migrating to the latest version.
#if DEBUG
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Links.AddOrUpdate(
                    link => link.LinkId,
                    createLinks().ToArray());
            //context.SaveChanges();
#endif
        }

        private IList<Link> createLinks()
        {
            IList<Link> seeds = new List<Link>();

            seeds.Add(
                createLink("MONITORING", "", new List<Link>
                {
                    createLink("Drought", "", new List<Link>
                    {
                        createLink("USA Drought", "http://droghtmonitor.unl.edu", new List<Link>()),
                        createLink("Global Drought Link", "http://drought.mssl.ucl.ac.uk/drought.html", new List<Link>())
                    }),
                    createLink("Earthquake", "", new List<Link>
                    {
                        createLink("World USGS", "http://earthquake.usgs.gov/earthquakes/map/", new List<Link>()),
                        createLink("USA Live Heliplots",
                            "http://earthquake.usgs.gov/monitoring/operations/heliplots_gsn.php", new List<Link>()),
                        createLink("PNW Network Earthquakes", "http://www.pnsn.org/earthquakes/recent", new List<Link>())
                    })
                }));

            seeds.Add(createLink("-", "", new List<Link>()));

            seeds.Add(
                createLink("RESPONSE", "", new List<Link>
                {
                    createLink("USA Links", "", new List<Link>
                    {
                        createLink("State EMA TwitList", "https://twitter.com/fema/state-em-offices",new List<Link>()),
                        createLink("State CERT", "https://docs.google.com/spreadsheet/ccc?key=0Ai5GhFyoXs0LdFo2eEp2RXhaSURGUWpHVEhOcDVNSEE#gid=0", new List<Link>()),
                        createLink("State Spreadsheet", "https://docs.google.com/spreadsheet/ccc?key=0AgnZhKE3EJxNdDBia29mMU92QkxDZENFdUxrNHVVVGc#gid=27", new List<Link>
                        {
                            createLink("Alabama", "http://www.ema.alabama.gov/", new List<Link>()),
                            createLink("Alaska", "http://www.ak-prepared.com/", new List<Link>()),
                            createLink("American Samoa", "http://asdhs.org/", new List<Link>()),
                            createLink("Arizona", "http://www.dem.azdema.gov/", new List<Link>()),
                            createLink("Arkansas", "http://adem.arkansas.gov/", new List<Link>()),
                            createLink("California", "http://www.calema.ca.gov/Pages/default.aspx", new List<Link>())
                        })
                    })
                }));

            return seeds;
        }

        private Link createLink(string name, string href, List<Link> subLinks)
        {
            return new Link
            {
                ImageSrc = "~/Images/heartAid.jpg",
                Version = 1,
                ImageAltText = name,
                Name = name,
                Target = LinkTarget.Current,
                TargetHref = href,
                Visibility = ToolbarVisibility.Public,
                Links = subLinks
            };
        }
    }
}