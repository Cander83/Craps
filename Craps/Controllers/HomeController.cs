using Craps.ApiDataHandlers;
using Craps.DataGateways;
using Craps.EntityFrameworkDataHandlers;
using Craps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Craps.Controllers
{
    public class HomeController : Controller
    {
        public HomeModel HomeModel { get; set; }

        public HomeController()
        {
            HomeModel = new HomeModel();
            HomeModel.UserName = "";
            HomeModel.CrapsResultModel = new EntityControllers.CrapsObjects.CrapsResultModel();
        }

        public ActionResult Index()
        {
            return View(HomeModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult NavigateCreateUser(Models.HomeModel inputModel)
        {
            return View("CreateUser", HomeModel);
        }

        public ActionResult NavigateGetUser(Models.HomeModel inputModel)
        {
            return View("GetUser", HomeModel);
        }

        public ActionResult GetUser(Models.HomeModel inputModel)
        {
            UserDataGateway userDataGateway = new UserDataGateway(new UserEfDataHandler());

            UserModel result = userDataGateway.GetUser(inputModel.UserName);

            HomeModel.UserId = result.Id.ToString();
            HomeModel.UserName = result.Name;

            return View("Index", HomeModel);
        }

        public ActionResult NavigateDeleteUser(Models.HomeModel inputModel)
        {
            return View("DeleteUser");
        }

        public ActionResult NavigateViewCrapsRecord(Models.HomeModel inputModel)
        {
            CrapsResultDataGateway dataGateway = new CrapsResultDataGateway(new GameRecordEfDataHandler());

            CrapsRecordListModel resultModel = new CrapsRecordListModel();

            resultModel.CrapsResults = dataGateway.GetAllCrapsResults(inputModel.UserId);

            return View("CrapsRecords", resultModel);
        }

        public ActionResult CreateUser(Models.HomeModel inputModel)
        {
            UserDataGateway userDataGateway = new UserDataGateway(new UserEfDataHandler());

            UserModel result = userDataGateway.createUser(inputModel.UserName);

            HomeModel.UserId = result.Id.ToString();
            HomeModel.UserName = result.Name;

            return View("Index",HomeModel);
        }

        public ActionResult DeleteUser(Models.HomeModel inputModel)
        {
            UserDataGateway userDataGateway = new UserDataGateway(new UserEfDataHandler());

            userDataGateway.DeleteUser(inputModel.UserName);

            HomeModel.UserId = "";
            HomeModel.UserName = "";

            return View("Index", HomeModel);
        }

        public ActionResult NavigateCraps(Models.HomeModel inputModel)
        {
            return View("Craps", inputModel);
        }

        public async System.Threading.Tasks.Task<ActionResult> PlayCraps(Models.HomeModel inputModel)
        {
            this.HomeModel.UserName = inputModel.UserName;
            this.HomeModel.UserId = inputModel.UserId;

            Craps.EntityControllers.CrapsObjects.CrapsController game = new EntityControllers.CrapsObjects.CrapsController(new RollDataHandler());

            this.HomeModel.CrapsResultModel = await game.PlayCraps(this.HomeModel.CrapsResultModel);

            CrapsResultDataGateway dataGateway = new CrapsResultDataGateway(new GameRecordEfDataHandler());

            if (HomeModel.CrapsResultModel.GameStatus != "point")
            {
                this.HomeModel.CrapsResultModel.GameId = dataGateway.CreateCrapsResult(HomeModel.CrapsResultModel);
            }
            else if (HomeModel.CrapsResultModel.GameStatus == "point" && HomeModel.CrapsResultModel.GameId != 0 )
            {
                dataGateway.UpdateCrapsResult(HomeModel.CrapsResultModel);
            }

            return View("Index", HomeModel);
        }

    }
}