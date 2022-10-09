using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UjAnthologySSO.DataAccess.Repository.IRepository
{

    // This is to prevent accessing the database directly because its a big project
   public  interface IRepository<T> where T: class
   {
       T GetFirstOrDefault(Expression<Func<T,Boolean>> filter);// this gets a class spits out a boolean and we pass it to filter
       IEnumerable<T> GetAll(); // getting a list of T 
       void Add(T entity); // Passing the object that need be added
       void Remove(T entity); //Passing the object that need be deleted
       void RemoveRange(IEnumerable<T> entities); // Passing a range of objects that need be deleted


   }
}
