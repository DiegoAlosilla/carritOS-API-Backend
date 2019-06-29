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
    public class ContractRepositoryImpl : IContractRepository
    {
        private readonly ApplicationDbContext context;

        public ContractRepositoryImpl(ApplicationDbContext _contex)
        {
            context = _contex;
        }

        bool CrudRepository<Contract>.Delete(Contract t)
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

        List<Contract> CrudRepository<Contract>.FindAll()
        {
            return context.Contracts.ToList();
        }

        Contract CrudRepository<Contract>.FindById(int? id)
        {
            return context.Contracts
             .Find(id);
        }

        bool CrudRepository<Contract>.Save(Contract t)
        {
            try
            {
                context.Contracts.Add(t);
                context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        bool CrudRepository<Contract>.Update(Contract t)
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
