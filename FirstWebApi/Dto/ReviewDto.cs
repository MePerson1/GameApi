using System.ComponentModel.DataAnnotations;

namespace FirstWebApi.Dto
{
    public class ReviewDto
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
    }
}
