using ShiftYar.Domain.Entities.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftYar.Domain.Entities.DepartmentModel
{
    public class DepartmentSchedulingSettings : BaseEntity
    {
        [Key]
        public int? Id { get; set; } // شناسه تنظیمات زمان‌بندی دپارتمان

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; } // شناسه دپارتمان
        public Department? Department { get; set; } // دپارتمان مربوطه

        //قوانین سخت و غیرقابل نقض
        public bool? ForbidUnavailableDates { get; set; } // ممنوعیت انتساب در تاریخ‌های غیرمجاز
        public bool? ForbidDuplicateDailyAssignments { get; set; } // ممنوعیت بیش از یک شیفت در روز برای کاربر
        public bool? EnforceMaxShiftsPerDay { get; set; } // اعمال حداکثر شیفت روزانه مطابق تنظیمات سراسری
        public bool? EnforceMinRestDays { get; set; } // اعمال حداقل روزهای استراحت بین شیفت‌ها
        public bool? EnforceMaxConsecutiveShifts { get; set; } // اعمال حداکثر شیفت‌های متوالی
        public bool? EnforceWeeklyMaxShifts { get; set; } // اعمال سقف هفتگی شیفت‌ها
        public bool? EnforceNightShiftMonthlyCap { get; set; } // اعمال سقف شیفت شب ماهانه
        public bool? EnforceSpecialtyCapacity { get; set; } // جلوگیری از تجاوز از ظرفیت تخصص/شیفت/روز

        //قوانین نرم دارای وزن
        public double? GenderBalanceWeight { get; set; } // وزن تعادل جنسیتی
        public double? SpecialtyPreferenceWeight { get; set; } // وزن ترجیح مطابقت تخصص
        public double? UserUnwantedShiftWeight { get; set; } // وزن جریمه شیفت‌های ناخواسته کاربر
        public double? UserPreferredShiftWeight { get; set; } // وزن پاداش شیفت‌های ترجیحی کاربر
        public double? WeeklyMaxWeight { get; set; } // وزن سقف هفتگی شیفت‌ها (نرم)
        public double? MonthlyNightCapWeight { get; set; } // وزن سقف شیفت شب ماهانه (نرم)
    }
}
