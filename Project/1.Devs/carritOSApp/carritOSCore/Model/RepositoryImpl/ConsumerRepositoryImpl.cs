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
    public class ConsumerRepositoryImpl : IConsumerRepository
    {
        private readonly ApplicationDbContext context;

        public ConsumerRepositoryImpl(ApplicationDbContext _contex)
        {
            context = _contex;
        }

        bool CrudRepository<Consumer>.Delete(Consumer t)
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

        List<Consumer> CrudRepository<Consumer>.FindAll()
        {
            return context.Consumers.ToList();
        }

        Consumer CrudRepository<Consumer>.FindById(int? id)
        {
            return context.Consumers
             .Find(id);
        }

        bool CrudRepository<Consumer>.Save(Consumer t)
        {
            try
            {
                context.Consumers.Add(t);
                context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        bool CrudRepository<Consumer>.Update(Consumer t)
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
