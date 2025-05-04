using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Auth
{
    public class AppJwtSettings
    {
        public string SecretKey { get; set; } = "MeuSuperSegredo"!;
        public int Expiration { get; set; } = 24;//horas
        public string Issuer { get; set; } = "E-Commerce.Api";
        public string Audience { get; set; } = "Api";
    }
}
