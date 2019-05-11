using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Services
{
    public abstract class ServiceBase
    {
        public T GetEnumFromString<T>(string type)
        {
            return (T)Enum.Parse(typeof(T), type);
        }
    }
}
