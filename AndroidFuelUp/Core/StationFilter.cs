using AndroidFuelUp.Models;
using System.Collections.Generic;

namespace AndroidFuelUp.Core
{
    public static class StationFilter
    {
        public static  List<StationForMap> StationsOnMapWithFilter { set; get; }

        static StationFilter()
        {
            StationsOnMapWithFilter=new List<StationForMap>();
        }

        public static void GetStationsForMap(long cod)
        {
            foreach (StationForMap tempStationForMap in InfoStore.StationsOnMap)
            {
                if (IsStationHasServices(cod, tempStationForMap))
                {
                    StationsOnMapWithFilter.Add(tempStationForMap);
                }
            }
        }

        public static bool IsStationHasServices(long cod, StationForMap station)
        {
            var services = station.codServices;
            if (cod == 0) return true;
            if (services == 0 || services==null) return false;
            var array1 = Parse(cod);

            var array2 = Parse((long)services);
            var countEquals = 0;
            var countEqualsMax = array1.Count > array2.Count ? array2.Count : array1.Count;
            countEquals = array1.Count < array2.Count ? GetCountEquals(array1, array2) : GetCountEquals(array2, array1);
            return (countEquals == countEqualsMax);
        }

        public static int GetCountEquals(List<long> array1, List<long> array2)
        {
            var equalsCount = 0;
            for (var i = array1.Count - 1; i >= 0; i--)
            {
                if (array2.Contains(array1[i]) != false)
                    equalsCount++;
            }
            return equalsCount;
        }

        public static List<long> Parse(long cod)
        {
            var codArray = new List<long>();
            var currentCod = 134217728;
            for (var i = 28; i > 0; i--)
            {
                if (cod < currentCod) continue;
                codArray.Add(i);
                cod -= currentCod;
                currentCod = currentCod / 2;
            }
            return codArray;
        }
    }
}