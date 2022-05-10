using Flx.Domain.Models;

namespace Flx.Domain.Domains
{
    public class SubCategory : BaseSAModel
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public long ImageId { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public Image? Image { get; set; }
    }
}
