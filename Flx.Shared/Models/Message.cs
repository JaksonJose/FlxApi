using Flx.Shared.Enums;
using Flx.Shared.Models.IModels;

namespace Flx.Shared.Models
{
    public class Message : IMessage
    {
        public Message(MessageTypeEnum messageType, string text)
        {
            this.MessageType = messageType;
            this.Text = text;
        }
        public MessageTypeEnum MessageType { get; set; } = MessageTypeEnum.None;
        public string Text { get; set; }
    }
}
