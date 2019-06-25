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
    public class BusinessOwnerRepositoryImpl : IBusinessOwnerRepository
    {
        private readonly ApplicationDbContext context;

        public BusinessOwnerRepositoryImpl(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool Delete(BusinessOwner t)
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

        public List<BusinessOwner> FindAll()
        {
            return context.BusinessOwners.ToList();
        }

        public BusinessOwner FindById(int? id)
        {
            return context.BusinessOwners
              .Find(id);
        }

        public bool Save(BusinessOwner t)
        {
            try
            {
                context.BusinessOwners.Add(t);
                context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(BusinessOwner t)
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
