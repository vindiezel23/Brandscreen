namespace Brandscreen.Core.Services.Creatives.Vast
{
    public class VastValidationResult
    {
        public VastValidationResult(bool success, string error = null)
        {
            Success = success;
            Error = error;
        }

        public bool Success { get; set; }
        public string Error { get; set; }
    }
}