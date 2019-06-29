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
    public class ConsumerServiceImpl : IConsumerService
    {
        private IConsumerRepository consumerRepository;
        public ConsumerServiceImpl(ApplicationDbContext _context)
        {
            consumerRepository = new ConsumerRepositoryImpl(_context);
        }

        public bool Delete(Consumer t)
        {
            return consumerRepository.Delete(t);
        }

        public List<Consumer> FindAll()
        {
            return consumerRepository.FindAll();
        }

        public Consumer FindById(int? id)
        {
            return consumerRepository.FindById(id);
        }

        public bool Save(Consumer t)
        {
            return consumerRepository.Save(t);
        }

        public bool Update(Consumer t)
        {
            return consumerRepository.Update(t);
        }
    }
}
