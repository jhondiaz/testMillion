using System.ComponentModel;

namespace TestMillion.DTOs
{
    public class LogInDTO
    {
        [DefaultValue("User@test.com")]
        public string User { get; set; }

        [DefaultValue("$123456789")]
        public string Password { get; set; }

    }
}
