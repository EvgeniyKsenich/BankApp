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

        public void CreateTransaction(double amount, Account Initiator, Account Receiver, int type)
        {
            var Transaction_ = new BA.Database.Enteties.Transaction()
            {
                Summa = amount,
                Date = DateTime.Now,
                Type = type,
                AccountRecipient = Receiver,
                AccountInitiator = Initiator
            };
            _Unit.Transaction.Add(Transaction_);
        }

        public bool Deposit(string UserName, double amount)
        {
            var Account = _Unit.Accounts.Get(UserName);

            if (amount < 0)
                return false;

            Account.Balance += amount;

            CreateTransaction(amount, Account, Account, 1);

            _Unit.Save();
            return true;
        }

        public bool Withdraw(string UserName, double amount)
        {
            var Account = _Unit.Accounts.Get(UserName);
            if (Account.Balance < amount || amount < 0)
                return false;

            Account.Balance -= amount;

            CreateTransaction(amount, Account, Account, 2);

            _Unit.Save();
            return true;
        }

        public bool Transfer(double amount, string UserInitiatorName, string UserReceiverName)
        {
            var UserInitiator = _Unit.Accounts.Get(UserInitiatorName);
            if (UserInitiator == null)
                return false;
            if (UserInitiator.Balance < amount || amount < 0)
                return false;

            var UserReceiver = _Unit.Accounts.Get(UserReceiverName);
            if (UserReceiver == null)
                return false;

            CreateTransaction(amount, UserInitiator, UserReceiver, 3);

            UserInitiator.Balance -= amount;
            UserReceiver.Balance += amount;
            _Unit.Save();

            return true;
        }
    }
}
