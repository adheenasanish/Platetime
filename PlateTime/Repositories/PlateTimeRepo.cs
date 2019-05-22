using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlateTimeApp.Models;
using PlateTimeApp.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlateTimeApp.Repositories
{
    public class PlateTimeRepo
    {
        private PlateTimeContext db;        

        public PlateTimeRepo(PlateTimeContext db)
        {
            this.db = db;            
        }

        public async Task<IEnumerable> GetAllPlateTime()
        {
            IEnumerable<PlateTime> all = db.PlateTime.Include(p => p.Restaurant).Include(p => p.RestaurantGoer);
            return all.Reverse();
        }

        public async Task<PlateTime> GetCurrentPlateTime(int? id)
        {
            var currentPlateTime = await db.PlateTime
                                            .Include(p => p.Restaurant)
                                            .Include(p => p.RestaurantGoer)
                                            .FirstOrDefaultAsync(m => m.Id == id);
            return currentPlateTime;
        }

        public async Task UpdateEntry(PlateTime pt)
        {
            db.Update(pt);
            await db.SaveChangesAsync();
        }

        public IEnumerable<RestaurantGoer> GetAllResGoerForPlateTime(int plateTimeId)
        {
            List<RestaurantGoer> goerList = new List<RestaurantGoer>();

            var list = db.PlateTimeRestaurantGoer.Include(p => p.PlateTime).Include(r => r.RestaurantGoer);
            foreach(RestaurantGoer rg in list.Where(r => r.PlateTimeId == plateTimeId).Select(rg => rg.RestaurantGoer).ToList())
            {
                goerList.Add(rg);
            }

            return goerList;
        }

        public void CreateNewPlateTime(PlateTime plateTime)
        {
            db.Add(plateTime);
            db.SaveChanges();
        }        

        public async Task DeleteEntry(int id)
        {
            var plateTimeResGoer = await db.PlateTimeRestaurantGoer.FirstOrDefaultAsync(pr => pr.PlateTimeId == id);
            if(plateTimeResGoer != null)
            {
                db.PlateTimeRestaurantGoer.Remove(plateTimeResGoer);
            }
            var plateTime = await db.PlateTime.FindAsync(id);            
            db.PlateTime.Remove(plateTime);
            await db.SaveChangesAsync();
        }

        public bool PlateTimeExists(int id)
        {
            return db.PlateTime.Any(e => e.Id == id);
        }

        private dynamic GetEntry(int plateTimeId, int resGoerId)
        {
            var entry = db.PlateTimeRestaurantGoer.Where(p => p.PlateTimeId == plateTimeId)
                .Where(r => r.RestaurantGoerId == resGoerId).FirstOrDefault();
            return entry;
        }

        public bool CheckAvailable(int plateTimeId)
        {
            var plateTime = db.PlateTime.Find(plateTimeId);
            int goerListCount = GetAllResGoerForPlateTime(plateTimeId).Count();
            if(goerListCount >= plateTime.MaxMembers)
            {
                return false;
            }

            return true;
        }

        public bool CheckIsClosed(int plateTimeId)
        {
            var plateTime = db.PlateTime.Find(plateTimeId);
            if ((bool)plateTime.Isopen)
            {
                return false;
            }

            return true;
        }

        public void JoinPlateTime(int plateTimeId, int resGoerId)
        {
            PlateTimeRestaurantGoer ptrg = new PlateTimeRestaurantGoer();
            ptrg.PlateTimeId = plateTimeId;
            ptrg.RestaurantGoerId = resGoerId;

            var exists = GetEntry(plateTimeId, resGoerId);
            if(exists != null)
            {
                return;
            }

            db.Add(ptrg);
            db.SaveChanges();
        }

        public void CancelPlateTime(int plateTimeId, int resGoerId)
        {
            var ptrg = GetEntry(plateTimeId, resGoerId);
            db.PlateTimeRestaurantGoer.Remove(ptrg);           
            db.SaveChanges();
        }
    }
}
