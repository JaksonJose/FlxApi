using Flx.Shared.Enums;

namespace Flx.Shared.Models.IModels
{
    public interface IMessage
    {
        MessageTypeEnum MessageType { get; set; }
    }
}
