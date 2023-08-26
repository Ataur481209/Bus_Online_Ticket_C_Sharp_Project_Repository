
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using work_01_Repository.Repositories;
using work_01_Repository.Models;

namespace work_01_Repository
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayOption();
            Console.ReadKey();
        }
        public static void DisplayOption()
        {
            Console.WriteLine("1. Show All Bus");
            Console.WriteLine("2. Insert Bus");
            Console.WriteLine("3. Update Bus");
            Console.WriteLine("4. Delete Bus");

            var index = int.Parse(Console.ReadLine());
            Show(index);

        }
        public static void Show(int index)
        {
            BusRepo busRepo = new BusRepo();
            if (index == 1)
            {
                var busList = busRepo.GetAll();
                if (busList.Count() == 0)
                {
                    Console.WriteLine("======================");
                    Console.WriteLine("No data found");
                    Console.WriteLine("======================");
                    DisplayOption();
                }
                else
                {
                    foreach (var item in busRepo.GetAll())
                    {
                        Console.WriteLine($"Bus Id: {item.BusId}, Name: {item.BusName}, Bus Seat Number: {item.BusSeatNumber}");
                    }
                    Console.WriteLine("===============================");
                    DisplayOption();
                }
            }
            else if (index == 2)
            {
                Console.WriteLine("============================");
                Console.Write("Bus Name :");
                string busName = Console.ReadLine();

                Console.Write("Seat Number :");
                int seatNumber = Convert.ToInt32(Console.ReadLine());

                int maxId = busRepo.GetAll().Any() ? busRepo.GetAll().Max(x => x.BusId) : 0;

                Bus bus = new Bus
                {
                    BusId = maxId + 1,
                    BusName = busName,
                    BusSeatNumber = seatNumber
                    
                };
                busRepo.Insert(bus);
                Console.WriteLine("Data Inserted successfully!!!");
                Console.WriteLine("=================================");
                DisplayOption();
            }
            else if (index == 3)
            {
                Console.WriteLine("==================================");
                Console.Write("Enter Bus Id to Update: ");
                int id = int.Parse(Console.ReadLine());
                var _bus = busRepo.GetById(id);

                if (_bus == null)
                {
                    Console.WriteLine("======================");
                    Console.WriteLine("Bus Id is invalid!!!");
                    Console.WriteLine("======================");
                    DisplayOption();
                }
                else
                {
                    Console.WriteLine($"Update Info for Bus Id : {id}");
                    Console.WriteLine("===================================");
                    Console.Write("Bus Name :");
                    string busName = Console.ReadLine();

                    Console.Write("Seat Number :");
                    int seatNumber = Convert.ToInt32(Console.ReadLine());
                    Bus bus = new Bus
                    {
                        BusId = id,
                        BusName = busName,
                        BusSeatNumber = seatNumber

                    };
                    busRepo.Update(bus);
                    Console.WriteLine("Data Updated Successfully!!!");
                    Console.WriteLine("===============================");
                    DisplayOption();
                }
            }
            else if (index == 4)
            {
                Console.WriteLine("==================================");
                Console.Write("Enter Bus Id to Delete: ");
                int id = int.Parse(Console.ReadLine());
                var _bus = busRepo.GetById(id);

                if (_bus == null)
                {
                    Console.WriteLine("======================");
                    Console.WriteLine("Bus Id is invalid!!!");
                    Console.WriteLine("======================");
                    DisplayOption();
                }
                else
                {
                    busRepo.Delete(id);
                    Console.WriteLine("Data Deleted Successfully!!!");
                    Console.WriteLine("===============================");
                    DisplayOption();
                }
            }
        }
    }
}
