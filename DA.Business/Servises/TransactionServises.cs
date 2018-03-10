using AutoMapper;
using BA.Database.UnitOfWork;
using BA.Database.Сommon.Repositories;
using System;
using BA.Database.Enteties;
using DA.Business.Repositories;

namespace DA.Business.Servises
{
    public class TransactionServises: ITransactionServisesRepositoryes
    {
        private IMapper _Mapper;
        private IUnitOfWork _Unit;

        public TransactionServises(IUnitOfWork Unit, IMapper mapper)
        {
            _Mapper = mapper;
            _Unit = Unit;
        }

        public bool Deposit(string UserName, double amount)
        {
            var Account = _Unit.Accounts.Get(UserName);
            Account.Balance += amount;

            var Transaction_ = new BA.Database.Enteties.Transaction()
            {
                Summa = amount,
                Date = DateTime.Now,
                Type = 1,
                AccountRecipient = Account,
                AccountInitiator = Account
            };
            _Unit.Transaction.Add(Transaction_);

            _Unit.Save();
            return true;
        }

        public bool Withdraw(string UserName, double amount)
        {
            var Account = _Unit.Accounts.Get(UserName);
            if (Account.Balance < amount)
                return false;

            Account.Balance -= amount;

            var Transaction_ = new BA.Database.Enteties.Transaction()
            {
                Summa = amount,
                Date = DateTime.Now,
                Type = 2,
                AccountInitiator = Account,
                AccountRecipient = Account
            };
            _Unit.Transaction.Add(Transaction_);

            _Unit.Save();
            return true;
        }

        public bool Transfer(double amount, string UserInitiatorName, string UserReceiverName)
        {
            var UserInitiator = _Unit.Accounts.Get(UserInitiatorName);
            if (UserInitiator == null)
                return false;
            if (UserInitiator.Balance < amount)
                return false;

            var UserReceiver = _Unit.Accounts.Get(UserReceiverName);
            if (UserReceiver == null)
                return false;


            var Transaction_ = new BA.Database.Enteties.Transaction()
            {
                Summa = amount,
                Date = DateTime.Now,
                Type = 3,
                AccountInitiator = UserInitiator,
                AccountRecipient = UserReceiver
            };
            _Unit.Transaction.Add(Transaction_);

            UserInitiator.Balance -= amount;
            UserReceiver.Balance += amount;
            _Unit.Save();

            return true;
        }
    }
}
