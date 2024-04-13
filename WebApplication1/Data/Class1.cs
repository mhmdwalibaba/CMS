using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Class1
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class TestContext : DbContext
    {
        public DbSet<Class1> class1s { get; set; }
    }
}
