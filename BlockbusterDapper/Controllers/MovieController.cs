using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlockbusterDapper.Models;
using Dapper;

namespace BlockbusterDapper.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            Movies m = new Movies();
            return View(m);
        }
        
        [HttpPost]
        public IActionResult Index(Movies m)
        {
            if (ModelState.IsValid)
            {
                using (var connect = new MySqlConnection(Secret.Connection))
                {

                    string insertString = $"insert into movie values(0,@name,@genre,@year,@runtime)";
                    string queryString = $"select * from movie";

                    connect.Open();
                    connect.Execute(insertString, new
                    {
                        Title = m.Name,
                        Genre = m.Genre,
                        Year = m.Year,
                        Runtime = m.Runtime
                    });
                    List<Movies> inventory = connect.Query<Movies>(queryString).ToList();
                    connect.Close();

                    return RedirectToAction("List", "Movie");
                }
            }
            else
            {
                return View(m);
            }
        }

        public IActionResult List()
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {


                string queryString = $"select * from movies";

                connect.Open();
                List<Movies> inventory = connect.Query<Movies>(queryString).ToList();
                connect.Close();
                return View(inventory);
            }

        }

    }
}
