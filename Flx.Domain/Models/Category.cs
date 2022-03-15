using Flx.Domain.Models;

namespace Flx.Domain.Domains
{
    public class Category
    {
        public long Id { get; set; }
        public int ImageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public Image Image { get; set; }
        public List<SubCategory> SubCategories { get; set; }
    }
}
