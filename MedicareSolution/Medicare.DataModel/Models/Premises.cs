﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
    public partial class Premises
    {
        public Premises()
        {

        }
        #region Properties
        public long PremisesId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        #endregion
               
    }
}