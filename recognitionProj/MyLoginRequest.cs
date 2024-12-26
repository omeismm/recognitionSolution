// File: Models/MyLoginRequest.cs

namespace recognitionProj.Models
{
    public class MyLoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string VerificationCode { get; set; }
    }
}
