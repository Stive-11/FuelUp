using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidFuelUp.Models;

namespace AndroidFuelUp.Core
{
   
        public static class StationDecoder
        {
            public static long GetServicesCod(List<string> serviceNames)
            {
                long? resultCod = 0;
                foreach (var name in serviceNames)
                {
                    resultCod += InfoStore.ServiceTypesInfo.FirstOrDefault(x => x.Service.Equals(name)).Code;
                }

                return resultCod ?? 0;
            }
        }
    
}