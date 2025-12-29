using ShiftYar.Application.Common.Models.ResponseModel;
using ShiftYar.Application.DTOs.ShiftModel.ShiftSchedulingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftYar.Application.Interfaces.ShiftModel
{
    /// <summary>
    /// اینترفیس سرویس بهینه‌سازی شیفت‌بندی با الگوریتم Simulated Annealing
    /// </summary>
    public interface IShiftSchedulingService
    {
        /// <summary>
        /// اجرای الگوریتم بهینه‌سازی شیفت‌بندی
        /// </summary>
        /// <param name="request">درخواست بهینه‌سازی</param>
        /// <returns>نتیجه بهینه‌سازی</returns>
        Task<ApiResponse<ShiftSchedulingResultDto>> OptimizeShiftScheduleAsync(ShiftSchedulingRequestDto request);

        /// <summary>
        /// اجرای الگوریتم بهینه‌سازی شیفت‌بندی (نسخه داخلی با تاریخ میلادی)
        /// </summary>
        /// <param name="request">درخواست بهینه‌سازی</param>
        /// <returns>نتیجه بهینه‌سازی</returns>
        Task<ApiResponse<ShiftSchedulingResultDto>> OptimizeShiftScheduleInternalAsync(ShiftSchedulingRequestInternalDto request);


        /// <summary>
        /// دریافت آمارهای الگوریتم
        /// </summary>
        /// <param name="request">درخواست بهینه‌سازی</param>
        /// <returns>آمارهای الگوریتم</returns>
        Task<ApiResponse<object>> GetAlgorithmStatisticsAsync(ShiftSchedulingRequestDto request);

        /// <summary>
        /// اعتبارسنجی محدودیت‌های شیفت‌بندی
        /// </summary>
        /// <param name="request">درخواست بهینه‌سازی</param>
        /// <returns>نتیجه اعتبارسنجی</returns>
        Task<ApiResponse<List<string>>> ValidateConstraintsAsync(ShiftSchedulingRequestDto request);

        /// <summary>
        /// ذخیره نتیجه بهینه‌سازی در دیتابیس
        /// </summary>
        /// <param name="result">نتیجه بهینه‌سازی</param>
        /// <returns>نتیجه ذخیره</returns>
        Task<ApiResponse<string>> SaveOptimizedScheduleAsync(ShiftSchedulingResultDto result);
    }
}
