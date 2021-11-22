using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ProductosInventario.Util
{
    public class Connection
    {
        private static string cName = "Data Source=JUANITA\\SQLEXPRESS; Initial Catalog=dbproductos;Trusted_Connection=True; ";

        public static string CName
        {
            get => cName;
        }
    }
}
