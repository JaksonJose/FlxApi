namespace Flx.Shared.Models
{
    public class FilterDescriptor
    {
        public FilterDescriptor()
        {
        }

        /// <summary>
        /// Name of property
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// The value to be used depending on criteria
        /// </summary>
        public object Value { get; set; }
    }
}
