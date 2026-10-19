using Microsoft.AspNetCore.Mvc;
using HtthLab01.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace HtthLab01.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> listStudents = new List<Student>();
        private readonly IWebHostEnvironment _env;

        public StudentController(IWebHostEnvironment env)
        {
            _env = env;
            if(listStudents.Count == 0)
            {
                listStudents = new List<Student>()
                {
                    new Student()
                    {
                        Id = 101,
                        Name = "Hải Nam",
                        Branch = Branch.IT,
                        Gender = Gender.Male,
                        IsRegular = true,
                        Address = "A1-2018",
                        Email = "nam@g.com"
                    },
                    new Student()
                    {
                        Id = 102,
                        Name = "Minh Tú",
                        Branch = Branch.BE,
                        Gender = Gender.Female,
                        IsRegular = true,
                        Address = "A1-2019",
                        Email = "tu@g.com"
                    },
                    new Student()
                    {
                        Id = 103,
                        Name = "Hoàng Phong",
                        Branch = Branch.CE,
                        Gender = Gender.Male,
                        IsRegular = false,
                        Address = "A1-2020",
                        Email = "phong@g.com"
                    },
                    new Student()
                    {
                        Id = 104,
                        Name = "Xuân Mai",
                        Branch = Branch.EE,
                        Gender = Gender.Female,
                        IsRegular = false,
                        Address = "A1-2021",
                        Email = "mai@g.com"
                    }
                };
            }
        }

        

        public IActionResult Index()
        {
            return View(listStudents);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem() {Text = "IT", Value = "1" },
                new SelectListItem() {Text = "BE", Value = "2" },
                new SelectListItem() {Text = "CE", Value = "3" },
                new SelectListItem() {Text = "EE", Value = "4" },
            };
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student s)
        {
            if(s.AvatarFile != null)
            {
                string uploadFolder = Path.Combine(_env.WebRootPath, "images");
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }
                string fileName = Guid.NewGuid().ToString() + "_" + s.AvatarFile.FileName.Replace(" ", "");
                string filePath = Path.Combine(uploadFolder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    s.AvatarFile.CopyTo(fileStream);
                }
                s.AvatarUrl = "/images/" + fileName;
            }
            s.Id = listStudents.Last<Student>().Id +1;
            listStudents.Add(s);
            return View("Index", listStudents);
        }
    }
}