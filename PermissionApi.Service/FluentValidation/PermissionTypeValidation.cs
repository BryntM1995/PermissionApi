using FluentValidation;
using PermissionManagement.Model.Entities;
using PermissionManagement.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PermissionManagement.Service.FluentValidation
{
    public class PermissionTypeValidation : AbstractValidator<PermissionTypeDto>
    {
        public PermissionTypeValidation()
        {
            RuleFor(dto => dto.Description).NotNull().WithMessage("Please add a description.");
        }
    }
}
