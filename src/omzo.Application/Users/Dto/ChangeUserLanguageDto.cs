using System.ComponentModel.DataAnnotations;

namespace omzo.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}