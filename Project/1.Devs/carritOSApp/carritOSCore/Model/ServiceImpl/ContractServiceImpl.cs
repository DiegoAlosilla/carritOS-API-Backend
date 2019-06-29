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
    public class ContractServiceImpl : IContractService
    {
        private IContractRepository contractRepository;
        public ContractServiceImpl(ApplicationDbContext _context)
        {
            contractRepository = new ContractRepositoryImpl(_context);
        }

        public bool Delete(Contract t)
        {
            return contractRepository.Delete(t);
        }

        public List<Contract> FindAll()
        {
            return contractRepository.FindAll();
        }

        public Contract FindById(int? id)
        {
            return contractRepository.FindById(id);
        }

        public bool Save(Contract t)
        {
            return contractRepository.Save(t);
        }

        public bool Update(Contract t)
        {
            return contractRepository.Update(t);
        }
    }
}
