using FirstWebApi.Data;
using FirstWebApi.Interfaces;
using FirstWebApi.Models;

namespace FirstWebApi.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private DatabaseContext context;
        public ReviewRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public int Create(Review review)
        {
            context.Reviews.Add(review);
            context.SaveChanges();
            return review.Id;
        }

        public bool Delete(int id)
        {
            var reviewToDelete = context.Reviews.FirstOrDefault(review => review.Id == id);
            if (reviewToDelete is null)
            {
                return false;
            }
            context.Reviews.Remove(reviewToDelete);
            context.SaveChanges();
            return true;
        }

        public IEnumerable<Review> GetAll()
        {
            return context.Reviews.ToList();
        }

        public Review? GetById(int id)
        {
            return context.Reviews.FirstOrDefault(review => review.Id == id);
        }

        public bool Update(int id, Review review)
        {
            var reviewToUpdate = context.Reviews.Find(id);
            if(reviewToUpdate is null)
            {
                return false;
            }
            reviewToUpdate.Title = review.Title;
            reviewToUpdate.Description = review.Description;
            reviewToUpdate.Author = review.Author;

            context.SaveChanges();
            return true;
        }
    }
}
