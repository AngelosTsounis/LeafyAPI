using FluentValidation;
using LeafyVersion3.Contracts.Requests;
using LeafyVersion3.Infrastructure.Repositories;

namespace LeafyVersion3.Validators;

public class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;

        RuleFor(request => request.Username)
            .NotEmpty()
            .When(request => !string.IsNullOrWhiteSpace(request.Username))
            .Matches(@"^[a-zA-Z\s]+$")
            .WithMessage("Username must only contain letters and not symbols or numbers.")
            .MustAsync(async (request, username, cancellation) =>
            {
                var user = await _userRepository.GetUserByUsernameAsync(username);
                return user == null || user.Id == request.UserId;
            })
            .WithMessage("Username is already taken.");
    }
}
