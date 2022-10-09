using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UjAnthologySSO.Models;

namespace UjAnthologySSO.DataAccess.Repository.IRepository
{
    public interface ICoverTypeRepository : IRepository<CoverType> // passing the model
    {
        void Update(CoverType obj); // implementing an update course

    }
}
