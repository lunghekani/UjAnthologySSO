﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UjAnthologySSO.DataAccess.Repository.IRepository;

namespace UjAnthologySSO.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Courses = new CourseRepository(_db);
            CoverType = new CoverTypeRepository(_db);
        }
        public ICoursesRepository Courses { get; private set; }
        public ICoverTypeRepository CoverType { get; private set; }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}