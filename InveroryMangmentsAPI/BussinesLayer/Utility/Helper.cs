using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Utility
{
    public class Helper <T>
    {
        public static T CastingTo(int id) 
        {
        return (T)Convert.ChangeType(id, typeof(T));
        }
    }
}
