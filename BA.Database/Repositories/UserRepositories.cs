using DA.Business.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DA.Business.Repositories;
using BA.Database.DataContext;
using BA.Database.Modeles;

namespace BA.Database.Repositories
{
    public class UserRepositories: IUser<User>
    {
        private DataContext.DataContext db;
        public UserRepositories(DataContext.DataContext _context)
        {
            db = _context;
        }

        public User GetUser(string UserName)
        {
            var User = db.Useers.Where(c => c.UserName == UserName).SingleOrDefault();
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
