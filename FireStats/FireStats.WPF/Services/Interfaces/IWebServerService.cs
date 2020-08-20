﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireStats.WPF.Services.Interfaces
{
    internal interface IWebServerService
    {
        bool Enable { get; set; }
        void Start();
        void Stop();
    }
}
