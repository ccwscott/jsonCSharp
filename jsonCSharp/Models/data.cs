using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace jsonCSharp.Models
{
    public class Location
    {
        public string locationName;
        public string airPrice;
        public string powerPrice;
        public string waterPrice;
        public string foodPrice;
        public string fuelPrice;
        public string weaponPrice;
        public string metalPrice;
        public string refugees;
        public string research;
        public int distance;
        public List<string> nearbyLocations;
    }

    public class ServerData
    {
        static public Location getCurrentLocationData()
        {
            Location currentLocationData = new Location();

            //open connection to server
            SqlConnection sqlConnection = new SqlConnection("Server=tcp:newgaia.database.windows.net,1433;Database=Newgaia;User ID=anticlockwisegames@newgaia;Password=K1i2l3l4A5l6l7H8u9m0a1n2s3;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;");
            sqlConnection.Open();

            //get prices
            string sqlString = "SELECT PT_Items.Name as itemName, PT_Sales.BuyPrice FROM PT_Locations INNER JOIN PT_PilotData ON PT_PilotData.Location = PT_Locations.ID INNER JOIN PT_Sales ON PT_Sales.Location =  PT_Locations.ID INNER JOIN PT_Items on PT_Sales.Item = PT_Items.ID";
            SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);
            SqlDataReader itemPrices = sqlCommand.ExecuteReader();
            while(itemPrices.Read())
            {
                if ((string) itemPrices["itemName"] == "Air")
                    currentLocationData.airPrice = itemPrices["BuyPrice"].ToString();
                else if ((string)itemPrices["itemName"] == "Power")
                    currentLocationData.powerPrice = itemPrices["BuyPrice"].ToString();
                else if ((string)itemPrices["itemName"] == "Water")
                    currentLocationData.waterPrice = itemPrices["BuyPrice"].ToString();
                else if ((string)itemPrices["itemName"] == "Food")
                    currentLocationData.foodPrice = itemPrices["BuyPrice"].ToString();
                else if ((string)itemPrices["itemName"] == "Fuel")
                    currentLocationData.fuelPrice = itemPrices["BuyPrice"].ToString();
                else if ((string)itemPrices["itemName"] == "Weapons")
                    currentLocationData.weaponPrice = itemPrices["BuyPrice"].ToString();
                else if ((string)itemPrices["itemName"] == "Metal")
                    currentLocationData.metalPrice = itemPrices["BuyPrice"].ToString();
                else if ((string)itemPrices["itemName"] == "Refugees")
                    currentLocationData.refugees = itemPrices["BuyPrice"].ToString();
                else if ((string)itemPrices["itemName"] == "Research")
                    currentLocationData.research = itemPrices["BuyPrice"].ToString();
            }

            itemPrices.Close();

            currentLocationData.nearbyLocations = new List<string>();

            //get nearby locations
            sqlString = "SELECT PT_Locations.Name as Name FROM PT_Locations INNER JOIN PT_PilotData on PT_Locations.ID != PT_PilotData.Location";
            sqlCommand = new SqlCommand(sqlString, sqlConnection);
            SqlDataReader nearbyLocations = sqlCommand.ExecuteReader();

            while (nearbyLocations.Read())
            {
                currentLocationData.nearbyLocations.Add((string) nearbyLocations["Name"]);
            }

            return currentLocationData;
        }
    }

    public class JsonData
    {
        

        private string currentLocation;

        public string getCurrentLocation()
        {
            return currentLocation;
        }

        public enum locationChangeResult { arrive, noPower, noOxygen, noWater, noFood }

        //STUB: UPDATE LATER
        public Location intializeFirstLocation()
        {
            return new Location();
        }

        //STUB: UPDATE LATER
        public locationChangeResult changeLocation()
        {
            return locationChangeResult.arrive;
        }

        
    }
}