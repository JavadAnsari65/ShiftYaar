using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShiftYar.Domain.Enums.ShiftModel.ShiftEnums;

namespace ShiftYar.Application.DTOs.ShiftModel.ShiftSchedulingModel
{
    /// <summary>
    /// انتساب شیفت
    /// </summary>
    public class ShiftAssignmentDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int ShiftId { get; set; }
        public ShiftLabel ShiftLabel { get; set; }
        public DateTime Date { get; set; }
        public bool IsOnCall { get; set; }
        public int SpecialtyId { get; set; }
        public string SpecialtyName { get; set; } = string.Empty;
    }
}
