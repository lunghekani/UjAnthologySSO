using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UjAnthologySSO.Models;

namespace UjAnthologySSO.DataAccess.Repository.IRepository
{
    public interface ICoursesRepository : IRepository<Course> // passing the model
    {
        void Update(Course obj); // implementing an update course

        void Save(); // this is a save function which helps limit the calls to the db
    }
}
