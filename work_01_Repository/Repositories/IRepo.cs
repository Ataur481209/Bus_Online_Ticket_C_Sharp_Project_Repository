using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using work_01_Repository.Models;

namespace work_01_Repository.Repositories
{
    public interface IRepo
    {
        IEnumerable<Bus> GetAll();
        Bus GetById(int BusId);
        void Insert(Bus bus);
        void Update(Bus bus);
        void Delete(int busId);
    }
}
