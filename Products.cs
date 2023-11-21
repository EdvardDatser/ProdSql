using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdSql
{
    public class Products
    {
        public int Id{ get; set; }
        public string ProductName { get; set; }
        public int Quanty { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }

        public IEnumerable<Kategooria> Kategooriad { get; set; }

    }

    public class Kategooria
    {
        public int Id { get; set; }
        public string Kategooria_Name { get; set; }
        public string Info { get; set; }

    }
}
