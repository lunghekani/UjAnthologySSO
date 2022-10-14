using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UjAnthologySSO.Models;

namespace UjAnthologySSO.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product> // passing the model
    {
        void Update(Product obj); // implementing an update course

    }
}
