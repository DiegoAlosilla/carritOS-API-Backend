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
    public class BusinessOwnerServiceImpl : IBusinessOwnerService
    {
        private IBusinessOwnerRepository BusinessOwnerRepository;

        public BusinessOwnerServiceImpl(ApplicationDbContext context)
        {
            BusinessOwnerRepository = new BusinessOwnerRepositoryImpl(context);
        }

        public bool Delete(BusinessOwner t)
        {
            return BusinessOwnerRepository.Delete(t);
        }

        public List<BusinessOwner> FindAll()
        {
            return BusinessOwnerRepository.FindAll();
        }

        public BusinessOwner FindById(int? id)
        {
            return BusinessOwnerRepository.FindById(id);
        }

        public bool Save(BusinessOwner t)
        {
            return BusinessOwnerRepository.Save(t);
        }

        public bool Update(BusinessOwner t)
        {
            return BusinessOwnerRepository.Update(t);
        }
    }
}
