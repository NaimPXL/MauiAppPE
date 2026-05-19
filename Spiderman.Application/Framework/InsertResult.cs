namespace Team05.Application.Framework
{
    public class InsertResult<T> : BaseResult
    {
        public T? Data { get; set; }
    }
}
