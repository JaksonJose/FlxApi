using Flx.Shared.Responses.IResponses;

namespace Flx.Shared.Responses
{
     public class InquiryResponse<T> : BaseResponse, IInquiryResponse<T>
    {
        /// <summary>
        /// Empty constructor
        /// </summary>
        public InquiryResponse() : base() 
        { 
        }

        /// <summary>
        /// Constructor that that add a T list to response data.
        /// </summary>
        /// <param name="item"></param>
        public InquiryResponse(List<T> item) : base()
        {
            this.ResponseData = item;
        }

        /// <summary>
        /// Constructor that add an object to a ResponseData list.
        /// </summary>
        /// <param name="item"></param>
        public InquiryResponse(T item) : base()
        {
            this.ResponseData.Add(item);
        }
        public List<T> ResponseData { get; set; } = new List<T>();
    }
}
