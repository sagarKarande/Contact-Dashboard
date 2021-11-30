using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcApplication2.Models
{
    public interface IAuthentication
    {
        bool Login(UserModel user);
        bool register(User user);

        bool CheckUserExist(string userName);
    }
}
