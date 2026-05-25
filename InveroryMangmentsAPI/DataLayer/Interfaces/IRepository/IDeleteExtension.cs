using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces.IRepository
{
    public  interface IDeleteExtension<Tkey> where Tkey : struct
    {
        Task<bool> DeleteAsync<T>(Tkey id);
    }
}
