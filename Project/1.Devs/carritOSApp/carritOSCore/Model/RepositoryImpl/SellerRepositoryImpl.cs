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
    public class SellerRepositoryImpl : ISellerRepository
    {
        private readonly ApplicationDbContext context;

        public SellerRepositoryImpl(ApplicationDbContext _context)
        {
            context = _context;
        }

        public bool Delete(Seller t)
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

        public List<Seller> FindAll()
        {
            return context.Sellers.ToList();
        }

        public Seller FindById(int? id)
        {
            return context.Sellers
             .Find(id);
        }

        public bool Save(Seller t)
        {
            try
            {
                context.Sellers.Add(t);
                context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(Seller t)
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
