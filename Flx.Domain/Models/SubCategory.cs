using Flx.Domain.Models;

namespace Flx.Domain.Domains
{
    public class SubCategory
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public long ImageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Image Image { get; set; }
    }
}
