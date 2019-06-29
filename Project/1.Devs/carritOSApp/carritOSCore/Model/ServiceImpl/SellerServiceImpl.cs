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
    public class SellerServiceImpl : ISellerService
    {
        private ISellerRepository sellerRepository;


        public SellerServiceImpl(ApplicationDbContext _contex)
        {
            sellerRepository = new SellerRepositoryImpl(_contex);
        }

        public bool Delete(Seller t)
        {
            return sellerRepository.Delete(t);
        }

        public List<Seller> FindAll()
        {
            return sellerRepository.FindAll();
        }

        public Seller FindById(int? id)
        {
            return sellerRepository.FindById(id);
        }

        public bool Save(Seller t)
        {
            return sellerRepository.Save(t);
        }

        public bool Update(Seller t)
        {
            return sellerRepository.Update(t);
        }
    }
}
