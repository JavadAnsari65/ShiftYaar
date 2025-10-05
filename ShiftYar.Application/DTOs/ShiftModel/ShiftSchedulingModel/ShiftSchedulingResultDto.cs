using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftYar.Application.DTOs.ShiftModel.ShiftSchedulingModel
{
    /// <summary>
    /// نتیجه بهینه‌سازی شیفت‌بندی
    /// </summary>
    public class ShiftSchedulingResultDto
    {
        public List<ShiftAssignmentDto> Assignments { get; set; } = new List<ShiftAssignmentDto>();
        public double FinalScore { get; set; }
        public int TotalIterations { get; set; }
        public TimeSpan ExecutionTime { get; set; }
        public List<string> Violations { get; set; } = new List<string>();
        public ShiftSchedulingStatisticsDto Statistics { get; set; } = new ShiftSchedulingStatisticsDto();
    }
}
