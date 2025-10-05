using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShiftYar.Domain.Enums.ShiftModel.ShiftEnums;

namespace ShiftYar.Application.DTOs.ShiftModel.ShiftSchedulingModel
{
    /// <summary>
    /// آمارهای شیفت‌بندی
    /// </summary>
    public class ShiftSchedulingStatisticsDto
    {
        public int TotalShifts { get; set; }
        public int TotalUsers { get; set; }
        public int SatisfiedConstraints { get; set; }
        public int ViolatedConstraints { get; set; }
        public double AverageShiftsPerUser { get; set; }
        public Dictionary<ShiftLabel, int> ShiftsByType { get; set; } = new Dictionary<ShiftLabel, int>();
        public Dictionary<int, int> ShiftsByUser { get; set; } = new Dictionary<int, int>();
    }
}
