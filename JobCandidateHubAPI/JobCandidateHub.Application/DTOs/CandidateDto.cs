using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidateHub.Application.DTO
{
    public class CandidateDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }  
        public string PreferredTimeToCall { get; set; }
        public string LinkedInUrl { get; set; }
        public string GitHubUrl { get; set; }
        [Required]
        public string Comment { get; set; }
    }
}
