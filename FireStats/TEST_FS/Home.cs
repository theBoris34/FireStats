﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST_FS
{
    public class Home
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<People> Peoples { get; set; }

    }
}
