using DTOsLayer.Common.Exceptions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Exceptions
{
    public class DbExceptions
    {
        private static Exception _HandkeForeignKeyConstraints(DbUpdateException ex) 
        {
             return new ConflictException("Operation violates data relationships"); ;
        }
        private static Exception _HandleUniqeConstrains(DbUpdateException ex)
        {
            return new ConflictException("Duplicated value");
                }
    public static Exception Map(DbUpdateException ex) 
        {
            SqlException? sqle = FindSqlExpression(ex);
            if (sqle == null) return new AppException("DataBase error", 500);
            switch (sqle.Number) 
            {
                case 2601:
                case 2627: 
                    {
                        return _HandleUniqeConstrains(ex);
                    }
                case 547: return _HandkeForeignKeyConstraints(ex);

                default:
                    return new AppException("DataBase error", 500);
            }

        }
    
    private static SqlException? FindSqlExpression(Exception? ex)
        {
            while (ex !=null) 
            {
                if (ex is SqlException sqlex)
                {
                    return sqlex;
                }
                ex = ex.InnerException;
            }
            return null;
        }
    
    
    }
}
