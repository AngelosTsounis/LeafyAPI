using FluentValidation;
using LeafyVersion3.Contracts.Requests;

namespace LeafyVersion3.Validators;

public class UpdateRecyclingActivityValidator : AbstractValidator<UpdateRecyclingActivityRequest>
{
    public UpdateRecyclingActivityValidator()
    {
        // Validation for Location
        RuleFor(request => request.Location)
        .NotNull()
        .NotEmpty()
        .Matches(@"^[a-zA-Z\s]+$")
            .WithMessage("Location must be a string containing only letters and spaces.");


        // Validation for MaterialType
        RuleFor(request => request.MaterialType)
            .NotNull()
            .NotEmpty()
            .Must(type => new[] { "Glass", "Paper", "Plastic", "Metal", "glass", "paper", "plastic", "metal" }.Contains(type))
            .WithMessage("MaterialType must be one of the following: Glass, Paper, Plastic, or Metal.");

        // Validation for Quantity
        RuleFor(request => request.Quantity)
            .GreaterThan(0)
            .WithMessage("Quantity must be a positive number.");
    }

}

