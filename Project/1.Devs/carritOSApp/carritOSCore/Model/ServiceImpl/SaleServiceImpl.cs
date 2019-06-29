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
    public class SaleServiceImpl : ISaleService
    {
        private ISaleRepository saleRepository;

        public SaleServiceImpl(ApplicationDbContext _context)
        {
            saleRepository = new SaleRepositoryImpl(_context);
        }

        public bool Delete(Sale t)
        {
            return saleRepository.Delete(t);
        }

        public List<Sale> FindAll()
        {
            return saleRepository.FindAll();
        }

        public Sale FindById(int? id)
        {
            return saleRepository.FindById(id);
        }

        public bool Save(Sale t)
        {
            return saleRepository.Save(t);
        }

        public bool Update(Sale t)
        {
            return saleRepository.Update(t);
        }
    }
}
