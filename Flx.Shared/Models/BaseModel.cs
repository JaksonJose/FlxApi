using Flx.Shared.Enums;
using Flx.Shared.Models.IModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flx.Shared.Models
{
    public class BaseModel: IModel
    {
        [NotMapped]
        public ModelActionEnum Action { get; set; }
    }
}