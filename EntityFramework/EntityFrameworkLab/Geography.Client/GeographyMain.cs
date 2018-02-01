using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Script.Serialization;
using System.IO;
using System.Xml.Linq;

using Geography.Data;
using System.Xml.XPath;

namespace Geography.Client
{
    public class GeographyMain
    {
        public static void Main()
        {
            var context = new GeographyEntities();
            //foreach (var continent in context.Continents)
            //{
            //    Console.WriteLine(continent.ContinentName);
            //}

            var rivers = context.Rivers.OrderByDescending(r => r.Length).
                Select(r =>
                new
                {
                    RiverName = r.RiverName,
                    Length = r.Length,
                    Countries = r.Countries.Select(c => c.CountryName)
                });

            //foreach (var river in rivers)
            //{
            //    Console.WriteLine(river.RiverName);
            //    Console.WriteLine(river.Length);
            //    Console.WriteLine(string.Join(", ", river.Countries));
            //}

            //string riversAsJSON = SerializeQueryableToJSON(rivers, "riversJSON.json");
            //Console.WriteLine(riversAsJSON);

            //foreach (var monastery in context.Monasteries)
            //{
            //    Console.WriteLine(monastery.Name);
            //}

            var countriesWithMonasteries = context.Countries.OrderBy(c => c.CountryName).
                    Where(c => c.Monasteries.Any()).
                    Select(c =>
                            new 
                            {
                                CountryName = c.CountryName,
                                Monasteries = c.Monasteries.OrderBy(m => m.Name).
                                                            Select(m => m.Name)
                            });

            //foreach (var country in countriesWithMonasteries)
            //{
            //    Console.WriteLine(country.CountryName + " " +
            //        string.Join(", ", country.Monasteries));
            //}

            //var countriesWithMonasteriesXMLRootElement = new XElement("countries-with-monasteries");

            //foreach (var country in countriesWithMonasteries)
            //{
            //    var countryXML = new XElement("country");
            //    countryXML.Add(new XAttribute("name", country.CountryName));
            //    countriesWithMonasteriesXMLRootElement.Add(countryXML);

            //    foreach (var monastery in country.Monasteries)
            //    {
            //        countryXML.Add(new XElement("monastery", monastery));
            //    }
            //}

            //var countriesWithMonasteriesXML = new XDocument(countriesWithMonasteriesXMLRootElement);
            //countriesWithMonasteriesXML.Save("countriesWithMonasteriesXML.xml");

            //Console.WriteLine(countriesWithMonasteriesXML);

            var riversXML = XDocument.Load("../../rivers.xml");
            //Console.WriteLine(riversXML);

            var riverNodes = riversXML.XPathSelectElements("/rivers/river");
            foreach (var riverNode in riverNodes)
            {
                string riverName = riverNode.Element("name").Value;
                int riverLength = int.Parse(riverNode.Element("length").Value);
                string riverOutflow = riverNode.Element("outflow").Value;
                int? drainageArea = null;
                if (riverNode.Element("drainage-area") != null)
                {
                    drainageArea = int.Parse(riverNode.Element("drainage-area").Value);
                }

                int? discharge = null;
                if (riverNode.Element("average-discharge") != null)
                {
                    discharge = int.Parse(riverNode.Element("average-discharge").Value);
                }

                var river = new River()
                {
                    RiverName = riverName,
                    Length = riverLength,
                    Outflow = riverOutflow,
                    DrainageArea = drainageArea,
                    AverageDischarge = discharge
                };

                context.Rivers.Add(river);

                var countryNodes = riverNode.XPathSelectElements("countries/country");
                var countryNames = countryNodes.Select(c => c.Value);
                foreach (var countryName in countryNames)
                {
                    var country = context.Countries.
                        FirstOrDefault(c => c.CountryName == countryName);
                    river.Countries.Add(country);
                }
            }

            context.SaveChanges();
        }

        private static string SerializeQueryableToJSON(IQueryable<object> queryable, string filePath)
        {
            var jsSerializer = new JavaScriptSerializer();

            string result = jsSerializer.Serialize(queryable.ToList());

            File.WriteAllText("riversJSON.json", filePath);

            return result;
        }
    }
}
