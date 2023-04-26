using FirstWebApi.Models;

namespace FirstWebApi.Interfaces
{
    public interface IReviewRepository
    {
        IEnumerable<Review> GetAll();
        Review? GetById(int id);
        int Create(Review review);
        bool Update(int id, Review review);
        bool Delete(int id);
    }
}
