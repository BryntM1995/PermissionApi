using System;

namespace PermissionManagement.Service.DTOs
{
    public class PermissionDto : BaseDto
    {
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public int PermissionTypeId { get; set; }
        public DateTime PermissionDate { get; set; }
        public string PermissionTypeName { get; set; }
    }
}
