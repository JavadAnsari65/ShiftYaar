using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftYar.Application.DTOs.DepartmentModel
{
    public class DepartmentSchedulingSettingsDtoAdd
    {
        [Required]
        public int DepartmentId { get; set; }
        public bool? ForbidUnavailableDates { get; set; }
        public bool? ForbidDuplicateDailyAssignments { get; set; }
        public bool? EnforceMaxShiftsPerDay { get; set; }
        public bool? EnforceMinRestDays { get; set; }
        public bool? EnforceMaxConsecutiveShifts { get; set; }
        public bool? EnforceWeeklyMaxShifts { get; set; }
        public bool? EnforceNightShiftMonthlyCap { get; set; }
        public bool? EnforceSpecialtyCapacity { get; set; }

        public double? GenderBalanceWeight { get; set; }
        public double? SpecialtyPreferenceWeight { get; set; }
        public double? UserUnwantedShiftWeight { get; set; }
        public double? UserPreferredShiftWeight { get; set; }
        public double? WeeklyMaxWeight { get; set; }
        public double? MonthlyNightCapWeight { get; set; }
    }

    public class DepartmentSchedulingSettingsDtoGet : DepartmentSchedulingSettingsDtoAdd
    {
        public int Id { get; set; }
    }
}
