using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlateTimeApp.Models;
using PlateTimeApp.Repositories;

namespace PlateTimeApp.Controllers
{
    
    public class PlateTimesController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly PlateTimeContext _context;
        private readonly IServiceProvider _serviceProvider;
        private UserRoleAccountRepo roleRepo;
        private PlateTimeRepo ptRepo;


        public PlateTimesController(PlateTimeContext context, IServiceProvider serviceProvider, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _serviceProvider = serviceProvider;
            _userManager = userManager;

            roleRepo = new UserRoleAccountRepo(context, serviceProvider);
            ptRepo = new PlateTimeRepo(_context);
        }

        private Task<IdentityUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

        // GET: PlateTimes
        [Authorize(Roles = "Admin, Manager, Member")]
        public async Task<IActionResult> Index()
        {
            var plateTimeContext = ptRepo.GetAllPlateTime();
            ViewBag.currentResGoer = await roleRepo.GetCurrentRestrauntGoerId(await GetCurrentUserAsync());
            ViewBag.currentRes = await roleRepo.GetCurrentRestrauntId(await GetCurrentUserAsync());

            return View(await plateTimeContext);
        }

        // GET: PlateTimes/Details/5
        [Authorize(Roles = "Admin, Manager, Member")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plateTime = ptRepo.GetCurrentPlateTime(id).Result;
            if (plateTime == null)
            {
                return NotFound();
            }
            
            int currentResGoer = await roleRepo.GetCurrentRestrauntGoerId(await GetCurrentUserAsync());
            ViewBag.currentResGoer = currentResGoer;
            ViewBag.currentRes = await roleRepo.GetCurrentRestrauntId(await GetCurrentUserAsync());

            IEnumerable<RestaurantGoer> rgList = ptRepo.GetAllResGoerForPlateTime((int)id);
            ViewBag.resGoersList = rgList;

            ViewBag.isGoing = false;
            foreach(var resGoerId in rgList)
            {
                if(currentResGoer == resGoerId.Id)
                {
                    ViewBag.isGoing = true;
                }
            }

            if (!ptRepo.CheckAvailable((int) id))
            {
                ViewBag.plateTimeFull = true ;
            }
            else
            {
                ViewBag.plateTimeFull = false;
            }

            if (ptRepo.CheckIsClosed((int)id))
            {
                ViewBag.plateTimeClosed = true;
            }
            else
            {
                ViewBag.plateTimeClosed = false;
            }

            return View(plateTime);
        }

        // GET: PlateTimes/Create
        [Authorize(Roles = "Admin, Manager, Member")]
        public async Task<IActionResult> Create()
        {
            int resId = await roleRepo.GetCurrentRestrauntId(await GetCurrentUserAsync());
            if (resId != 0)
            {
                ViewBag.isRestaurant = true;
            }

            ViewData["RestaurantId"] = new SelectList(_context.Restaurant, "Id", "Name");
            ViewData["RestaurantGoerId"] = new SelectList(_context.RestaurantGoer, "Id", "Name");

            return View();
        }

        // POST: PlateTimes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Manager, Member")]
        public async Task<IActionResult> Create([Bind("Id,RestaurantGoerId,RestaurantId,Time,MaxMembers,Isopen,AllCommitted")] PlateTime plateTime)
        {            
            int resGoerId = await roleRepo.GetCurrentRestrauntGoerId(await GetCurrentUserAsync());
            if (resGoerId != 0)
            {
                plateTime.RestaurantGoerId = resGoerId;
            }

            int resId = await roleRepo.GetCurrentRestrauntId(await GetCurrentUserAsync());
            if (resId != 0)
            {
                plateTime.RestaurantId = resId;
                plateTime.RestaurantGoerId = null;
            }

            if (ModelState.IsValid)
            {
                ptRepo.CreateNewPlateTime(plateTime);
                return RedirectToAction(nameof(Index));
            }
            
            ViewBag.ErrorMessage = "Please make sure all fields have valid entries.";
            ViewData["RestaurantId"] = new SelectList(_context.Restaurant, "Id", "Name", plateTime.RestaurantId);
            ViewData["RestaurantGoerId"] = new SelectList(_context.RestaurantGoer, "Id", "Name", resGoerId);
            return View(plateTime);
        }

