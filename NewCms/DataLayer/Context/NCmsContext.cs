﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Context
{
    public class NCmsContext:DbContext
    {
        public DbSet<PageGroup> pageGroups { get; set; }
        public DbSet<Page> pages { get; set; }

        public DbSet<PageComment> pageComments { get; set; }
    }

}
