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
    public class ReviewRepositoryImpl : IReviewRepository
    {
        private readonly ApplicationDbContext context;
        public ReviewRepositoryImpl(ApplicationDbContext _contex)
        {
            context = _contex;
        }

        public bool Delete(Review t)
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

        public List<Review> FindAll()
        {
            return context.Reviews.ToList();
        }

        public Review FindById(int? id)
        {
            return context.Reviews
             .Find(id);
        }

        public bool Save(Review t)
        {
            try
            {
                context.Reviews.Add(t);
                context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(Review t)
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
