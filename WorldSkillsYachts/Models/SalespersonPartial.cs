﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSkillsYachts.Models
{
    public partial class Salesperson
    {
        public override string ToString()
        {
            return FirstName + " " + FamilyName;
        }
    }
}
