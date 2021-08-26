using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class ApplicationBase
    {
        private readonly IConfiguration _configuration;
        public ApplicationBase(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetCadenaConexion()
        {
            string respuesta = string.Empty;

            respuesta = _configuration.GetSection("MySqlDB").Value;

            return respuesta;
        }
    }
}
