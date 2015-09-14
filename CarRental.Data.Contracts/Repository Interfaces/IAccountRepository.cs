using CarRental.Business.Entities;
using Core.Common.Contracts;

namespace CarRental.Data.Contracts.Repository_Interfaces
{
    public interface IAccountRepository : IDataRepository<Account>
    {
        Account GetByLogin(string login);
    }
}
