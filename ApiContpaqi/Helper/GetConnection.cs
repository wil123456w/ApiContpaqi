using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiContpaqi.Helper
{
    /// <summary>
    /// Clase para generar conexión con el archivo secreto de usuario
    /// </summary>
    public class GetConnection
    {
        public static IConfiguration Configuration { get; set; }

        public GetConnection(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string GetConfigurationString
        {
            get
            {
                string secretConn = Configuration["ConnectionDB"];
                return secretConn;
            }
        }
    }
}
