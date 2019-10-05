namespace UniqueWordsApi.Dtos
{
    /// <summary>
    /// This DTO object defines a request.
    /// </summary>
    public class Request
    {
        /// <summary>
        /// This property defines the request value.
        /// This property must be suplied.
        /// </summary>
        public string text { get; set; }
    }
}
