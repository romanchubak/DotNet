﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Interfaces
{
    interface INameAndCopy
    {
        string Name { get; set; }
        object DeepCopy();
    }
}
