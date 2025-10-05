using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftYar.Application.DTOs.ShiftModel.ShiftSchedulingModel
{
    /// <summary>
    /// DTO برای درخواست بهینه‌سازی شیفت‌بندی
    /// </summary>
    public class ShiftSchedulingRequestDto
    {
        [Required]
        public int DepartmentId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public List<ShiftSchedulingConstraintDto> Constraints { get; set; } = new List<ShiftSchedulingConstraintDto>();

        public ShiftSchedulingParametersDto Parameters { get; set; } = new ShiftSchedulingParametersDto();
    }
}
