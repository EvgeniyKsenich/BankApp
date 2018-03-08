using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BA.Database.DataContext;
using BA.Database.Enteties;
using BA.Database.Сommon.Repositories;

namespace BA.Database.Repositories
{
    public class UserRepositories : IRepositories<User>
    {
        private DataContext.DataContext db;
        public UserRepositories(DataContext.DataContext _context)
        {
            db = _context;
        }

        public User Get(string UserName)
        {
            var User = db.Useers.Where(c => c.UserName == UserName).FirstOrDefault();
            return User;
        }

        public IEnumerable<User> GetList()
        {
            var List = db.Useers.ToList<User>();
            return List;
        }

        public void Add(User User)
        {
            db.Useers.Add(User);
        }
    }
}
