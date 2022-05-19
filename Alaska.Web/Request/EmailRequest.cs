namespace Alaska.Web.Request
{
    using System.ComponentModel.DataAnnotations;
    public class EmailRequest
    {

        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }

}
