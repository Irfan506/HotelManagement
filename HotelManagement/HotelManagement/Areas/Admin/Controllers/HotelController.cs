using HotelManagement.Areas.Admin.Models;
using HotelManagement.Common.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HotelController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<HotelController> _logger;
        private readonly IEmailSender _emailSender;
        public HotelController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<HotelController> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }
        public IActionResult DashBoard()
        {
            return View();
        }

        public IActionResult ManageRoom()
        {
            ViewBag.SomeData = "Hello From Asp.Net";
            var model = new RoomListModel();
            return View(model);
        }
        public JsonResult GetRoomData()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new RoomListModel();
            var data = model.GetRooms(dataTablesModel);
            return Json(data);
        }
        public IActionResult AddRoom()
        {
            var model = new AddRoomModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddRoom(AddRoomModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.AddRoom();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to Add Room");
                    _logger.LogError(ex, "Add room Failed");
                }

            }
            return View(model);
        }
        public IActionResult EditRoom(int id)
        {
            var model = new EditRoomModel();
            model.LoadModelData(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditRoomModel model)
        {
            if (ModelState.IsValid)
            {
                model.Update();
            }

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]

        public IActionResult Delete(int id)
        {
            var model = new RoomListModel();
            model.Delete(id);

            return RedirectToAction(nameof(ManageRoom));

        }
        




        public IActionResult AddUser()
        {
            var model = new AddUserModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddUser(AddUserModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.AddUser();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to Add User");
                    _logger.LogError(ex, "Add user Failed");
                }

            }
            return View(model);
        }
    }
}
