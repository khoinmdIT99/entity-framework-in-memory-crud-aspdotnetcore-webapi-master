using System.Collections.Generic;
using FluentValidation.Results;
using SimonGilbert.Blog.Models;

namespace SimonGilbert.Blog.Validation
{
    public static class ValidationExtensions
    {
        public static bool IsValid(this BlogPost blogPost, out IEnumerable<string> errors)
        {
            var validator = new BlogPostValidator();

            var validationResult = validator.Validate(blogPost);

            errors = AggregateErrors(validationResult);

            return validationResult.IsValid;
        }

        private static List<string> AggregateErrors(ValidationResult validationResult)
        {
            var errors = new List<string>();

            if (!validationResult.IsValid)
                foreach (var error in validationResult.Errors)
                    errors.Add(error.ErrorMessage);

            return errors;
        }
    }
}
