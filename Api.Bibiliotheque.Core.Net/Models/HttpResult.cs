namespace Api.Bibiliotheque.Core.Net.Models
{
    public class HttpResult<T>where T : class
    {
        public int? StatutCode { get; set; }

        public bool IsSuccess { get; set;}

        public T Data { get; set;}
    }
}
