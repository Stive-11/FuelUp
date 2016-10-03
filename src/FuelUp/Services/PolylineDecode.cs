using FuelUp.Models.ApiModels;
using System;
using System.Collections.Generic;

namespace FuelUp.Services
{
    public static class PolylineDecode
    {
        public static List<Сoordinates> DecodePolylinePoints(string encodedPoints)
        {
            if (string.IsNullOrEmpty(encodedPoints)) return null;
            var poly = new List<Сoordinates>();
            var polylinechars = encodedPoints.ToCharArray();
            var index = 0;

            var currentLat = 0;
            var currentLng = 0;

            try
            {
                while (index < polylinechars.Length)
                {
                    // calculate next latitude
                    var sum = 0;
                    var shifter = 0;
                    int next5Bits;
                    do
                    {
                        next5Bits = polylinechars[index++] - 63;
                        sum |= (next5Bits & 31) << shifter;
                        shifter += 5;
                    } while (next5Bits >= 32 && index < polylinechars.Length);

                    if (index >= polylinechars.Length)
                        break;

                    currentLat += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);

                    //calculate next longitude
                    sum = 0;
                    shifter = 0;
                    do
                    {
                        next5Bits = polylinechars[index++] - 63;
                        sum |= (next5Bits & 31) << shifter;
                        shifter += 5;
                    } while (next5Bits >= 32 && index < polylinechars.Length);

                    if (index >= polylinechars.Length && next5Bits >= 32)
                        break;

                    currentLng += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);
                    var p = new Сoordinates
                    {
                        latitude = Convert.ToDouble(currentLat)/100000.0,
                        longitude = Convert.ToDouble(currentLng)/100000.0
                    };
                    poly.Add(p);
                }
            }
            catch (Exception)
            {
                // logo it
            }
            return poly;
        }
    }
}