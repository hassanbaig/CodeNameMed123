using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using CareHub.Data;
using CareHub.Factory.Factories;

namespace CareHub.Repository.Base
{
    public class BaseRepository : IDisposable
    {
      
       private shiner49_CareHubEntities _context;      
       private bool _disposed;
       protected shiner49_CareHubEntities GetConnection()
       {
           string connectionString = System.Configuration.ConfigurationManager.AppSettings["customeConnectionString"].ToString();
           _context = new shiner49_CareHubEntities();
           if (_context.Database.Connection.State == System.Data.ConnectionState.Closed)
           {
               _context.Database.Connection.ConnectionString = connectionString;
               _context.Database.Connection.Open();
           }
           return _context;
       }
       public BaseRepository()
       {          
           
       }   
       public void Dispose()
       {         
           DisposeObject(true);
           GC.SuppressFinalize(this);
       }
       private void DisposeObject(bool disposing)
       {
           if (_disposed) return;
           _disposed = true;
       }   
    }
}
