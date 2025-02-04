﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Start.Models;

namespace MVC_Start.Controllers
{
    public class HomeController : Controller  // ":" is extends, so extend Controller into HomeController
    {
        public IActionResult Index(int id)
        {
            DemoModel MyModel = new DemoModel
            {
                FirstName = "John",
                LastName = "Doe",
                Age = id
            };

            return View(MyModel);
        }

        public IActionResult IndexWithLayout()
        {
            return View();
        }

        public IActionResult Demo()
        {
            return View();
        }

        public IActionResult Contact2()
        {
            GuestContact contact = new GuestContact();
            
            contact.Name = "Erich McCartney";
            contact.Email = "emccartney@usf.edu";
            contact.Phone = "123-456-789";

            return View(contact);
        }

        [HttpPost]  //decoration method with same name to collect form information
        public IActionResult Contact2(GuestContact c)  
        {
            return View();
        }

        public IActionResult Contact3()
        {
            GuestContact contact = new GuestContact();

            contact.Name = "Erich McCartney";
            contact.Email = "emccartney@usf.edu";
            contact.Phone = "123-456-789";
            contact.Address = "123 N 1st Ave";
            contact.City = "Tampa";
            contact.State = "FL";

            return View(contact);
        }

        [HttpPost]  //decoration method with same name to collect form information
        public IActionResult Contact3(GuestContact c)
        {
            return View();
        }


        public IActionResult Contact()
        {
            GuestContact contact = new GuestContact();

            contact.Name = "Erich McCartney";
            contact.Email = "emccartney@usf.edu";
            contact.Phone = "813-974-6716";


            /* alternate syntax to initialize object 
            GuestContact contact2 = new GuestContact
            {
              Name = "Manish Agrawal",
              Email = "magrawal@usf.edu",
              Phone = "813-974-6716"
            };
            */

            //ViewData["Message"] = "Your contact page.";

            return View(contact);
        }

        [HttpPost]
        public IActionResult Contact(GuestContact contact)
        {
            return View(contact);
        }

        /// <summary>
        /// Replicate the chart example in the JavaScript presentation
        /// 
        /// Typically LINQ and SQL return data as collections.
        /// Hence we start the example by creating collections representing the x-axis labels and the y-axis values
        /// However, chart.js expects data as a string, not as a collection.
        ///   Hence we join the elements in the collections into strings in the view model
        /// </summary>
        /// <returns>View that will display the chart</returns>
        public ViewResult DemoChart()
        {
            string[] ChartLabels = new string[] { "Africa", "Asia", "Europe", "Latin America", "North America" };
            int[] ChartData = new int[] { 2478, 5267, 734, 784, 433 };

            ChartModel Model = new ChartModel
            {
                ChartType = "bar",
                Labels = String.Join(",", ChartLabels.Select(d => "'" + d + "'")),
                Data = String.Join(",", ChartData.Select(d => d)),
                Title = "Predicted world population (millions) in 2050"
            };

            return View(Model);
        }
    }
}