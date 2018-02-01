using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using System.Data.Entity;
using System.Xml.Linq;
using System.Xml.XPath;

using Newtonsoft.Json;

using MassDefect.Data;
using MassDefect.Client.DTOs;
using MassDefect.Models;

namespace MassDefect.Client
{
    public class MassDefectMain
    {
        private const string SolarSystemsPath = "../../../datasets/solar-systems.json";
        private const string StarsPath = "../../../datasets/stars.json";
        private const string PlanetsPath = "../../../datasets/planets.json";
        private const string PersonsPath = "../../../datasets/persons.json";
        private const string AnomaliesPath = "../../../datasets/anomalies.json";
        private const string AnomalyVictimsPath = "../../../datasets/anomaly-victims.json";
        private const string NewAnomaliesPath = "../../../datasets/new-anomalies.xml";

        public static void Main()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<MassDefectContext>());

            ImportSolarSystems();
            ImportStars();
            ImportPlanets();
            ImportPersons();
            ImportAnomalies();
            ImportAnomalyVictims();

            ImportNewAnomalies();

            ExportPlanetsWhichAreNotAnomalyOrigins();
            ExportPeopleWhoHaveNotBeenVictims();
            ExportTopAnomaly();

            ExportAllAnomalies();
        }

        private static void ImportSolarSystems()
        {
            MassDefectContext context = new MassDefectContext();
            var solarSystemsJSON = File.ReadAllText(SolarSystemsPath);
            var deserializedSolarSystems = 
                JsonConvert.DeserializeObject<IEnumerable<SolarSystemDTO>>(solarSystemsJSON);

            foreach (var solarSystemDTO in deserializedSolarSystems)
            {
                if (solarSystemDTO.Name == null)
                {
                    Console.WriteLine("Error: Invalid data.");

                    continue;
                }

                var newSolarSystem = new SolarSystem { Name = solarSystemDTO.Name };
                context.SolarSystems.Add(newSolarSystem);
                Console.WriteLine("Successfully imported solar system {0}.", solarSystemDTO.Name);
            }

            context.SaveChanges();
        }

        private static void ImportStars()
        {
            MassDefectContext context = new MassDefectContext();
            var starsJSON = File.ReadAllText(StarsPath);
            var deserializedStars =
                JsonConvert.DeserializeObject<IEnumerable<StarDTO>>(starsJSON);

            foreach (var starDTO in deserializedStars)
            {
                if (starDTO.Name == null)
                {
                    Console.WriteLine("Error: Invalid data.");

                    continue;
                }

                var newStar = new Star { Name = starDTO.Name };
                var solarSystem = context.SolarSystems.
                    Where(s => s.Name == starDTO.SolarSystem).FirstOrDefault();
                if (solarSystem == null)
                {
                    Console.WriteLine("Error: Invalid data.");

                    continue;
                }

                newStar.SolarSystem = solarSystem;
                context.Stars.Add(newStar);
                Console.WriteLine("Successfully imported star {0}.", starDTO.Name);
            }

            context.SaveChanges();
        }

        private static void ImportPlanets()
        {
            MassDefectContext context = new MassDefectContext();
            var planetsJSON = File.ReadAllText(PlanetsPath);
            var deserializedPlanets =
                JsonConvert.DeserializeObject<IEnumerable<PlanetDTO>>(planetsJSON);

            foreach (var planetDTO in deserializedPlanets)
            {
                if (planetDTO.Name == null || planetDTO.SolarSystem == null || planetDTO.Sun == null)
                {
                    Console.WriteLine("Error: Invalid data.");

                    continue;
                }

                var newPlanet= new Planet { Name = planetDTO.Name };
                var solarSystem = context.SolarSystems.
                    Where(s => s.Name == planetDTO.SolarSystem).FirstOrDefault();
                if (solarSystem == null)
                {
                    Console.WriteLine("Error: Invalid data.");

                    continue;
                }

                newPlanet.SolarSystem = solarSystem;

                var newSun = new Sun { Name = planetDTO.Sun };
                newSun.Planet = newPlanet;
                newSun.SolarSystem = solarSystem;
                context.Planets.Add(newPlanet);
                context.Suns.Add(newSun);
                Console.WriteLine("Successfully imported planet {0}.", planetDTO.Name);
            }

            context.SaveChanges();
        }

        private static void ImportPersons()
        {
            MassDefectContext context = new MassDefectContext();
            var personsJSON = File.ReadAllText(PersonsPath);
            var deserializedPersons =
                JsonConvert.DeserializeObject<IEnumerable<PersonDTO>>(personsJSON);

            foreach (var personDTO in deserializedPersons)
            {
                if (personDTO.Name == null || personDTO.HomePlanet == null)
                {
                    Console.WriteLine("Error: Invalid data.");

                    continue;
                }

                var newPerson = new Person { Name = personDTO.Name };
                var planet = GetPlanet(personDTO.HomePlanet, context);
                if (planet == null)
                {
                    Console.WriteLine("Error: Invalid data.");

                    continue;
                }

                newPerson.Planet = planet;
                context.Persons.Add(newPerson);
                Console.WriteLine("Successfully imported person {0}.", personDTO.Name);
            }

            context.SaveChanges();
        }

        private static void ImportAnomalies()
        {
            MassDefectContext context = new MassDefectContext();
            var anomaliesJSON = File.ReadAllText(AnomaliesPath);
            var deserializedAnomalies =
                JsonConvert.DeserializeObject<IEnumerable<AnomalyDTO>>(anomaliesJSON);

            foreach (var anomalyDTO in deserializedAnomalies)
            {
                if (anomalyDTO.OriginPlanet == null || anomalyDTO.TeleportPlanet == null)
                {
                    Console.WriteLine("Error: Invalid data.");

                    continue;
                }

                var originPlanet = GetPlanet(anomalyDTO.OriginPlanet, context);
                var teleportPlanet = GetPlanet(anomalyDTO.TeleportPlanet, context);
                if (originPlanet == null || teleportPlanet == null)
                {
                    Console.WriteLine("Error: Invalid data.");

                    continue;
                }

                var newAnomaly = new Anomaly
                {
                    OriginPlanet = originPlanet,
                    TeleportPlanet = teleportPlanet
                };

                context.Anomalies.Add(newAnomaly);
                Console.WriteLine("Successfully imported anomaly.");
            }

            context.SaveChanges();
        }

        private static void ImportAnomalyVictims()
        {
            MassDefectContext context = new MassDefectContext();
            var anomalyVictimsJSON = File.ReadAllText(AnomalyVictimsPath);
            var deserializedAnomalyVictims =
                JsonConvert.DeserializeObject<IEnumerable<AnomalyVictimDTO>>(anomalyVictimsJSON);

            foreach (var anomalyVictim in deserializedAnomalyVictims)
            {
                if (anomalyVictim.Id == null || anomalyVictim.Person == null)
                {
                    Console.WriteLine("Error: Invalid data.");

                    continue;
                }

                var anomaly = context.Anomalies.Find(anomalyVictim.Id);
                var person = 
                    context.Persons.Where(p => p.Name == anomalyVictim.Person).FirstOrDefault();
                if (anomaly == null || person == null)
                {
                    Console.WriteLine("Error: Invalid data.");

                    continue;
                }

                anomaly.Persons.Add(person);
                person.Anomalies.Add(anomaly);
            }

            context.SaveChanges();
        }

        private static void ImportNewAnomalies()
        {
            MassDefectContext context = new MassDefectContext();
            var newAnomaliesXML = XDocument.Load(NewAnomaliesPath);
            var anomalyNodes = newAnomaliesXML.XPathSelectElements("anomalies/anomaly");

            foreach (var anomalyNode in anomalyNodes)
            {
                var originPlanetAttribute = anomalyNode.Attribute("origin-planet");
                var teleportPlanetAttribute = anomalyNode.Attribute("teleport-planet");
                if (originPlanetAttribute == null || teleportPlanetAttribute == null)
                {
                    Console.WriteLine("Error: Invalid data.");

                    continue;
                }

                var originPlanet = GetPlanet(originPlanetAttribute.Value, context);
                var teleportPlanet = GetPlanet(teleportPlanetAttribute.Value, context);
                if (originPlanet == null || teleportPlanet == null)
                {
                    Console.WriteLine("Error: Invalid data.");

                    continue;
                }

                var anomalyEntity = new Anomaly
                {
                    OriginPlanet = originPlanet,
                    TeleportPlanet = teleportPlanet
                };

                var victimNodes = anomalyNode.XPathSelectElements("victims/victim");
                foreach (var victimNode in victimNodes)
                {
                    var victimAttribute = victimNode.Attribute("name");
                    if (victimAttribute == null)
                    {
                        Console.WriteLine("Error: Invalid data.");

                        continue;
                    }

                    var victim = context.Persons.
                        Where(p => p.Name == victimAttribute.Value).FirstOrDefault();
                    if (victim == null)
                    {
                        Console.WriteLine("Error: Invalid data.");

                        continue;
                    }

                    anomalyEntity.Persons.Add(victim);
                }

                context.Anomalies.Add(anomalyEntity);
            }

            context.SaveChanges();
        }

        private static void ExportTopAnomaly()
        {
            MassDefectContext context = new MassDefectContext();
            var topAnomaly =
                context.Anomalies.Include(x => x.Persons)
                .OrderByDescending(x => x.Persons.Count)
                .Take(1)
                .Select(x => new
                {
                    id = x.Id,
                    originPlanet = new
                    {
                        name = x.OriginPlanet.Name
                    },
                    teleportPlanet = new
                    {
                        name = x.TeleportPlanet.Name
                    },
                    victimsCount = x.Persons.Count
                });

            var topAnomalyAsJSON = JsonConvert.SerializeObject(topAnomaly, Formatting.Indented);
            File.WriteAllText("../../../exports/exported-top-anomaly.json", topAnomalyAsJSON);
        }

        private static void ExportPeopleWhoHaveNotBeenVictims()
        {
            MassDefectContext context = new MassDefectContext();
            var exportedPersons =
                context.Persons.Include(x => x.Anomalies).
                Where(x => !x.Anomalies.Any()).
                Select(x => new
                {
                    name = x.Name,
                    homePlanet = x.Planet.Name
                });

            var personsAsJSON = JsonConvert.SerializeObject(exportedPersons, Formatting.Indented);
            File.WriteAllText("../../../exports/exported-persons.json", personsAsJSON);
        }

        private static void ExportPlanetsWhichAreNotAnomalyOrigins()
        {
            MassDefectContext context = new MassDefectContext();
            var exportedPlanets =
                context.Planets.Include(p => p.OriginPlanetAnomalies).
                Where(p => !p.OriginPlanetAnomalies.Any()).
                Select(p => new
                {
                    name = p.Name
                });

            var planetsAsJSON = JsonConvert.SerializeObject(exportedPlanets, Formatting.Indented);
            File.WriteAllText("../../../exports/exported-planets.json", planetsAsJSON);
        }

        private static void ExportAllAnomalies()
        {
            MassDefectContext context = new MassDefectContext();
            var exportedAnomalies =
                context.Anomalies.Include(a => a.OriginPlanet).
                Include(a => a.TeleportPlanet).
                Include(a => a.Persons).
                Select(a => new
                {
                    a.Id,
                    OriginPlanet = a.OriginPlanet.Name,
                    TeleportPlanet = a.TeleportPlanet.Name,
                    Victims = a.Persons.Select(x => x.Name)
                }).
                OrderBy(a => a.Id);

            var xmlDocument = new XElement("anomalies");

            foreach (var anomaly in exportedAnomalies)
            {
                var anomalyNode = new XElement("anomaly");
                anomalyNode.Add(new XAttribute("id", anomaly.Id));
                anomalyNode.Add(new XAttribute("orgin-planet", anomaly.OriginPlanet));
                anomalyNode.Add(new XAttribute("teleport-planet", anomaly.TeleportPlanet));
                var victimsNode = new XElement("victims");
                foreach (var victim in anomaly.Victims)
                {
                    var victimNode = new XElement("victim");
                    victimNode.Add(new XAttribute("name", victim));
                    victimsNode.Add(victimNode);
                }

                anomalyNode.Add(victimsNode);
                xmlDocument.Add(anomalyNode);
            }

            xmlDocument.Save("../../../exports/exported-anomalies.xml");
        }

        private static Planet GetPlanet(string planetName, MassDefectContext context)
        {
            var planet = context.Planets.
                    Where(p => p.Name == planetName).FirstOrDefault();

            return planet;
        }
    }
}
