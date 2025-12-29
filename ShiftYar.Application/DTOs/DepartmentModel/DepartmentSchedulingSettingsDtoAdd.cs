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
        public bool? ForbidDuplicateDailyAssignments { get; set; }
        public bool? EnforceMaxShiftsPerDay { get; set; }
        public bool? EnforceMinRestDays { get; set; }
        public bool? EnforceMaxConsecutiveShifts { get; set; }
        public bool? EnforceWeeklyMaxShifts { get; set; }
        public bool? EnforceNightShiftMonthlyCap { get; set; }
        public bool? EnforceSpecialtyCapacity { get; set; }

        // مقادیر عددی قوانین (اختیاری؛ هنگام فعال بودن Enforce ها اعمال می‌شوند)
        public int? MinRestDaysBetweenShifts { get; set; }
        public int? MaxConsecutiveShifts { get; set; }
        public int? MaxShiftsPerWeek { get; set; }
        public int? MaxNightShiftsPerMonth { get; set; }
        public int? MaxShiftsPerDay { get; set; }
        public int? MaxConsecutiveNightShifts { get; set; }

        public double? GenderBalanceWeight { get; set; }
        public double? SpecialtyPreferenceWeight { get; set; }
        public double? UserUnwantedShiftWeight { get; set; }
        public double? UserPreferredShiftWeight { get; set; }
        public double? WeeklyMaxWeight { get; set; }
        public double? MonthlyNightCapWeight { get; set; }

        // عدالت و چرخش
        public double? FairShiftCountBalanceWeight { get; set; }
        public double? ExtraShiftRotationWeight { get; set; }
        public double? ShiftLabelBalanceWeight { get; set; }
        public int? FairnessLookbackMonths { get; set; }

        // تنظیمات حداقل شیفت برای انواع مختلف شیفت‌گردشی
        public bool? EnforceMinimumShiftsForRotatingStaff { get; set; }
        public int? MinMorningShiftsForThreeShiftRotation { get; set; }
        public int? MinEveningShiftsForThreeShiftRotation { get; set; }
        public int? MinNightShiftsForThreeShiftRotation { get; set; }
        public int? MinFirstShiftForTwoShiftRotation { get; set; }
        public int? MinSecondShiftForTwoShiftRotation { get; set; }

        // تنظیمات شب‌دوست/شب‌گریز
        public bool? EnableNightShiftPreference { get; set; }
        public int? NightShiftPreferenceType { get; set; } // 0=شب‌دوست، 1=شب‌گریز، 2=خنثی
        public double? NightShiftPreferenceWeight { get; set; }

        // تنظیمات الزام مسئول شیفت
        public bool? RequireManagerForEveningShift { get; set; }
        public bool? RequireManagerForNightShift { get; set; }
        public double? ShiftManagerRequirementWeight { get; set; }

        // تنظیمات توزیع شیفت‌های شب باقی‌مانده بر اساس سابقه
        public bool? EnableNightShiftDistributionBySeniority { get; set; }
        public int? NightShiftDistributionType { get; set; } // 0=شب‌دوست (سابقه بیشتر اولویت), 1=شب‌گریز (سابقه کمتر اولویت), 2=خنثی
        public double? NightShiftDistributionWeight { get; set; }
        public double? SeniorityDistributionSlope { get; set; }
    }
    public class DepartmentSchedulingSettingsDtoGet : DepartmentSchedulingSettingsDtoAdd
    {
        public int Id { get; set; }
    }
}
