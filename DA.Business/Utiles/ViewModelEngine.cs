using BA.Business.ViewModel;
using BA.Database.Enteties;
using BA.Database.UnitOfWork;
using DA.Business.Repositories;
using DA.Business.ViewModel;

namespace DA.Business.Utiles
{
    public class ViewModelEngine : IViewModelEngine
    {
        private IUnitOfWork _Unit;

        public ViewModelEngine(IUnitOfWork Unit)
        {
            _Unit = Unit;
        }

        public UserView GetUserViewModel(User User)
        {
            var Account = _Unit.Accounts.Get(User.UserName);

            var UserView = new UserView()
            {
                Id = User.Id,
                Name = User.Name,
                Surname = User.Surname,
                UserName = User.UserName,
                Balance = Account.Balance
            };

            return UserView;
        }

        public TransactionView GetTransactionViewModel(Transaction Transaction)
        {
            var TransactionView = new TransactionView()
            {
                Id = Transaction.Id,
                Date = Transaction.Date,
                Summa = Transaction.Summa,
                Type = Transaction.Type,
                AccountInfoInitiator = Transaction.AccountInitiator.User.UserName,
                AccountInfoRecipient = Transaction.AccountRecipient.User.UserName
            };

            return TransactionView;
        }
    }
}
