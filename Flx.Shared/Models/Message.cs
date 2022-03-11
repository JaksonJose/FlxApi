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

        public Message(MessageTypeEnum messageType, string text, int status)
        {
            this.MessageType = messageType;
            this.Text = text;
            this.Status = status;
        }

        public MessageTypeEnum MessageType { get; set; } = MessageTypeEnum.None;
        public int Status { get; set; }
        public string Text { get; set; }
    }
}
