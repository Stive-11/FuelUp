﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuelUp.Models.ApiModels
{
    public class Requests
    {
        public class PathStrings
        {
            public string startPoint { set; get; }
            public string finishPoint { set; get; }
        }

        public class PathCoordinats
        {
            public Сoordinates startPoint { set; get; }
            public Сoordinates finishPoint { set; get; }
        }
            
    }
}