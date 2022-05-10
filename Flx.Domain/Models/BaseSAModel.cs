using Flx.Shared.Models;

namespace Flx.Domain.Models
{
    public class BaseSAModel : BaseModel
    {
        /// <summary>
        /// The date the instace was created.
        /// </summary>
        public DateTime CreateDateTimeUTC { get; set; }

        /// <summary>
        /// Set when user modify the instance
        /// </summary>
        public DateTime ModifyDateTimeUTC { get; set; }
    }
}
