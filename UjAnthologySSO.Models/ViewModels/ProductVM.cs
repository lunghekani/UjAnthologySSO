﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UjAnthologySSO.Models.ViewModels
{
    public class ProductVM
    {
       public Product product { get; set; }
      public IEnumerable<SelectListItem> CourseList { get; set; }
      public IEnumerable<SelectListItem> CoverList { get; set; }
    }
}
