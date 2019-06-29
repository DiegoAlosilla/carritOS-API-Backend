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
    public class SaleRepositoryImpl : ISaleRepository
    {
        private readonly ApplicationDbContext context;

        public SaleRepositoryImpl(ApplicationDbContext _contex)
        {
            context = _contex;
        }

        public bool Delete(Sale t)
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

        public List<Sale> FindAll()
        {
            return context.Sales.ToList();
        }

        public Sale FindById(int? id)
        {
            return context.Sales
             .Find(id);
        }

        public bool Save(Sale t)
        {
            try
            {
                context.Sales.Add(t);
                context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(Sale t)
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
