

namespace DataAccess
{
    public interface IAccountDal
    {
        string[] GetRolesForUser(string username);
       
    }
}