﻿using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class Utils
    {
        public bool SameCity(Location origin, Location destination)
        {
            return origin.Equals(destination);
        }

        public GeoCoordinate posToCoor(Position p)
        {
            return new GeoCoordinate(p.latitude, p.longitude);
        }
        public Itinerary calculateItinenary(List<Rootobject> route)
        {
            route.Select(o => o.metadata.query.profile);
            Itinerary itinerary = new Itinerary();
            Segment segment = new Segment();
            foreach (Rootobject obj in route)
            {
                Segment seg = obj.features.First().properties.segments.First();
                string profile = obj.metadata.query.profile;
                itinerary.directions.Add(new Direction(seg, profile));
                itinerary.distance += obj.features.First().properties.summary.distance;
                itinerary.duration += obj.features.First().properties.summary.duration;
            }

            return itinerary;
        }
    }
}
