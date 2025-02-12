﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace GenericProxyCache
{
    /*Design a JCDecauxItem class with a constructor which makes a request to the
     * JCDecaux API to create a JCDecauxItem object. The structure of this class 
     * depends on the targetted API's endpoint (and so on the retrieved data).)*/
    [DataContract]
    public class JCDecauxItem
    {
        [DataMember]
        string query { get; set; }
        [DataMember]
        public string response { get; set; }


        public JCDecauxItem(string query)
        {
            this.query = query;
            response = JCDecauxAPICall(query).Result;

        }

        [OperationContract]
        static async Task<string> JCDecauxAPICall(string query)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(query);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        /*public JCDecauxItem(int itemNumber)
        {

            var url = $"https://api.jcdecaux.com/vls/v3/stations/{itemNumber}";

            using (var httpClient = new HttpClient())
            {
                // Make a GET request to the API endpoint.
                var response = httpClient.GetAsync(url).Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    // If the request is successful, parse the
                    // response JSON data and populate the
                    // object properties with the retrieved values.
                    var jsonData = response.Content.ReadAsStringAsync().Result;
                    dynamic parsedData = JsonSerializer.Deserialize<Task>(jsonData);
                    Name = parsedData.name;
                    Number = parsedData.number;
                    Address = parsedData.address;
                    Latitude = parsedData.position.lat;
                    Longitude = parsedData.position.lng;
                    BikeStands = parsedData.bike_stands;
                    AvailableBikeStands = parsedData.available_bike_stands;
                    AvailableBikes = parsedData.available_bikes;
                }
            }
        }*/
    }
    [DataContract]
    public class JCDContract
    {
        [DataMember]
        public string name { get; set; }
    }

    [DataContract]
    public class JCDStation
    {
        [DataMember]
        public int number { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string contractName { get; set; }
        [DataMember]
        public Position position { get; set; }
        [DataMember]
        public Totalstands totalStands { get; set; }
    }


    [DataContract]
    public class Totalstands
    {
        [DataMember]
        public Availabilities availabilities { get; set; }
    }

    [DataContract]
    public class Availabilities
    {
        [DataMember]
        public int bikes { get; set; }
        [DataMember]
        public int stands { get; set; }
    }


    [DataContract]
    public class Position
    {
        [DataMember]
        public double latitude { get; set; }
        [DataMember]
        public double longitude { get; set; }
    }


}
