using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGateway.Application.Commands.CreateService
{
    public class CreateServiceCommandValidator: AbstractValidator<CreateServiceCommand>
    {
        public CreateServiceCommandValidator()
        {
            RuleFor(u => u.DownstreamPathTemplate)
              .NotEmpty().WithMessage("DownstreamPathTemplate field is required");

            RuleFor(u => u.UpstreamPathTemplate)
                   .NotEmpty().WithMessage("this field is required");

            RuleFor(u => u.Port)
                 .NotEmpty().WithMessage("this field is required");

            RuleFor(u => u.Host)
              .NotEmpty().WithMessage("this field is required");


            RuleFor(u => u.ServiceName)
              .NotEmpty().WithMessage("ServiceName field is required");

            RuleFor(u => u.DownstreamScheme)
             .NotEmpty().WithMessage("DownstreamScheme field is required");
        }
    }
}
