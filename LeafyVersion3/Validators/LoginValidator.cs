using FluentValidation;
using LeafyVersion3.Contracts.Requests;
using LeafyVersion3.Infrastructure.Repositories;

namespace LeafyVersion3.Validators;

public class LoginValidator : AbstractValidator<SignUpRequest>
{
    public LoginValidator(IUserRepository userRepository)
    {
        // Validator for Username
        RuleFor(request => request.Username)
            .NotEmpty()
            .When(request => request.Username != null)  
            .Matches(@"^[a-zA-Z\s]+$")
            .WithMessage("Username must only contain letters and not symbols or numbers.")
            .MustAsync(async (username, cancellation) => !await userRepository.UsernameExistsAsync(username))
              .When(request => !string.IsNullOrEmpty(request.Username))  
            .WithMessage("Username already exists.");

        // Validator for Password
        RuleFor(request => request.Password)
            .NotEmpty()
            .MinimumLength(8)
            .When(request => !string.IsNullOrEmpty(request.Password))  
            .WithMessage("Password must be at least 8 characters long.");
    }
}

