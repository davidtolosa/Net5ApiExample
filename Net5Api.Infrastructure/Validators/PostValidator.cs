using FluentValidation;
using Net5Api.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5Api.Infrastructure.Validators
{
    public class PostValidator : AbstractValidator<PostDTO>
    {
        public PostValidator() {
            RuleFor(post => post.Description)
                .NotNull()
                .Length(10, 500);
        }
    }
}
