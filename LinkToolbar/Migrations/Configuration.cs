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

            seeds.Add(createLink("PREPAREDNESS", "", new List<Link>()));

            seeds.Add(createLink("MONITORING", "", new List<Link>
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

Drought
	USA Drought http://droughtmonitor.unl.edu/
	Global Drought Link http://drought.mssl.ucl.ac.uk/drought.html 
	

Earthquake
	World USGS http://earthquake.usgs.gov/earthquakes/map/
	USA Live Heliplots http://earthquake.usgs.gov/monitoring/operations/heliplots_gsn.php
	PNW Network Earthquakes http://www.pnsn.org/earthquakes/recent 
	California Heliplots http://www.ncedc.org/bdsn/quicklook.html 
	European Earthquake Ctr. EMSC http://www.emsc-csem.org/#2
	Iranian Earthquake Ctr  http://irsc.ut.ac.ir/currentearthq.php
	EQ Reporter http://earthquake-report.com/ 

Hurricane/Cyclone
	Global moisture plot http://tropic.ssec.wisc.edu/real-time/mimic-tpw/global/main.html
	National Hurricane Center http://www.nhc.noaa.gov/ 
	NRL Tropical Cyclone Page http://www.nrlmry.navy.mil/TC.html
	NASA Hurricanes/Tropical Cyclones http://www.nasa.gov/mission_pages/hurricanes/main/index.html
	Weather Underground http://www.wunderground.com/tropical/
	CIMSS Tropical Cyclone http://tropic.ssec.wisc.edu/

Ocean/Flood
	D.A.R.T. Buoys http://www.ndbc.noaa.gov
	Ocean Waveheight http://www.oceanweather.com/data/
	USA - Flood outlook http://www.hpc.ncep.noaa.gov/nationalfloodoutlook/index.html
	USA- Coastal Watch http://oceanwatch.noaa.gov/cwn/cw_regionalnodes.html 
	NOAA Flood Watch http://www.noaawatch.gov/floods.php
	European Commission Floods Portal http://floods.jrc.ec.europa.eu/
	USGS WaterWatch http://waterwatch.usgs.gov/
Tsunami
	D.A.R.T. Buoys http://www.ndbc.noaa.gov
	Tsunami Travel Time http://www.ngdc.noaa.gov/hazard/tsu_travel_time_events.shtml
	TWarnC - Australia http://www.bom.gov.au/tsunami/
	TWarnC - Japan http://www.jma.go.jp/en/tsunami/
	TWarnC - Pacific http://ptwc.weather.gov/
	TWarnC - Carribean http://www.srh.noaa.gov/srh/ctwp/

Volcano
	US Hazards http://volcanoes.usgs.gov/
	World Map Current events http://volcano.si.edu/weekly_report.cfm
	Ash Advisories http://www.ssd.noaa.gov/VAAC/messages.html
	UK Advisories http://www.metoffice.gov.uk/aviation/vaac/vaacuk.html
	HR Volcano Page http://www.humanityroad.org/Volcano.htm#.UgaTLm2yk_o 

Severe Weather
	USA NWS http://radar.weather.gov/ridge/Conus/index.php
	World WX http://severe.worldweather.org/
	World Cities Forecast http://worldweather.wmo.int/','swic
	Met by Country http://www.wmo.int/pages/members/members_en.html
	Winterwx http://www.humanityroad.org/Winterwx.htm#.UgaUMm2yk_o
	Solarwx http://www.humanityroad.org/Solar.htm
	European Severe Weather http://www.essl.org/cgi-bin/eswd/eswd.cgi
	Weather Warnings Europe http://www.meteoalarm.eu/
	
Tornado
Tornado Tracker http://www.tornadohq.com/
NOAA Storm Prediction Center http://www.spc.noaa.gov/
US Tornadoes http://www.ustornadoes.com/tornado-tracking/
Twister Tracker http://www.twistertracker.com/

Solar/Space
	Today’s Space Weather http://www.swpc.noaa.gov/ 
	Space Weather.com http://www.spaceweather.com/ 
	Geomag Realtime http://geomag.usgs.gov/map/#realtime 
HRSolarwx	http://www.humanityroad.org/Solar.htm
Space Weather Alerts https://pss.swpc.noaa.gov 
Meteors & meteorites http://lunarmeteoritehunters.blogspot.com/
Meteor Shower Plots http://fireballs.ndc.nasa.gov/

Disease Outbreak
	WHO Global Outbreak Alert & Response Network http://www.who.int/csr/outbreaknetwork/en/
	CDC Outbreaks http://www2c.cdc.gov/podcasts/createrss.asp?c=233 
	Gideon http://www.gideononline.com/
	Healthmap http://healthmap.org/en/
	USDA Animal Disease Surveillance http://www.aphis.usda.gov/vs/nahss/nahss.htm
	WAHID Interface (Animal Disease) http://www.oie.int/wahis_2/public/wahid.php/Countryinformation/countryhome

Fire Monitoring
World Current Fires http://www.fire.uni-freiburg.de/current/globalfire.htm
USA Current Wildfires http://activefiremaps.fs.fed.us/
HR Wildfires http://www.humanityroad.org/wildfires.htm
USA Incident Management	http://inciweb.org/
Wildfire Animation 13 yrs   Link

RESPONSE
DISASTER DESK (Secure portal items)
Hashboard http://humanityroad.org/Hashboard 
Advanced Image Search http://www.google.com/advanced_image_search 
Advanced Twitter Tips http://humanityroad.org/_literature_184064/Example_Advanced_Twitter_Search 
Create Event Doc https://docs.google.com/document/d/11PDTAMGJwNc4SjPGg49IAKKxdTGnNmYV9ejygiIMTyk/edit 
Earthquake Tips http://humanityroad.org/_literature_50026/Earthquake_Event_Training 
Tornado Tips http://humanityroad.org/_literature_184063/Tornado_Tweeting_Tips 

ANIMALS IN DISASTER
Service Dogs http://aiddigest.wordpress.com/2013/03/26/disaster-planning-and-response-for-service-animals/ 
AID Blog http://humanityroad.org/animals-in-disaster-digest  
Animal Shelter & Rescue Directory http://www.petfinder.com/animal-shelters-and-rescues/
International Directory of Veterinarians http://www.veterinarian-pages.com/#country=USA
Veterinarian Locator http://www.vetlocator.com/

	USA Links
State EMA TwitList  https://twitter.com/fema/state-em-offices
State CERT   Link
State Spreadsheet Link
	Alabama http://www.ema.alabama.gov/
	Alaska http://www.ak-prepared.com/ 
	American Samoa http://asdhs.org/
	Arizona http://www.dem.azdema.gov/ 
	Arkansas http://adem.arkansas.gov/ 
	California http://www.calema.ca.gov/Pages/default.aspx
	Colorado http://www.coemergency.com/
	Connecticut http://www.ct.gov/demhs/site/default.asp
	Delaware http://www.dema.delaware.gov/
	District of Columbia http://hsema.dc.gov/
	Florida http://www.floridadisaster.org/index.asp
	Georgia http://www.gema.state.ga.us/
	Guam http://ghs.guam.gov/
	Hawaii http://www.scd.hawaii.gov/
	Idaho http://www.bhs.idaho.gov/
	Illinois http://www.state.il.us/iema/
	Indiana http://www.in.gov/dhs/emermgtngpgm.htm
	Iowa http://www.iowahomelandsecurity.org/
	Kansas http://www.kansastag.gov/kdem_default.asp
	Kentucky http://kyem.ky.gov/Pages/default.aspx
	Louisiana http://www.gohsep.la.gov/
	Maine http://www.maine.gov/mema/
	Maryland http://mema.maryland.gov/Pages/homePreparedness_heat.aspx
	Massachusetts http://www.mass.gov/eopss/agencies/mema/
	Michigan http://www.michigan.gov/msp/0,4643,7-123-1593_3507---,00.html
	Minnesota https://dps.mn.gov/divisions/hsem/ 
	Mississippi http://www.msema.org/
	Missouri http://sema.dps.mo.gov/
	Montana http://montanadma.org/disaster-and-emergency-services
	Nebraska http://www.nema.ne.gov/index.shtml
	Nevada http://dem.nv.gov/
	New Hampshire http://www.nh.gov/safety/divisions/hsem/
	New Jersey http://www.ready.nj.gov/
	New Mexico http://www.nmdhsem.org/
	New York http://www.dhses.ny.gov/oem/
	North Carolina https://www.ncdps.gov/Index2.cfm?a=000003,000010
	North Dakota http://www.nd.gov/des/
	Northern Mariana Islands http://www.cnmiemo.gov.mp/
	Ohio http://ema.ohio.gov/
	Oklahoma http://www.ok.gov/OEM/
	Oregon http://www.oregon.gov/OMD/OEM/Pages/index.aspx
	Pennsylvania http://www.pema.state.pa.us/portal/server.pt/community/pema_home/4463
	Puerto Rico http://www.manejodeemergencias.pr.gov/
	Rhode Island http://www.riema.ri.gov/
	South Carolina http://www.scemd.org/
	South Dakota http://dps.sd.gov/emergency_services/emergency_management/
	Tennessee http://www.tnema.org/
	Texas http://www.txdps.state.tx.us/dem/
	US Virgin Islands http://www.vitema.gov/index.html
	Utah http://publicsafety.utah.gov/emergencymanagement/
	Vermont http://vem.vermont.gov/
	Virginia http://www.vaemergency.gov/
	Washington http://www.emd.wa.gov/
	West Virginia http://www.dhsem.wv.gov/Pages/default.aspx
	Wisconsin http://emergencymanagement.wi.gov/
	Wyoming http://wyohomelandsecurity.state.wy.us/




TRANSLATE
	

REFERENCE	

FEMA

FEMA Regional Offices - http://www.fema.gov/organizational-structure 

FEMA  - Plan and Prepare - http://www.fema.gov/what-mitigation/plan-prepare

Virtual Joint Planning Office - https://www.vjpo.org/ 

FEMA Think Tank - http://www.fema.gov/fema-think-tank

Declared Disasters - http://www.fema.gov/disasters 

Independent Study Course Selections - http://training.fema.gov/IS/

ESF Overview - http://emilms.fema.gov/IS809/ESFrefresher02.htm 

ESF #1 Transportation - wrong link

ESF #2 Communications Training - bad link

ESF #3 Public Works and Engineering - http://emilms.fema.gov/IS803/ESF0301000.htm 

ESF #4 Fire Fighting - http://emilms.fema.gov/IS804/ESF0401000.htm 

ESF #5 Emergency Management - http://emilms.fema.gov/IS805/ESF0501000.htm 

ESF #6 Mass Care, Emergency Assistance - http://training.fema.gov/EMIWeb/IS/courseOverview.aspx?code=is-806 

ESF #7 Logistics Management and Resource Support - http://emilms.fema.gov/IS807/ESF0701000.htm 

ESF #8 Public Health and Medical Services - http://emilms.fema.gov/IS808/ESF0801000.htm 

ESF #9 Search and Rescue - http://emilms.fema.gov/IS809/ESF0901000.htm 

ESF #10 Oil and Hazardous Material -  bad link

ESF #11 Agricultural and Natural Resources - http://emilms.fema.gov/IS811/ESF1101000.htm 

ESF #12 Energy - http://emilms.fema.gov/IS812/ESF1201000.htm 

ESF #13 Public Safety and Security -  wrong link

ESF #14 Long Term Community Recovery - http://emilms.fema.gov/IS814/ESF1401000.htm 

FEMA RSF Functions -  no link

FEMA Training - bad link - leads to HR homepage


	VOST

Active VOSTS - http://vosg.us/active-vosts/

Oklahoma VOST - https://twitter.com/OKVOST 

Alaska Forestry VOST - https://twitter.com/ak_forestry 

Oregon VOST - https://twitter.com/OKVOST wrong link!!!

CRESA VOST - https://twitter.com/cresavost 

Pacific NW VOST - https://twitter.com/pnwvost 

Hawaii VOST - https://twitter.com/HawaiiVOST  corrected, toolbar link is bad

Osbourne VOST -  https://twitter.com/_JSPhillips toolbar link is wrong!

New York VOST - https://twitter.com/nyvost 

North Carolina VOST -  https://twitter.com/ekendriss  toolbar link is wrong!

SW Washington State VOST -  https://twitter.com/cresavost  leads to CRESA VOST!? 

United Kingdom VOST - https://twitter.com/vostuk 

New Zealand VOST -  https://twitter.com/nzvost 

Victoria Australia VOST -  https://twitter.com/vicvost 

Canada VOST - http://www.ptsc-online.ca/canvost 


UN OCHA

UN Clusters - bad link 

OCHA Mandate in Action - Haiti Tutorial - http://www.youtube.com/watch?v=A4MSgyyfYII&feature=related 

Camp Coord Shelter & Mgt - https://sites.google.com/site/clusterstimorleste/the-cluster-system/cccm-es 

Early Recovery - https://sites.google.com/site/clusterstimorleste/the-cluster-system/early-recovery 

Telecommunications - https://sites.google.com/site/clusterstimorleste/the-cluster-system/emergency-telecommunications 

Food Security - https://sites.google.com/site/clusterstimorleste/the-cluster-system/food-security 

Health - https://sites.google.com/site/clusterstimorleste/the-cluster-system/health 

Logistics -  bad link

Nutrition - https://sites.google.com/site/clusterstimorleste/the-cluster-system/nutrition 

Protection - https://sites.google.com/site/clusterstimorleste/the-cluster-system/protection 

Water and Sanitation - https://sites.google.com/site/clusterstimorleste/the-cluster-system/water-and-sanitation 


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

        private Link createLink(string name, string href = "", List<Link> subLinks = new List<Link>())
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