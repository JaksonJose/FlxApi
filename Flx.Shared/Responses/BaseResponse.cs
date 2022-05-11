using Flx.Shared.Enums;
using Flx.Shared.Models;
using Flx.Shared.Responses.IResponses;

namespace Flx.Shared.Responses
{
    public abstract class BaseResponse : IBaseResponse
    {
        #region Properties

        public List<Message> Messages { get; set; } = new();
        public string Token { get; set; } = "";

        /// <summary>
        /// Reflect if the message list has any messages
        /// </summary>
        public bool HasAnyMessages { get { return Messages.Count > 0; } }

        /// <summary>
        /// Reflect if there are any error messages
        /// </summary>
        public bool HasErrorMessages { get { return HasMessageType(MessageTypeEnum.Error); } }

        /// <summary>
        /// Reflext if there are any Exception Messages
        /// </summary>
        public bool HasExceptionMessages { get { return HasMessageType(MessageTypeEnum.Exception); } }

        /// <summary>
        /// Reflect if there are any Infomation messages
        /// </summary>
        public bool HasInformationMessages { get { return HasMessageType(MessageTypeEnum.Info); } }

        /// <summary>
        /// Reflect if there are any Validation messages
        /// </summary>
        public bool HasValidationMessages { get { return HasMessageType(MessageTypeEnum.Validation); } }

        /// <summary>
        /// Reflect if there are any Warning messages
        /// </summary>
        public bool HasWarningMessage { get { return HasMessageType(MessageTypeEnum.Warning);  } }

        #endregion

        #region Public Method

        /// <summary>
        /// Add Error Message to BaseResponse Object.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public BaseResponse AddErrorMessage(string text, int? status = null)
        {
            Messages.Add(new Message(MessageTypeEnum.Error, text, status));
            return this;
        }

        /// <summary>
        /// Add Exception Message to BaseResponse Object.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public BaseResponse AddExceptionMessage(string text, int? status = null)
        {
            Messages.Add(new Message(MessageTypeEnum.Exception, text, status));

            return this;
        }

        /// <summary>
        /// Add Info Message to BaseResponse Object
        /// </summary>
        /// <param name="text"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public BaseResponse AddInfoMessage(string text, int? status = null)
        {
            Messages.Add(new Message(MessageTypeEnum.Info, text, status));

            return this;
        }

        /// <summary>
        /// Add validation message to the Messages collection
        /// </summary>
        /// <param name="status"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public BaseResponse AddValidationMessage(string text, int? status = null)
        {
            Messages.Add(new Message(MessageTypeEnum.Validation, text, status));

            return this;
        }

        /// <summary>
        /// Add Warning Message to BaseResponse Object
        /// </summary>
        /// <param name="text"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public BaseResponse AddWarningMessage(string text, int? status = null)
        {
            Messages.Add(new Message(MessageTypeEnum.Warning, text, status));

            return this;
        }

        public virtual void Merge(IBaseResponse baseResponse)
        {
            this.Messages.AddRange(baseResponse.Messages);
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
