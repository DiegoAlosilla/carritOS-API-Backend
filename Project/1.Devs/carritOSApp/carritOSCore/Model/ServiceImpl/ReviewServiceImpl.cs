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
    public class ReviewServiceImpl : IReviewService
    {
        private IReviewRepository reviewRepository;
        public ReviewServiceImpl(ApplicationDbContext _context)
        {
            reviewRepository = new ReviewRepositoryImpl(_context);
        }

        public bool Delete(Review t)
        {
            return reviewRepository.Delete(t);
        }

        public List<Review> FindAll()
        {
            return reviewRepository.FindAll();
        }

        public Review FindById(int? id)
        {
            return reviewRepository.FindById(id);
        }

        public bool Save(Review t)
        {
            return reviewRepository.Save(t);
        }

        public bool Update(Review t)
        {
            return reviewRepository.Update(t);
        }
    }
}
