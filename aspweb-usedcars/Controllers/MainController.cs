using aspweb_usedcars.DataAbstractionLayer;
using aspweb_usedcars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aspweb_usedcars.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            return View("FilterCars");
        }

        public ActionResult GoAddCar()
        {
            return View("AddCar");
        }

        public string Test()
        {
            return "It's working";
        }

        public string GetCarsFromCategory()
        {
            string category = Request.Params["category"];
            DAL dal = new DAL();
            System.Diagnostics.Debug.WriteLine("about to get cars");
            List<Car> clist = dal.GetCarsFromCategory(category);

            //ViewData["carList"] = clist;
            //return View("FilterCars");
            //Response.Redirect("FilterCars", false);
            //return;

            string result = "<table class='table'><thead><th>model</th><th>hp</th><th>fuel</th><th>year</th><th>color</th><th>price</th><th>update</th><th>delete</th></thead>";
            System.Diagnostics.Debug.WriteLine("got cars");
            foreach (Car car in clist)
            {
                result += "<tr data-id=" + car.id + "><td>" + car.model + "</td><td>" + car.engine_power + "</td><td>" + car.fuel + "</td><td>" + car.year + "</td><td>" + car.color + "</td><td>" + car.price + "</td>" +
                    "<td><input type='button' class='btn update' value='Update'/></td>" +
                    "<td><input type='button' class='btn delete' value='Delete'/></td></tr>";
            }
            result += "</table>";
            return result;
        }

        public string DeleteCar()
        {
            int id = Int32.Parse(Request.Params["id"]);
            System.Diagnostics.Debug.WriteLine("deleting car with id: " + id.ToString());
            DAL dal = new DAL();
            dal.DeleteCar(id);
            System.Diagnostics.Debug.WriteLine("deleted car with id: " + id.ToString());
            return "im done with deleting now its your responsibility";
        }

        public ActionResult GoUpdateCar(int id)
        {
            DAL dal = new DAL();
            Car car = dal.GetCar(id);
            ViewData["car"] = car;
            return View("UpdateCarView");
        }

        public ActionResult UpdateCar()
        {
            Car car = new Car();
            car.id = Int32.Parse(Request.Params["id"]);
            System.Diagnostics.Debug.WriteLine("updating car with id: " + car.id.ToString());
            car.model = Request.Params["model"];
            car.engine_power = Int32.Parse(Request.Params["engine_power"]);
            car.fuel = Request.Params["fuel"];
            car.year = Int32.Parse(Request.Params["year"]);
            car.color = Request.Params["color"];
            car.price = Int32.Parse(Request.Params["price"]);
            DAL dal = new DAL();
            dal.UpdateCar(car);
            //ViewData["car"] = car;
            return View("FilterCars");
        }

        public ActionResult AddCar()
        {
            Car car = new Car();
            car.category = Request.Params["category"];
            car.model = Request.Params["model"];
            car.engine_power = Int32.Parse(Request.Params["engine_power"]);
            car.fuel = Request.Params["fuel"];
            car.year = Int32.Parse(Request.Params["year"]);
            car.color = Request.Params["color"];
            car.price = Int32.Parse(Request.Params["price"]);
            DAL dal = new DAL();
            dal.AddCar(car);
            return View("FilterCars");
        }
    }
}