        // GET: PlateTimes/Edit/5
        [Authorize(Roles = "Admin, Manager, Member")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            PlateTime plateTime = await ptRepo.GetCurrentPlateTime(id);
            if (plateTime == null)
            {
                return NotFound();
            }
            if (plateTime.RestaurantGoerId != await roleRepo.GetCurrentRestrauntGoerId(await GetCurrentUserAsync()) &&
                plateTime.RestaurantId != await roleRepo.GetCurrentRestrauntId(await GetCurrentUserAsync()))
            {
                return NotFound();
            }

            int resId = 0;
            resId = await roleRepo.GetCurrentRestrauntId(await GetCurrentUserAsync());
            if (resId != 0)
            {
                ViewBag.isRestaurant = true;
            }

            List<SelectListItem> tfList = new List<SelectListItem>();
            tfList.Add(new SelectListItem
            {
                Text = "Open",
                Value = true.ToString()
            });
            tfList.Add(new SelectListItem
            {
                Text = "Closed",
                Value = false.ToString()
            });
            ViewData["TrueFalse"] = tfList;
            ViewData["RestaurantId"] = new SelectList(_context.Restaurant, "Id", "Name", plateTime.RestaurantId);
            ViewData["RestaurantGoerId"] = new SelectList(_context.RestaurantGoer, "Id", "Name", plateTime.RestaurantGoerId);
            return View(plateTime);
        }

        // POST: PlateTimes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Manager, Member")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RestaurantGoerId,RestaurantId,Time,MaxMembers,Isopen,AllCommitted")] PlateTime plateTime)
        {
            if (id != plateTime.Id)
            {
                return NotFound();
            }

            int resGoerId = await roleRepo.GetCurrentRestrauntGoerId(await GetCurrentUserAsync());
            if (resGoerId != 0)
            {
                plateTime.RestaurantGoerId = resGoerId;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await ptRepo.UpdateEntry(plateTime);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ptRepo.PlateTimeExists(plateTime.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["RestaurantId"] = new SelectList(_context.Restaurant, "Id", "Name", plateTime.RestaurantId);
            ViewData["RestaurantGoerId"] = new SelectList(_context.RestaurantGoer, "Id", "Name", plateTime.RestaurantGoerId);
            return View(plateTime);
        }

        // GET: PlateTimes/Delete/5
        [Authorize(Roles = "Admin, Manager, Member")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plateTime = await ptRepo.GetCurrentPlateTime(id);
            if (plateTime == null)
            {
                return NotFound();
            }
            if (plateTime.RestaurantGoerId != await roleRepo.GetCurrentRestrauntGoerId(await GetCurrentUserAsync()) &&
                plateTime.RestaurantId != await roleRepo.GetCurrentRestrauntId(await GetCurrentUserAsync()))
            {
                return NotFound();
            }

            return View(plateTime);
        }

        // POST: PlateTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Manager, Member")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await ptRepo.DeleteEntry(id);
            return RedirectToAction(nameof(Index));
        }        

        [Authorize(Roles = "Admin, Manager, Member")]
        public IActionResult JoinPlateTime(int plateTimeId, int resGoerId)
        {
            if (!ptRepo.CheckAvailable(plateTimeId) || ptRepo.CheckIsClosed(plateTimeId))
            {
                return RedirectToAction(nameof(Details), new { id = plateTimeId });
            }
            ptRepo.JoinPlateTime(plateTimeId, resGoerId);

            return RedirectToAction(nameof(Details), new { id = plateTimeId });
        }

        [Authorize(Roles = "Admin, Manager, Member")]
        public IActionResult CancelJoinPlateTime(int plateTimeId, int resGoerId)
        {
            ptRepo.CancelPlateTime(plateTimeId, resGoerId);

            return RedirectToAction(nameof(Index));
        }
    }
}
