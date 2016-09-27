using FuelUp.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuelUp.Services
{
    public interface IGetInfo
    {
        IEnumerable<MainInfoAzs> GetMainInfo();
        IEnumerable<MainInfoAzs> GetFilteredInfo(long filters);
    }
}
