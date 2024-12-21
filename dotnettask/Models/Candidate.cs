using System.ComponentModel.DataAnnotations;

namespace CandidateHubAPI.Models
{
    public class Candidate
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public required string FirstName { get; set; }
        
        [Required]
        public required string LastName { get; set; }
        
        [Required, EmailAddress]
        public required string Email { get; set; }
        
        public string? PhoneNumber { get; set; }
        
        public string? PreferredCallTime { get; set; }
        
        public string? LinkedInURL { get; set; }
        
        public string? GitHubURL { get; set; }
        
        [Required]
        public required string Comment { get; set; }
    }
}