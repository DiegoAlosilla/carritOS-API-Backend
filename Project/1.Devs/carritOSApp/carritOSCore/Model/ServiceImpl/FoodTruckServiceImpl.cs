using carritOSCore.Model.Context;
using carritOSCore.Model.Entities;
using carritOSCore.Model.Repository;
using carritOSCore.Model.RepositoryImpl;
using carritOSCore.Model.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/**
 * --
 * @author Juan Diego Alosilla
 * @email diegoalosillagmail.com
 */
namespace carritOSCore.Model.ServiceImpl
{
    public class FoodTruckServiceImpl : IFoodTruckService
    {
        private IFoodTruckRepository foodTruckRepository;

        public FoodTruckServiceImpl(ApplicationDbContext _contex)
        {
            foodTruckRepository = new FoodTruckRepositoryImpl(_contex);
        }


        public bool Delete(FoodTruck t)
        {
            return foodTruckRepository.Delete(t);
        }

        public List<FoodTruck> FindAll()
        {
            return foodTruckRepository.FindAll();
        }

        public FoodTruck FindById(int? id)
        {
            return foodTruckRepository.FindById(id);
        }

        public bool Save(FoodTruck t)
        {
            return foodTruckRepository.Save(t);
        }

        public bool Update(FoodTruck t)
        {
            return foodTruckRepository.Update(t);
        }
    }
}
