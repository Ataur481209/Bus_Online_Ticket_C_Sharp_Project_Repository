using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using work_01_Repository.Models;

namespace work_01_Repository.Repositories
{
    public class BusRepo : IRepo
    {
        public void Delete(int busId)
        {
            Bus bus = BusDB.BusList.FirstOrDefault(x => x.BusId == busId);
            BusDB.BusList.Remove(bus);
        }

        public IEnumerable<Bus> GetAll()
        {
            return BusDB.BusList;
        }

        public Bus GetById(int BusId)
        {
            Bus bus = BusDB.BusList.FirstOrDefault(x => x.BusId == BusId);
            return bus;
        }

        public void Insert(Bus bus)
        {
            BusDB.BusList.Add(bus);
        }

        public void Update(Bus bus)
        {
            Bus _bus = BusDB.BusList.FirstOrDefault(x => x.BusId == bus.BusId);
            if (bus.BusName !=null)
            {
                _bus.BusName = bus.BusName;
            }
            if (bus.BusSeatNumber !=0)
            {
                _bus.BusSeatNumber = bus.BusSeatNumber;
            }
        }
    }
}
