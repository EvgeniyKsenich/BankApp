using DA.Business.Modeles;

namespace DA.Business.Repositories
{
    public interface ITransactionServisesRepositoryes
    {
        bool Deposit(string UserName, double amount);
        bool Withdraw(string UserName, double amount);
        bool Transfer(double amount, string UserInitiatorName, string UserReceiverName);
    }
}
