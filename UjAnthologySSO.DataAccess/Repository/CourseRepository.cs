using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UjAnthologySSO.DataAccess.Repository.IRepository;
using UjAnthologySSO.Models;

namespace UjAnthologySSO.DataAccess.Repository
{
    public class CourseRepository : Repository<Course>, ICoursesRepository
    {
        private readonly ApplicationDbContext _db;

        public CourseRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Course obj)
        {
            _db.Courses.Update(obj);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
