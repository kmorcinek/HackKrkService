namespace NancyTest
{
    public class Error
    {
        public int HttpCode { get; set; }
        public string ErrorMessage { get; set; }

        public Error(int httpCode, string errorMessage)
        {
            HttpCode = httpCode;
            ErrorMessage = errorMessage;
        }
    }
}