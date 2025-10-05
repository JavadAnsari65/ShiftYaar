using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShiftYar.Api.Filters;
using ShiftYar.Application.Common.Models.ResponseModel;
using ShiftYar.Application.DTOs.ShiftModel.ShiftSchedulingModel;
using ShiftYar.Application.Interfaces.ShiftModel;
using ShiftYar.Domain.Entities.UserModel;
using ShiftYar.Infrastructure.Persistence.AppDbContext;

namespace ShiftYar.Api.Controllers.ShiftModel
{
    /// <summary>
    /// کنترلر مدیریت بهینه‌سازی شیفت‌بندی با الگوریتم Simulated Annealing
    /// </summary>
    [Authorize]
    public class ShiftSchedulingController : BaseController
    {
        private readonly IShiftSchedulingService _shiftSchedulingService;

        public ShiftSchedulingController(IShiftSchedulingService shiftSchedulingService, ShiftYarDbContext context) : base(context)
        {
            _shiftSchedulingService = shiftSchedulingService;
        }

        /// <summary>
        /// اجرای الگوریتم بهینه‌سازی شیفت‌بندی
        /// </summary>
        /// <param name="request">درخواست بهینه‌سازی</param>
        /// <returns>نتیجه بهینه‌سازی</returns>
        [HttpPost("optimize")]
        [Authorize(Roles = "Admin,Supervisor")]
        public async Task<IActionResult> OptimizeShiftSchedule([FromBody] ShiftSchedulingRequestDto request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ApiResponse<ShiftSchedulingResultDto>.Fail("Invalid request data"));
                }

                var result = await _shiftSchedulingService.OptimizeShiftScheduleAsync(request);

                if (result.IsSuccess)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<ShiftSchedulingResultDto>.Fail($"Internal server error: {ex.Message}"));
            }
        }

        /// <summary>
        /// دریافت آمارهای الگوریتم
        /// </summary>
        /// <param name="request">درخواست بهینه‌سازی</param>
        /// <returns>آمارهای الگوریتم</returns>
        [HttpPost("statistics")]
        [Authorize(Roles = "Admin,Supervisor")]
        public async Task<IActionResult> GetAlgorithmStatistics([FromBody] ShiftSchedulingRequestDto request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ApiResponse<object>.Fail("Invalid request data"));
                }

                var result = await _shiftSchedulingService.GetAlgorithmStatisticsAsync(request);

                if (result.IsSuccess)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<object>.Fail($"Internal server error: {ex.Message}"));
            }
        }

        /// <summary>
        /// اعتبارسنجی محدودیت‌های شیفت‌بندی
        /// </summary>
        /// <param name="request">درخواست بهینه‌سازی</param>
        /// <returns>نتیجه اعتبارسنجی</returns>
        [HttpPost("validate")]
        [Authorize(Roles = "Admin,Supervisor")]
        public async Task<IActionResult> ValidateConstraints([FromBody] ShiftSchedulingRequestDto request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ApiResponse<List<string>>.Fail("Invalid request data"));
                }

                var result = await _shiftSchedulingService.ValidateConstraintsAsync(request);

                if (result.IsSuccess)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<List<string>>.Fail($"Internal server error: {ex.Message}"));
            }
        }

        /// <summary>
        /// ذخیره نتیجه بهینه‌سازی در دیتابیس
        /// </summary>
        /// <param name="result">نتیجه بهینه‌سازی</param>
        /// <returns>نتیجه ذخیره</returns>
        [HttpPost("save")]
        [Authorize(Roles = "Admin,Supervisor")]
        public async Task<IActionResult> SaveOptimizedSchedule([FromBody] ShiftSchedulingResultDto result)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ApiResponse<string>.Fail("Invalid request data"));
                }

                var saveResult = await _shiftSchedulingService.SaveOptimizedScheduleAsync(result);

                if (saveResult.IsSuccess)
                {
                    return Ok(saveResult);
                }
                else
                {
                    return BadRequest(saveResult);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<string>.Fail($"Internal server error: {ex.Message}"));
            }
        }

        /// <summary>
        /// اجرای کامل فرآیند بهینه‌سازی و ذخیره
        /// </summary>
        /// <param name="request">درخواست بهینه‌سازی</param>
        /// <returns>نتیجه کامل</returns>
        [HttpPost("optimize-and-save")]
        [Authorize(Roles = "Admin,Supervisor")]
        public async Task<IActionResult> OptimizeAndSave([FromBody] ShiftSchedulingRequestDto request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ApiResponse<object>.Fail("Invalid request data"));
                }

                // اعتبارسنجی اولیه
                var validationResult = await _shiftSchedulingService.ValidateConstraintsAsync(request);
                if (!validationResult.IsSuccess || validationResult.Data.Count > 0)
                {
                    return BadRequest(ApiResponse<object>.Fail($"Validation failed: {string.Join(", ", validationResult.Data)}"));
                }

                // اجرای بهینه‌سازی
                var optimizationResult = await _shiftSchedulingService.OptimizeShiftScheduleAsync(request);
                if (!optimizationResult.IsSuccess)
                {
                    return BadRequest(optimizationResult);
                }

                // ذخیره نتیجه
                var saveResult = await _shiftSchedulingService.SaveOptimizedScheduleAsync(optimizationResult.Data);
                if (!saveResult.IsSuccess)
                {
                    return BadRequest(saveResult);
                }

                return Ok(ApiResponse<object>.Success(new
                {
                    OptimizationResult = optimizationResult.Data,
                    SaveResult = saveResult.Data,
                    Message = "Shift schedule optimized and saved successfully"
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<object>.Fail($"Internal server error: {ex.Message}"));
            }
        }
    }
}
