using FluentValidation;
using PermissionManagement.Service.DTOs;

namespace PermissionManagement.Service.FluentValidation
{
    public class PermissionValidation : AbstractValidator<PermissionDto>
    {
        public PermissionValidation()
        {

            RuleFor(dto => dto.EmployeeFirstName).NotNull().WithMessage("Please add First name.");
            RuleFor(dto => dto.EmployeeLastName).NotNull().WithMessage("Please add Last name.");
            RuleFor(dto => dto.PermissionDate).NotNull().WithMessage("You must specify the date that you'd like to get the permission.");
        }
    }
}
