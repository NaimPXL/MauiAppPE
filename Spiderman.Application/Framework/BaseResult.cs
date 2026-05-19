namespace Team05.Application.Framework
{
    public class BaseResult
    {
        public List<string> Errors { get; set; } = new List<string>();
        public bool RequestSucceeded { get; set; }
        public BaseResult()
        {
            RequestSucceeded = true;
        }
    }
}
