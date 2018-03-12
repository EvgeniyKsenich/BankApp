using AutoMapper;
using BA.Database.UnitOfWork;
using System.Collections.Generic;
using BA.Database.Enteties;
using DA.Business.Repositories;
using DA.Business.Modeles;
using BA.Business.ViewModel;
using DA.Business.ViewModel;
using BA.Business.Repositories;
using Microsoft.Extensions.Options;
using BA.Business.Modeles;

namespace DA.Business.Servises
{
    public class UserServises : IUserServises
    {
        private IMapper Mapper_;
        private IUnitOfWork Unit_;
        private IViewModelEngine ViewModelEngine_;
        private IPasswordEngine PasswordEngine_;
        private IOptions<Identity> Identity_;

        public UserServises(IPasswordEngine PasswordEngine, IUnitOfWork Unit, IMapper mapper, IViewModelEngine ViewModelEngine, IOptions<Identity> Identity)
        {
            Mapper_ = mapper;
            Unit_ = Unit;
            ViewModelEngine_ = ViewModelEngine;
            PasswordEngine_ = PasswordEngine;
            Identity_ = Identity;
        }

        public UserView GetUserViewModel(string UserName)
        {
            var User = Unit_.Users.Get(UserName);
            return ViewModelEngine_.GetUserViewModel(User);
        }

        public UserView GetUserViewModel(User User)
        {
            return ViewModelEngine_.GetUserViewModel(User);
        }

        public IEnumerable<UserView> GetList()
        {
            var UserList = Unit_.Users.GetList();
            var UserViewList = new List<UserView>();
            foreach(var user in UserList)
            {
                UserViewList.Add(GetUserViewModel(user));
            }
            return UserViewList;
        }

        public IEnumerable<UserView> GetSafeList(string CurrentUserName)
        {
            var UserList = Unit_.Users.GetList();
            var UserViewList = new List<UserView>();
            foreach (var user in UserList)
            {
                if (user.UserName != CurrentUserName)
                {
                    var Model = GetUserViewModel(user);
                    Model.Balance = 0;
                    UserViewList.Add(Model);
                }
            }
            return UserViewList;
        }

        public bool Register(UserModel User)
        {
            if (User != null)
            {
                var EntetiUser = Mapper_.Map<User>(User);
                EntetiUser.Password = PasswordEngine_.GetHash( string.Concat(EntetiUser.Password, Identity_.Value.Salt) );
                EntetiUser.Accounts.Add(new Account()
                {
                    Balance = 0
                });
                Unit_.Users.Add(EntetiUser);
                Unit_.Save();

                return true;
            }

            return false;
        }

        public IEnumerable<TransactionView> GetTransactionList(string Username)
        {
            var Transactions = Unit_.Transaction.GetList(Username);
            var List = new List<TransactionView>();
            foreach (var item in Transactions)
            {
                List.Add(ViewModelEngine_.GetTransactionViewModel(item));
            }
            return List;
        }

    }
}
