using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;
using Microsoft.EntityFrameworkCore;
using CheeseMVC.Data;

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        private CheeseDbContext context;

        public CheeseController(/*CheeseDbContext dbContext*/)
        {
            //context = dbContext;
        }

        public IActionResult Index()
        {
            CheeseListViewModel model = new CheeseListViewModel
            {
                Cheeses = CheeseData.GetAll()//context.Cheeses.ToList()
            };

            return View(model);
        }

        public IActionResult Add()
        {
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel();
            return View(addCheeseViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            if (ModelState.IsValid){
                // Add the new cheese to my existing cheeses
                //CheeseData.Add(new Cheese{
                //    Name = addCheeseViewModel.Name,
                //    Description = addCheeseViewModel.Description,
                //    Type = addCheeseViewModel.Type,
                //    Rating = addCheeseViewModel.Rating
                //});

                /*context.Cheeses.Add(addCheeseViewModel.CreateCheese());
                context.SaveChanges();*/
                CheeseData.Add(addCheeseViewModel.CreateCheese());

                return Redirect("/");
            }

            return View(addCheeseViewModel);
        }

        public IActionResult Detail(int id)
        {
            ViewBag.cheese = CheeseData.GetById(id);//.Cheeses.Single(c => c.ID == id);
            ViewBag.title = "Cheese Detail";
            return View();
        }

        public IActionResult Edit(int id)
        {
            Cheese current = CheeseData.GetById(id);//context.Cheeses.Single(c => c.ID == id);
            AddEditCheeseViewModel editCheeseViewModel = new AddEditCheeseViewModel
            {
                Name = current.Name,
                Description = current.Description,
                Type = current.Type,
                Rating = current.Rating,
                cheeseId = id
            };
            return View(editCheeseViewModel);
        }

        [HttpPost]
        public IActionResult Edit(AddEditCheeseViewModel editCheeseViewModel)
        {
            if (ModelState.IsValid)
            {
                Cheese editCheese = CheeseData.GetById(editCheeseViewModel.cheeseId);//context.Cheeses.Single(c => c.ID == editCheeseViewModel.cheeseId);
                editCheese.Name = editCheeseViewModel.Name;
                editCheese.Description = editCheeseViewModel.Description;
                editCheese.Type = editCheeseViewModel.Type;
                editCheese.Rating = editCheeseViewModel.Rating;
                return Redirect("/");
            }

            return View(editCheeseViewModel);
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Cheeses";
            ViewBag.cheeses = CheeseData.GetAll();//context.Cheeses.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] cheeseIds)
        {
            foreach (int cheeseId in cheeseIds)
            {
                //Cheese theCheese = context.Cheeses.Single(c => c.ID == cheeseId);
                //context.Cheeses.Remove(theCheese);
                CheeseData.Remove(cheeseId);
            }

            context.SaveChanges();
            return Redirect("/Cheese");
        }
    }
}
