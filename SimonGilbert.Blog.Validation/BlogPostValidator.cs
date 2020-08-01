using System;
using FluentValidation;
using FluentValidation.Results;
using SimonGilbert.Blog.Models;

namespace SimonGilbert.Blog.Validation
{
    public class BlogPostValidator : AbstractValidator<BlogPost>
    {
        public BlogPostValidator()
        {
            RuleFor(m => m.UserAccountId).NotNull().WithMessage("Please specify a userAccountId.");

            RuleFor(m => m.Title).NotNull().WithMessage("Please specify a title.");

            RuleFor(m => m.Description).NotNull().WithMessage("Please specify a description.");
        }

        protected override bool PreValidate(ValidationContext<BlogPost> context, ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please submit a non-null model."));

                return false;
            }
            return true;
        }
    }
}
