namespace Team05.Application.Framework
{
    public class SelectListResult<T> : BaseResult
    {
        public IEnumerable<T> Rows { get; set; }
    }
}
