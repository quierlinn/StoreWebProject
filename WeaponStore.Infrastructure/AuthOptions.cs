using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WeaponStore.Infrastructure;
    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer";
        public const string AUDIENCE = "MyAuthClient";

        private const string KEY =
            "vasyaGayvasyaGayvasyaGayvasyaGayvasyaGayvasyaGayvasyaGayvasyaGayvasyaGayvasyaGayvasyaGayvasyaGayvasyaGay";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
    }