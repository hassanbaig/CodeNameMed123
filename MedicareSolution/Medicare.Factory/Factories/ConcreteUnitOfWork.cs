using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.Factory.Factories
{
   public class ConcreteUnitOfWork:AbstractFactory
    {
       public override IUnitOfWork CreateUnitOfWork(Type type)
        {
            IUnitOfWork obj = null;
            obj = (IUnitOfWork)CreateObject(type);
            return obj;
        }      
    }
}
