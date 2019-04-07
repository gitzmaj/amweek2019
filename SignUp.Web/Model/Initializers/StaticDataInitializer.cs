using SignUp.Model.Entities;
using System.Data.Entity;

namespace SignUp.Model.Initializers
{
    public class StaticDataInitializer : CreateDatabaseIfNotExists<SignUpContext>
    {
        protected override void Seed(SignUpContext context)
        {
        }

        private void AddCountry(SignUpContext context, string code, string name)
        {
            context.Countries.Add(new Country
            {
                CountryCode = code,
                CountryName = name
            });
        }

        private void AddRole(SignUpContext context, string code, string name)
        {
            context.Roles.Add(new Role
            {
                RoleCode = code,
                RoleName = name
            });
        }
    }
}
