using System.Data.SqlClient;

namespace P1InitialSetup
{
    public class P1InitialSetup
    {
        public static void Main()
        {
            string initialConnectionString = "Data Source=.;Database=master;Integrated Security=true;";

            using (SqlConnection connection = new SqlConnection(initialConnectionString))
            {
                connection.Open();

                string createDatabaseCommandParam = "IF (object_id(N'MinionsDB') IS NULL) " +
                                                    "BEGIN " +
                                                    "CREATE DATABASE MinionsDB " +
                                                    "END";
                SqlCommand createDatabaseCommand = new SqlCommand(createDatabaseCommandParam, connection);
                createDatabaseCommand.ExecuteNonQuery();
            }

            string databaseCreatedConnectionString = 
                "Data Source=.;Database=MinionsDB;Integrated Security=true;";

            using (SqlConnection connection = new SqlConnection(databaseCreatedConnectionString))
            {
                connection.Open();

                string createTableCountriesCommandParam = "CREATE TABLE Countries ( " +
                                                          "ID int IDENTITY, " +
                                                          "CountryName nvarchar(100) NOT NULL, " +
                                                          "CONSTRAINT PK_Countries PRIMARY KEY(ID))";
                SqlCommand createTableCountriesCommand =
                    new SqlCommand(createTableCountriesCommandParam, connection);
                createTableCountriesCommand.ExecuteNonQuery();

                string createTableTownsCommandParam = "CREATE TABLE Towns ( " +
                                                       "ID int IDENTITY, " +
                                                       "TownName nvarchar(100) NOT NULL, " +
                                                       "CountryID nvarchar(100), " +
                                                       "CONSTRAINT PK_Towns PRIMARY KEY(ID) " +
                                                       "CONSTRAINT FK_Towns_Countries " + 
                                                       "FOREIGN KEY(CountryID) " +
                                                       "REFERENCES Countries(ID))";
                SqlCommand createTableTownsCommand = 
                    new SqlCommand(createTableTownsCommandParam, connection);
                createTableTownsCommand.ExecuteNonQuery();

                string createTableMinionsCommandParam = "CREATE TABLE Minions ( " +
                                                       "ID int IDENTITY, " +
                                                       "Name nvarchar(100) NOT NULL, " +
                                                       "Age int, " +
                                                       "TownID int, " +
                                                       "CONSTRAINT PK_Minions PRIMARY KEY(ID) " +
                                                       "CONSTRAINT FK_Minions_Towns " +
                                                       "FOREIGN KEY(TownsID) " +
                                                       "REFERENCES Towns(ID))";
                SqlCommand createTableMinionsCommand =
                    new SqlCommand(createTableMinionsCommandParam, connection);
                createTableMinionsCommand.ExecuteNonQuery();

                string createTableVillainsCommandParam = "CREATE TABLE Villains ( " +
                                                         "ID int IDENTITY, " +
                                                         "Name nvarchar(100) NOT NULL, " +
                                                         "EvilFactor varchar(10) " +
                                                         "CONSTRAINT PK_Viilains PRIMARY KEY(ID))";
                SqlCommand createTableVillainsCommand =
                    new SqlCommand(createTableVillainsCommandParam, connection);
                createTableVillainsCommand.ExecuteNonQuery();

                string createTableVillainsMinionsCommandParam = 
                                               "CREATE TABLE VillainsMinions ( " +
                                               "MinionID int, " +
                                               "VillainID int " +
                                               "CONSTRAINT PK_VillainsMinions PRIMARY KEY(MinionID, VillainID) " +
                                               "CONSTRAINT FK_VillainsMinions_Villains " +
                                               "FOREIGN KEY(VillainID) " +
                                               "REFERENCES Villains(ID) " +
                                               "CONSTRAINT FK_VillainsMinions_Minions " +
                                               "FOREIGN KEY(MinionID) " +
                                               "REFERENCES Minions(ID))";
                SqlCommand createTableVillainsMinionsCommand =
                    new SqlCommand(createTableVillainsMinionsCommandParam, connection);
                createTableVillainsMinionsCommand.ExecuteNonQuery();
            }
        }
    }
}
