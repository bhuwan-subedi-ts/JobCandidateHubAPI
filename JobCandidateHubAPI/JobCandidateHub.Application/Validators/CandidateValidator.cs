using FluentValidation;
using JobCandidateHub.Application.DTO;


namespace JobCandidateHub.Application.Validators
{
    public class CandidateValidator : AbstractValidator<CandidateDto>
    {
        public CandidateValidator()
        {
            // Required Fields
            RuleFor(candidate => candidate.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");

            RuleFor(candidate => candidate.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");

            RuleFor(candidate => candidate.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(candidate => candidate.Comment)
                .NotEmpty().WithMessage("Comment is required.")
                .MaximumLength(500).WithMessage("Comment cannot exceed 500 characters.");

            // Optional Fields
            RuleFor(candidate => candidate.PhoneNumber)
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Phone number must be in valid international format (e.g., +123456789).")
                .When(candidate => !string.IsNullOrEmpty(candidate.PhoneNumber));

            RuleFor(candidate => candidate.PreferredTimeToCall)
                .MaximumLength(100).WithMessage("Call time interval cannot exceed 100 characters.")
                .When(candidate => !string.IsNullOrEmpty(candidate.PreferredTimeToCall));

            RuleFor(candidate => candidate.LinkedInUrl)
                .Must(BeAValidUrl).WithMessage("LinkedIn profile URL must be a valid URL.")
                .When(candidate => !string.IsNullOrEmpty(candidate.LinkedInUrl));

            RuleFor(candidate => candidate.GitHubUrl)
                .Must(BeAValidUrl).WithMessage("GitHub profile URL must be a valid URL.")
                .When(candidate => !string.IsNullOrEmpty(candidate.GitHubUrl));
        }

        private bool BeAValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out _);
        }
    }
}
