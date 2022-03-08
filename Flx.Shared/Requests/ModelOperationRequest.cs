
namespace Flx.Shared.Requests
{
    public class ModelOperationRequest<T>
    {
        public ModelOperationRequest()
        {
        }

        public ModelOperationRequest(T model)
        {
            this.Model = model;
        }

        public T Model { get; set; }
    }
}
