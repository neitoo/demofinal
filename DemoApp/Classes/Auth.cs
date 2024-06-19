using DemoApp.Data;
using System.Collections.Generic;
using System.Linq;

namespace DemoApp.Classes
{
    public class Auth
    {
        private IEnumerable<Users> users;
        public Users user { get; set; }

        public Auth(IEnumerable<Users> users) 
        { 
            this.users = users;
        }
        public bool SignIn(string login, string password)
        {
            user = users.Where(us => us.login == login && us.password == password).FirstOrDefault();
            return user != null;
        }
    }
}
