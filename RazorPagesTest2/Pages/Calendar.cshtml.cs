using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTest2.Data;
using RazorPagesTest2.Model;

namespace RazorPagesTest2.Pages
{
    [Authorize]
    public class CalendarModel : PageModel
    {
        
        [BindProperty]
        public String date { get; set; }
        private T2Communication communication = new T2Communication(); 
        public List<Movie> Movie = new List<Movie>();

        public async Task<IActionResult> OnGet() 
        {
            String today = DateTime.Today.Month.ToString() + "/" + DateTime.Today.Day.ToString() + "/" + DateTime.Today.Year.ToString();
           Console.WriteLine(today);
            date = today;
            communication.GETMovieData(date);
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            Console.WriteLine("Getting and printing out data!");
            Console.WriteLine(date);
            communication.GETMovieData(date);
            // String response = await communication.getData();
            //Console.WriteLine(response);
            


            return Page();
        }


    }
}
