
namespace Flx.Domain.Models
{
    public class Image
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }
        public string UrlImg { get; set; }
    }
}
