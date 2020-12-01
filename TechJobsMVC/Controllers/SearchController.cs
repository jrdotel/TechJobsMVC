using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Data;
using TechJobsMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        // TODO #3: Create an action method to process a search request and render the updated search view.
        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Job> jobs;

            ViewBag.columns = ListController.ColumnChoices;

            int count;

            if (string.IsNullOrEmpty(searchTerm))
            {
                jobs = JobData.FindByColumnAndValue(searchType, "all");
                count = jobs.Count;
                ViewBag.search = "Blank search returned. Please enter a Search Term.";
            }
            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                count = jobs.Count;

                if (count < 1)
                {
                    ViewBag.search = count + " Jobs with " + ViewBag.columns[searchType] + ": " + searchTerm;
                }
                else if (count == 1)
                {
                    ViewBag.search = count + " Job with " + ViewBag.columns[searchType] + ": " + searchTerm;
                }
                else
                {
                    ViewBag.search = count + " Jobs with " + ViewBag.columns[searchType] + ": " + searchTerm;
                }
            }

            ViewBag.jobs = jobs;
            return View("Index");
        }
    }
}
