using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces.ICrud
{
    public interface IUpdate<T> where T : class
    {
        public void Update(T entity);
    }
}
