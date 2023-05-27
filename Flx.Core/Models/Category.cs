
namespace Flx.Core.Models
{
    public class Category : BaseSAModel
    {
        public long Id { get; set; }
        public int ImageId { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public Image? Image { get; set; }
        public List<SubCategory>? SubCategories { get; set; }
    }
}