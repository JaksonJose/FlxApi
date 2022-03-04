using Flx.Domain.Responses.IResponses;

namespace Flx.Domain.Responses
{
     public class InquiryResponse<T> : Response, IInquiryResponse<T>
    {
        public InquiryResponse() : base() { }
        public InquiryResponse(List<T> item) : base()
        {
            this.ResponseData = item;
        }
        public List<T> ResponseData { get; set; } = new List<T>();
    }
}
