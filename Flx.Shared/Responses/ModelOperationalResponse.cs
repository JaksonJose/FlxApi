
namespace Flx.Shared.Responses
{
    public class ModelOperationalResponse : BaseResponse
    {
        public ModelOperationalResponse() : base()
        {
        }

        /// <summary>
        /// How mwany row this affected
        /// </summary>
        /// <param name="operationCount"></param>
        public ModelOperationalResponse(int operationCount) : base()
        {
            OperationCount = operationCount;
        }

        public int OperationCount { get; set; } = 0;

        public void Merge(ModelOperationalResponse response)
        {
            base.Merge(response);
            OperationCount += response.OperationCount;
        }
    }
}