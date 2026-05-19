namespace Team05.Application.Framework
{
    public class SelectResult<T> : BaseResult
    {
        public T? Data { get; set; }
    }
}
