using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces.ICrud
{
    public interface IAddUpdateReadAny<T>:IAdd<T>,IUpdate<T>,IRead<T>,IAny<T> where T : class
    {
    }
}
