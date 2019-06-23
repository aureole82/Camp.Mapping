using Microsoft.AspNetCore.Identity;

namespace Camp.Mapping.Data.Models
{
    public class UserModel : IdentityUser<int>
    {
        [PersonalData]
        public string Name { get; set; }
    }
}