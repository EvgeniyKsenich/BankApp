using DA.Business.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DA.Business.Repositories;
using BA.Database.DataContext;

namespace BA.Database.Repositories
{
    public class UserInfoRepositories: IUser<UserInfo>
    {
        private DataContext.DataContext db;
        public UserInfoRepositories(DataContext.DataContext _context)
        {
            db = _context;
        }

        public UserInfo GetUser(string UserName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserInfo> GetList()
        {
            //tmp//
            var List = db.Useers.ToList<UserInfo>();
            //List.Add(new UserInfo() { Id = 0, Name = "Name", Surname = "Surnm", DateOfBirth = DateTime.Now,UserName ="user1111" });
            //List.Add(new UserInfo() { Id = 1, Name = "Name1", Surname = "Surnm1", DateOfBirth = DateTime.Now,UserName ="user1112" });
            return List;
            //throw new NotImplementedException();
        }

        public void Add(UserInfo User)
        {
            throw new NotImplementedException();
        }
    }
}
