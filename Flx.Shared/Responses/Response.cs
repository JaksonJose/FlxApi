using Flx.Shared.Enums;
using Flx.Shared.Models;
using Flx.Shared.Responses.IResponses;

namespace Flx.Shared.Responses
{
    public abstract class Response : IResponse
    {
        #region Properties

        public List<Message> Messages { get; set; } = new();

        /// <summary>
        /// Reflect if the message list has any messages
        /// </summary>
        public bool HasAnyMessages { get { return Messages.Count > 0; } }

        /// <summary>
        /// Reflect if there are any error message
        /// </summary>
        public bool HasErrorMessages { get { return HasMessageType(MessageTypeEnum.Error); } }

        #endregion

        #region Public Method
        /// <summary>
        /// Add Error Message to Response Object.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public Response AddErrorMessage(string text)
        {
            Messages.Add(new Message(MessageTypeEnum.Error, text));
            return this;
        }

        /// <summary>
        /// Add Exception Message to Response Object.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public Response AddExceptionMessage(string text)
        {
            Messages.Add(new Message(MessageTypeEnum.Exception, text));
            return this;
        }

        #endregion

        #region Private Method
        /// <summary>
        /// Verify if messages was added in the object.
        /// </summary>
        /// <param name="messageType"></param>
        /// <returns></returns>
        private bool HasMessageType(MessageTypeEnum messageType)
        {
            return Messages.Any(item => item.MessageType == messageType);
        }

        #endregion
    }
}
