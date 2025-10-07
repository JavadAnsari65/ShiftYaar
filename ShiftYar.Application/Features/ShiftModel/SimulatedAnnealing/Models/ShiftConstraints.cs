using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShiftYar.Domain.Enums.ShiftModel.ShiftEnums;
using static ShiftYar.Domain.Enums.UserModel.UserEnums;

namespace ShiftYar.Application.Features.ShiftModel.SimulatedAnnealing.Models
{
    /// <summary>
    /// محدودیت‌های شیفت‌بندی
    /// </summary>
    public class ShiftConstraints
    {
        public int DepartmentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<UserConstraint> UserConstraints { get; set; } = new List<UserConstraint>();
        public List<ShiftRequirement> ShiftRequirements { get; set; } = new List<ShiftRequirement>();
        public GlobalConstraints GlobalConstraints { get; set; } = new GlobalConstraints();
    }

    /// <summary>
    /// محدودیت‌های کاربر
    /// </summary>
    public class UserConstraint
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public UserGender Gender { get; set; }
        public int SpecialtyId { get; set; }
        public string SpecialtyName { get; set; } = string.Empty;
        public List<DateTime> UnavailableDates { get; set; } = new List<DateTime>();      //تاریخ‌های غیرقابل دسترس
        public List<ShiftLabel> PreferredShifts { get; set; } = new List<ShiftLabel>();   //شیفت‌های ترجیحی
        public List<ShiftLabel> UnwantedShifts { get; set; } = new List<ShiftLabel>();    //شیفت‌های ناخواسته
        public int MaxConsecutiveShifts { get; set; } = 3;    //حداکثر شیفت‌های متوالی
        public int MinRestDaysBetweenShifts { get; set; } = 1;  //حداقل استراحت بین شیفت‌ها
        public int MaxShiftsPerWeek { get; set; } = 5;   //حداکثر شیفت در هر هفته
        public int MaxNightShiftsPerMonth { get; set; } = 8;    //حداکثر شیفت شب در ماه
        public bool CanBeShiftManager { get; set; }
        public ShiftTypes ShiftType { get; set; }
        public ShiftSubTypes ShiftSubType { get; set; }
        public TwoShiftRotationPattern? TwoShiftRotationPattern { get; set; }
    }

    /// <summary>
    /// نیازمندی‌های شیفت
    /// </summary>
    public class ShiftRequirement
    {
        public int ShiftId { get; set; }
        public ShiftLabel ShiftLabel { get; set; }
        public int DepartmentId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public List<SpecialtyRequirement> SpecialtyRequirements { get; set; } = new List<SpecialtyRequirement>();
    }

    /// <summary>
    /// نیازمندی تخصص در شیفت
    /// </summary>
    public class SpecialtyRequirement
    {
        public int SpecialtyId { get; set; }
        public string SpecialtyName { get; set; } = string.Empty;
        public int RequiredMaleCount { get; set; }
        public int RequiredFemaleCount { get; set; }
        public int RequiredTotalCount { get; set; }
        public int OnCallMaleCount { get; set; }
        public int OnCallFemaleCount { get; set; }
        public int OnCallTotalCount { get; set; }
    }

    /// <summary>
    /// محدودیت‌های سراسری
    /// </summary>
    public class GlobalConstraints
    {
        public bool AllowConsecutiveNightShifts { get; set; } = false;  //اجازه شیفت‌های شبانه متوالی
        public int MaxConsecutiveNightShifts { get; set; } = 2; //حداکثر شیفت‌های شب متوالی
        public bool RequireGenderBalance { get; set; } = true;  //نیازمند تعادل جنسیتی
        public double MinGenderBalanceRatio { get; set; } = 0.3; // حداقل 30% از هر جنسیت
        public bool PreferSpecialtyMatch { get; set; } = true;  //مطابقت با تخصص
        public int MaxShiftsPerDay { get; set; } = 1;   //حداکثر شیفت در روز
        public bool AllowWeekendShifts { get; set; } = true;    //مجاز کردن شیفت‌های آخر هفته
        public bool RequireShiftManager { get; set; } = true;   //نیاز به مدیر شیفت
    }

    /// <summary>
    /// پارامترهای الگوریتم Simulated Annealing
    /// </summary>
    public class SimulatedAnnealingParameters
    {
        public double InitialTemperature { get; set; } = 1000.0;
        public double FinalTemperature { get; set; } = 0.1;
        public double CoolingRate { get; set; } = 0.95;
        public int MaxIterations { get; set; } = 10000;
        public int MaxIterationsWithoutImprovement { get; set; } = 1000;
        public int MaxNeighborsPerIteration { get; set; } = 10;
        public double PenaltyWeight { get; set; } = 1000.0; // وزن جریمه برای نقض محدودیت‌ها
    }

    /// <summary>
    /// آمارهای الگوریتم
    /// </summary>
    public class AlgorithmStatistics
    {
        public int TotalIterations { get; set; }
        public int AcceptedMoves { get; set; }
        public int RejectedMoves { get; set; }
        public double BestScore { get; set; } = double.MaxValue;
        public double CurrentScore { get; set; } = double.MaxValue;
        public double CurrentTemperature { get; set; }
        public TimeSpan ExecutionTime { get; set; }
        public List<double> ScoreHistory { get; set; } = new List<double>();
        public List<double> TemperatureHistory { get; set; } = new List<double>();
    }
}
