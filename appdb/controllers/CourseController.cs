using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using appdb.models;
using appdb.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace appdb.controllers
{
    public class CourseController : Controller
    {

        private readonly CourseService _courseService;
        private readonly IConfiguration _iconfiguration;

        public CourseController(CourseService srv, IConfiguration config)
        {
            _courseService = srv;
            _iconfiguration = config;
        }

        public IActionResult Index()
        {
            IEnumerable<Course> _course = _courseService.GetCourses(_iconfiguration.GetConnectionString("SqlConnection"));
            return View(_course);
        }
    }
}