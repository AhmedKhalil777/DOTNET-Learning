using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransientScopedSingleton.Repositories
{
    public interface IMobileTransientService
    {
        IEnumerable<Mobile> GetAll();
        IEnumerable<Mobile> Add(Mobile mobile);
    }
    public class MobileTransientService : IMobileTransientService
    {
        private List<Mobile> _mobileList;

        public MobileTransientService()
        {
            _mobileList = new List<Mobile>()
            {
                new Mobile() { id = 1, name = "Samsung", model="Note-10",    price="70,000" },
                new Mobile() { id = 2, name = "Nokia",   model="S6",         price="20,000" },
                new Mobile()  { id = 3, name = "Xiaomi",  model="Note-8",    price="21,999" }
            };
        }
        public IEnumerable<Mobile> Add(Mobile mobile)
        {
            mobile.id = _mobileList.Max(e => e.id) + 1;
            _mobileList.Add(mobile);
            return GetAll();
        }
        public IEnumerable<Mobile> GetAll()
        {
            return _mobileList;
        }
    }
}
