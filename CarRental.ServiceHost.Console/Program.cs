using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Timers;
using System.Transactions;
using CarRental.Business.Bootstrapper;
using CarRental.Business.Entities;
using CarRental.Business.Managers;
using Core.Common.Core;
using SM = System.ServiceModel;

namespace CarRental.ServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericPrincipal principal = new GenericPrincipal(
                new GenericIdentity("Taras"), new string[] { "CarRentalAdmin" });
            Thread.CurrentPrincipal = principal;

            ObjectBase.Container = MEFLoader.Init();

            Console.WriteLine("Starting up services...");
            Console.WriteLine("");

            SM.ServiceHost hostInventoryManager = new SM.ServiceHost(typeof(InventoryManager));
            SM.ServiceHost hostRentalManager = new SM.ServiceHost(typeof(RentalManager));
            SM.ServiceHost hostAccountManager = new SM.ServiceHost(typeof(AccountManager));

            StartService(hostInventoryManager, "InventoryManager");
            StartService(hostRentalManager, "RentalManager");
            StartService(hostAccountManager, "AccountManager");

            System.Timers.Timer timer = new System.Timers.Timer(10000);
            timer.Elapsed += OnTimerElapsed;
            timer.Start();

            Console.WriteLine("Reservation monitor started.");

            Console.WriteLine("");
            Console.WriteLine("Press [Enter] to exit.");
            Console.ReadLine();

            timer.Stop();

            Console.WriteLine("Reservation monitor stopped.");

            StopService(hostInventoryManager, "InventoryManager");
            StopService(hostRentalManager, "RentalManager");
            StopService(hostAccountManager, "AccountManager");
        }

        static void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Looking for dead reservations at {0}.", DateTime.Now.ToString());

            RentalManager rentalManager = new RentalManager();

            Reservation[] reservations = rentalManager.GetDeadReservations();
            if (reservations != null)
            {
                foreach (Reservation reservation in reservations)
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        try
                        {
                            rentalManager.CancelReservation(reservation.ReservationId);
                            Console.WriteLine("Canceling reservation '{0}'.", reservation.ReservationId);

                            scope.Complete();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("There was an exception when attempting to cancel reservation '{0}'.", reservation.ReservationId);
                        }
                    }
                }
            }
        }

        static void StartService(SM.ServiceHost host, string serviceDescription)
        {
            host.Open();
            Console.WriteLine("Service {0} started.", serviceDescription);

            foreach (var endpoint in host.Description.Endpoints)
            {
                Console.WriteLine(string.Format("Listening on endpoint:"));
                Console.WriteLine(string.Format("Address: {0}", endpoint.Address.Uri.ToString()));
                Console.WriteLine(string.Format("Binding: {0}", endpoint.Binding.Name));
                Console.WriteLine(string.Format("Contract: {0}", endpoint.Contract.ConfigurationName));
            }

            Console.WriteLine();
        }

        static void StopService(SM.ServiceHost host, string serviceDescription)
        {
            host.Close();
            Console.WriteLine("Service {0} stopped.", serviceDescription);
        }
    }
}
