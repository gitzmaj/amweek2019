using amweek.Entities;
using System.Linq;

namespace SignUp.Web.ProspectSave
{
    public class SynchronousProspectSaveHandler : IProspectSaveHandler
    {
        public void SaveProspect(Prospect prospect)
        {
            using (var context = new Model.SignUpContext())
            {
                //reload child objects:
                prospect.Country = context.Countries.Single(x => x.CountryCode == prospect.Country.CountryCode);
                prospect.Role = context.Roles.Single(x => x.RoleCode == prospect.Role.RoleCode);

                context.Prospects.Add(prospect);
                context.SaveChanges();
            }
        }
    }
}