using Flx.Shared.Responses.IResponses;

namespace Flx.Shared.Responses
{
     public class InquiryResponse<T> : Response, IInquiryResponse<T>
    {
        public InquiryResponse() : base() { }
        public InquiryResponse(List<T> item) : base()
        {
            this.ResponseData = item;
        }

        public InquiryResponse(T item) : base()
        {
            this.ResponseData.Add(item);
        }
        public List<T> ResponseData { get; set; } = new List<T>();
    }
}
