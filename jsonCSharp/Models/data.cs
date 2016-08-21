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
    }

    public class ServerData
    {
        public Location getCurrentLocationData()
        {
            SqlConnection sqlConnection = new SqlConnection("Server=tcp:newgaia.database.windows.net,1433;Database=Newgaia;User ID=anticlockwisegames@newgaia;Password=K1i2l3l4A5l6l7H8u9m0a1n2s3;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;");
            sqlConnection.Open();
            string sqlString = "((SELECT * FROM PT_Location INNER JOIN PT_PilotData ON PT_PilotData.Location = PT_Location.ID) INNER JOIN PT_Sales ON PT_Sales.Location =  PT_Location.ID) INNER_JOIN PT_Items on PT_Sales.Item = PT_Items.ID)";
            SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);
            Location currentLocationData = new Location();
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