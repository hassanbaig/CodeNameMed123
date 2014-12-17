using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using Medicare.Data;
using Medicare.Factory.Factories;

namespace Medicare.UnitOfWork.Base
{
    public class BaseUnitOfWork : IDisposable
    {
       protected FactoryFacade Factory;
       protected MedicareDevEntities Context;
       protected List<AbstractDomainModel> DomainModelCollection;
       private bool _disposed;
       private string InitializeConnectionString()
       {
           string connectionString = System.Configuration.ConfigurationManager.AppSettings["customeConnectionString"].ToString();   
        
          return connectionString;
       }
       public BaseUnitOfWork()
       {
           DomainModelCollection = new List<AbstractDomainModel>();
           Context = new MedicareDevEntities();
           Factory = new FactoryFacade();
           if (Context.Database.Connection.State == System.Data.ConnectionState.Closed)
           {
               Context.Database.Connection.ConnectionString = InitializeConnectionString();               
               Context.Database.Connection.Open();
           }
       }
       public BaseUnitOfWork(MedicareDevEntities context)
       {
           if (context != null)
           {
               Context = context;
               if (Context.Database.Connection.State == System.Data.ConnectionState.Closed)
               {
                   Context.Database.Connection.ConnectionString = InitializeConnectionString();
                   Context.Database.Connection.Open();
               }
           }
       }
       public BaseUnitOfWork(MedicareDevEntities context, List<AbstractDomainModel> domainModelCollection)
       {
           if (context != null)
           {
               Context = context;
               if (Context.Database.Connection.State == System.Data.ConnectionState.Closed)
               {
                   Context.Database.Connection.ConnectionString = InitializeConnectionString();
                   Context.Database.Connection.Open();
               }
           }
           DomainModelCollection = domainModelCollection;
          
       }
       public BaseUnitOfWork(MedicareDevEntities context, List<AbstractDomainModel> domainModelCollection, FactoryFacade factory)
       {
           if (context != null)
           {
               Context = context;
               if (Context.Database.Connection.State == System.Data.ConnectionState.Closed)
               {
                   Context.Database.Connection.ConnectionString = InitializeConnectionString();
                   Context.Database.Connection.Open();
               }
           }
           DomainModelCollection = domainModelCollection;          
           Factory = factory;
       }
       public void Dispose()
       {
           Context.SaveChanges();
           DisposeObject(true);
           GC.SuppressFinalize(this);
       }
       private void DisposeObject(bool disposing)
       {
           if (_disposed) return;
           if (disposing && Context != null) Context.Dispose();

           _disposed = true;
       }
                
       public void Commit()
       {
           Context.SaveChanges();    
       }

       public void Add(AbstractDomainModel obj)
       {
           DomainModelCollection.Add(obj);
       }

       public void Remove(AbstractDomainModel obj)
       {
           DomainModelCollection.Remove(obj);
       }
    }
}
