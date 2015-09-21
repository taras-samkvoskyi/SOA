using System;
using System.ServiceModel;
using CarRental.Business.Contracts;
using CarRental.Business.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarRental.ServiceHost.Tests
{
    [TestClass]
    public class ServiceAccessTests
    {
        [TestMethod]
        public void test_inventory_manager_as_service()
        {
            ChannelFactory<IInventoryService> channelFactory =
                new ChannelFactory<IInventoryService>("");

            IInventoryService proxy = channelFactory.CreateChannel();

            (proxy as ICommunicationObject).Open();

            channelFactory.Close();
        }

        [TestMethod]
        public void test_rental_manager_as_service()
        {
            ChannelFactory<IRentalService> channelFactory =
                new ChannelFactory<IRentalService>("");

            IRentalService proxy = channelFactory.CreateChannel();

            (proxy as ICommunicationObject).Open();

            channelFactory.Close();
        }

        [TestMethod]
        public void test_account_manager_as_service()
        {
            ChannelFactory<IAccountService> channelFactory =
                new ChannelFactory<IAccountService>("");

            IAccountService proxy = channelFactory.CreateChannel();

            (proxy as ICommunicationObject).Open();

            channelFactory.Close();
        }
    }
}
