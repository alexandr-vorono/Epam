﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Concordance
{
    class Reader
    {
        public string[] Read()
        {
            string[] mass = File.ReadAllLines("test.txt", Encoding.Default);
            return mass;
        }
    }
}