using Flx.Domain.Models;

namespace Flx.Domain.Domains
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public List<Image> ImgUrl { get; set; }
        public List<SubCategory> SubCategories { get; set; }
    }
}
