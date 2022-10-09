using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UjAnthologySSO.DataAccess.Repository.IRepository
{
   public  interface IUnitOfWork
    {
        ICoursesRepository Courses { get; }
        ICoverTypeRepository CoverType { get; }
        void Save();
    }
}
