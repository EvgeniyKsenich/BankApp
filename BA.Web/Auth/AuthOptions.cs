using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BA.Web.Auth
{
    public class AuthOptions
    {
        public const string ISSUER = "BankApp"; // Publisher
        public const string AUDIENCE = "http://localhost:62733/"; // Tocken site
        const string KEY = "gaCn3EQa8ikIhNEfJKY248oBoiMKttXt";   // Key
        public const int LIFETIME = 1440; // Life time seconds

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
