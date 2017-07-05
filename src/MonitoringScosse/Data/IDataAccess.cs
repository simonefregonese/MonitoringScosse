using MonitoringScosse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonitoringScosse.Data
{
    public interface IDataAccess
    {
        void Insert(Misurazione m);

        IEnumerable<Misurazione> GetAll();
        bool isWorking(int id);
    }
}
