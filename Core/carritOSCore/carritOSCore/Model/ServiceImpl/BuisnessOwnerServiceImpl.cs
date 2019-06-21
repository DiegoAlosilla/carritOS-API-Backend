using carritOSCore.Model.Context;
using carritOSCore.Model.Entities;
using carritOSCore.Model.Repository;
using carritOSCore.Model.RepositoryImpl;
using carritOSCore.Model.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public bool Update(BusinessOwner t)
        {
            throw new NotImplementedException();
        }
    }
}
