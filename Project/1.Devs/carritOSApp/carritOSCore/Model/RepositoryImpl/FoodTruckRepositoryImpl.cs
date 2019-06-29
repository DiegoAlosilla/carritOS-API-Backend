using carritOSCore.Model.Context;
using carritOSCore.Model.Entities;
using carritOSCore.Model.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/**
 * --
 * @author Juan Diego Alosilla
 * @email diegoalosillagmail.com
 */
namespace carritOSCore.Model.RepositoryImpl
{
    public class FoodTruckRepositoryImpl : IFoodTruckRepository
    {
        private readonly ApplicationDbContext context;
        public FoodTruckRepositoryImpl(ApplicationDbContext _contex)
        {
            context = _contex;
        }

        public bool Delete(FoodTruck t)
        {
            try
            {
                context.Entry(t).State = EntityState.Deleted;
                context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public List<FoodTruck> FindAll()
        {
            return context.FoodTrucks.ToList();
        }

        public FoodTruck FindById(int? id)
        {
            return context.FoodTrucks
             .Find(id);
        }

        public bool Save(FoodTruck t)
        {
            try
            {
                context.FoodTrucks.Add(t);
                context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(FoodTruck t)
        {
            try
            {
                context.Entry(t).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
