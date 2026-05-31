using DTOsLayer.Common.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Interfaces
{
    public interface IPagination <T> where T : class
    {
     public Task<ICollection<T>> Pagination(Pagination request);
    }
}
