using SignUp.Model.Entities;

namespace SignUp.Web.ProspectSave
{
    interface IProspectSaveHandler
    {
        void SaveProspect(Prospect prospect);
    }
}
