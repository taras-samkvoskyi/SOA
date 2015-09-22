using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using CarRental.Client.Contracts;
using CarRental.Client.Entities;
using Core.Common.ServiceModel;

namespace CarRental.Client.Proxies
{
    [Export(typeof(IAccountService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AccountClient : UserClientBase<IAccountService>, IAccountService
    {
        public Account GetCustomerAccountInfo(string loginEmail)
        {
            return Channel.GetCustomerAccountInfo(loginEmail);
        }

        public void UpdateCustomerAccountInfo(Account account)
        {
            Channel.UpdateCustomerAccountInfo(account);
        }

        #region Async operations

        public Task<Account> GetCustomerAccountInfoAsync(string loginEmail)
        {
            return Channel.GetCustomerAccountInfoAsync(loginEmail);
        }

        public Task UpdateCustomerAccountInfoAsync(Account account)
        {
            return Channel.UpdateCustomerAccountInfoAsync(account);
        }

        #endregion
    }
}
