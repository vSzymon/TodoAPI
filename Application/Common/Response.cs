namespace TodoAPI.Application.Common
{
    public record Response<T>
    {
        public Response(T content)
        {
            Content = content;
            ServerTimeUTC = DateTime.UtcNow;
        }
        public Response(IReadOnlyCollection<string> errors)
        {
            Errors = errors;
            ServerTimeUTC = DateTime.UtcNow;
        }
        public DateTime ServerTimeUTC { get;}
        public IReadOnlyCollection<string> Errors { get; init; }
        public T? Content { get; init; }
    }
}
