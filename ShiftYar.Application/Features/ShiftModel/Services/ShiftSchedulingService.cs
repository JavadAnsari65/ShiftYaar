using Microsoft.Extensions.Logging;
using ShiftYar.Application.Common.Models.ResponseModel;
using ShiftYar.Application.DTOs.ShiftModel.ShiftSchedulingModel;
using ShiftYar.Application.Features.ShiftModel.SimulatedAnnealing.Models;
using ShiftYar.Application.Features.ShiftModel.SimulatedAnnealing;
using ShiftYar.Application.Interfaces.Persistence;
using ShiftYar.Application.Interfaces.ShiftModel;
using ShiftYar.Domain.Entities.DepartmentModel;
using ShiftYar.Domain.Entities.ShiftModel;
using ShiftYar.Domain.Entities.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShiftYar.Domain.Enums.ShiftModel.ShiftEnums;
using static ShiftYar.Domain.Enums.UserModel.UserEnums;

namespace ShiftYar.Application.Features.ShiftModel.Services
{
    /// <summary>
    /// سرویس بهینه‌سازی شیفت‌بندی با الگوریتم Simulated Annealing
    /// </summary>
    public class ShiftSchedulingService : IShiftSchedulingService
    {
        private readonly IEfRepository<User> _userRepository;
        private readonly IEfRepository<Shift> _shiftRepository;
        private readonly IEfRepository<Department> _departmentRepository;
        private readonly IEfRepository<Specialty> _specialtyRepository;
        private readonly IEfRepository<ShiftRequiredSpecialty> _shiftRequiredSpecialtyRepository;
        private readonly IEfRepository<ShiftAssignment> _shiftAssignmentRepository;
        private readonly ILogger<ShiftSchedulingService> _logger;

        public ShiftSchedulingService(
            IEfRepository<User> userRepository,
            IEfRepository<Shift> shiftRepository,
            IEfRepository<Department> departmentRepository,
            IEfRepository<Specialty> specialtyRepository,
            IEfRepository<ShiftRequiredSpecialty> shiftRequiredSpecialtyRepository,
            IEfRepository<ShiftAssignment> shiftAssignmentRepository,
            ILogger<ShiftSchedulingService> logger)
        {
            _userRepository = userRepository;
            _shiftRepository = shiftRepository;
            _departmentRepository = departmentRepository;
            _specialtyRepository = specialtyRepository;
            _shiftRequiredSpecialtyRepository = shiftRequiredSpecialtyRepository;
            _shiftAssignmentRepository = shiftAssignmentRepository;
            _logger = logger;
        }

        /// <summary>
        /// اجرای الگوریتم بهینه‌سازی شیفت‌بندی
        /// </summary>
        public async Task<ApiResponse<ShiftSchedulingResultDto>> OptimizeShiftScheduleAsync(ShiftSchedulingRequestDto request)
        {
            try
            {
                _logger.LogInformation("Starting shift scheduling optimization for department {DepartmentId}", request.DepartmentId);

                // بارگذاری داده‌های مورد نیاز
                var constraints = await LoadConstraintsAsync(request);
                if (constraints == null)
                {
                    return ApiResponse<ShiftSchedulingResultDto>.Fail("Failed to load constraints");
                }

                // ایجاد پارامترهای الگوریتم
                var parameters = new SimulatedAnnealingParameters
                {
                    InitialTemperature = request.Parameters.InitialTemperature,
                    FinalTemperature = request.Parameters.FinalTemperature,
                    CoolingRate = request.Parameters.CoolingRate,
                    MaxIterations = request.Parameters.MaxIterations,
                    MaxIterationsWithoutImprovement = request.Parameters.MaxIterationsWithoutImprovement
                };

                // اجرای الگوریتم
                var scheduler = new SimulatedAnnealingScheduler(constraints, parameters);
                var solution = scheduler.Optimize();

                // تبدیل نتیجه به DTO
                var result = await ConvertSolutionToResultAsync(solution, constraints);

                _logger.LogInformation("Shift scheduling optimization completed. Final score: {Score}, Iterations: {Iterations}",
                    result.FinalScore, result.TotalIterations);

                return ApiResponse<ShiftSchedulingResultDto>.Success(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during shift scheduling optimization");
                return ApiResponse<ShiftSchedulingResultDto>.Fail($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// دریافت آمارهای الگوریتم
        /// </summary>
        public async Task<ApiResponse<object>> GetAlgorithmStatisticsAsync(ShiftSchedulingRequestDto request)
        {
            try
            {
                var constraints = await LoadConstraintsAsync(request);
                if (constraints == null)
                {
                    return ApiResponse<object>.Fail("Failed to load constraints");
                }

                var parameters = new SimulatedAnnealingParameters
                {
                    InitialTemperature = request.Parameters.InitialTemperature,
                    FinalTemperature = request.Parameters.FinalTemperature,
                    CoolingRate = request.Parameters.CoolingRate,
                    MaxIterations = request.Parameters.MaxIterations,
                    MaxIterationsWithoutImprovement = request.Parameters.MaxIterationsWithoutImprovement
                };

                var scheduler = new SimulatedAnnealingScheduler(constraints, parameters);
                var solution = scheduler.Optimize();
                var statistics = scheduler.GetStatistics();

                return ApiResponse<object>.Success(new
                {
                    TotalIterations = statistics.TotalIterations,
                    AcceptedMoves = statistics.AcceptedMoves,
                    RejectedMoves = statistics.RejectedMoves,
                    BestScore = statistics.BestScore,
                    ExecutionTime = statistics.ExecutionTime,
                    ScoreHistory = statistics.ScoreHistory,
                    TemperatureHistory = statistics.TemperatureHistory
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting algorithm statistics");
                return ApiResponse<object>.Fail($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// اعتبارسنجی محدودیت‌های شیفت‌بندی
        /// </summary>
        public async Task<ApiResponse<List<string>>> ValidateConstraintsAsync(ShiftSchedulingRequestDto request)
        {
            try
            {
                var validationErrors = new List<string>();

                // اعتبارسنجی تاریخ‌ها
                if (request.StartDate >= request.EndDate)
                {
                    validationErrors.Add("Start date must be before end date");
                }

                if (request.EndDate < DateTime.Today)
                {
                    validationErrors.Add("End date cannot be in the past");
                }

                // اعتبارسنجی دپارتمان
                var department = await _departmentRepository.GetByIdAsync(request.DepartmentId);
                if (department == null)
                {
                    validationErrors.Add("Department not found");
                }

                // اعتبارسنجی پارامترهای الگوریتم
                if (request.Parameters.InitialTemperature <= 0)
                {
                    validationErrors.Add("Initial temperature must be positive");
                }

                if (request.Parameters.FinalTemperature <= 0)
                {
                    validationErrors.Add("Final temperature must be positive");
                }

                if (request.Parameters.CoolingRate <= 0 || request.Parameters.CoolingRate >= 1)
                {
                    validationErrors.Add("Cooling rate must be between 0 and 1");
                }

                if (request.Parameters.MaxIterations <= 0)
                {
                    validationErrors.Add("Max iterations must be positive");
                }

                // اعتبارسنجی محدودیت‌های کاربران
                foreach (var constraint in request.Constraints)
                {
                    var user = await _userRepository.GetByIdAsync(constraint.UserId);
                    if (user == null)
                    {
                        validationErrors.Add($"User with ID {constraint.UserId} not found");
                    }

                    if (constraint.MaxConsecutiveShifts <= 0)
                    {
                        validationErrors.Add($"Max consecutive shifts for user {constraint.UserId} must be positive");
                    }

                    if (constraint.MaxShiftsPerWeek <= 0 || constraint.MaxShiftsPerWeek > 7)
                    {
                        validationErrors.Add($"Max shifts per week for user {constraint.UserId} must be between 1 and 7");
                    }
                }

                return ApiResponse<List<string>>.Success(validationErrors);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during constraint validation");
                return ApiResponse<List<string>>.Fail($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// ذخیره نتیجه بهینه‌سازی در دیتابیس
        /// </summary>
        public async Task<ApiResponse<string>> SaveOptimizedScheduleAsync(ShiftSchedulingResultDto result)
        {
            try
            {
                _logger.LogInformation("Saving optimized schedule with {Count} assignments", result.Assignments.Count);

                // حذف انتساب‌های قبلی برای بازه زمانی مشخص
                var startDate = result.Assignments.Min(a => a.Date);
                var endDate = result.Assignments.Max(a => a.Date);

                // TODO: پیاده‌سازی حذف انتساب‌های قبلی

                // ذخیره انتساب‌های جدید
                foreach (var assignment in result.Assignments)
                {
                    var shiftAssignment = new ShiftAssignment
                    {
                        UserId = assignment.UserId,
                        ShiftId = assignment.ShiftId,
                        IsOnCall = assignment.IsOnCall,
                        Notes = "Generated by Simulated Annealing Algorithm"
                    };

                    await _shiftAssignmentRepository.AddAsync(shiftAssignment);
                }

                await _shiftAssignmentRepository.SaveAsync();

                _logger.LogInformation("Successfully saved {Count} shift assignments", result.Assignments.Count);

                return ApiResponse<string>.Success("Schedule saved successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while saving optimized schedule");
                return ApiResponse<string>.Fail($"Error: {ex.Message}");
            }
        }

        #region Private Methods

        /// <summary>
        /// بارگذاری محدودیت‌ها از دیتابیس
        /// </summary>
        private async Task<ShiftConstraints> LoadConstraintsAsync(ShiftSchedulingRequestDto request)
        {
            try
            {
                var constraints = new ShiftConstraints
                {
                    DepartmentId = request.DepartmentId,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate
                };

                // بارگذاری کاربران دپارتمان
                var users = await _userRepository.GetByFilterAsync(
                    filter: null,
                    includes: new[] { "Department", "Specialty" }
                );

                var departmentUsers = users.Items
                    .Where(u => u.DepartmentId == request.DepartmentId && u.IsActive == true)
                    .ToList();

                foreach (var user in departmentUsers)
                {
                    var userConstraint = new UserConstraint
                    {
                        UserId = user.Id ?? 0,
                        UserName = user.FullName ?? "",
                        Gender = user.Gender ?? UserGender.Male,
                        SpecialtyId = user.SpecialtyId ?? 0,
                        SpecialtyName = user.Specialty?.SpecialtyName ?? "",
                        CanBeShiftManager = user.CanBeShiftManager ?? false,
                        ShiftType = user.ShiftType ?? ShiftTypes.FixedShift,
                        ShiftSubType = user.ShiftSubType ?? ShiftSubTypes.FixedMorning,
                        TwoShiftRotationPattern = user.TwoShiftRotationPattern
                    };

                    // اعمال محدودیت‌های سفارشی
                    var customConstraint = request.Constraints.FirstOrDefault(c => c.UserId == user.Id);
                    if (customConstraint != null)
                    {
                        userConstraint.UnavailableDates = customConstraint.UnavailableDates;
                        userConstraint.PreferredShifts = customConstraint.PreferredShifts;
                        userConstraint.UnwantedShifts = customConstraint.UnwantedShifts;
                        userConstraint.MaxConsecutiveShifts = customConstraint.MaxConsecutiveShifts;
                        userConstraint.MinRestDaysBetweenShifts = customConstraint.MinRestDaysBetweenShifts;
                        userConstraint.MaxShiftsPerWeek = customConstraint.MaxShiftsPerWeek;
                        userConstraint.MaxNightShiftsPerMonth = customConstraint.MaxNightShiftsPerMonth;
                    }

                    constraints.UserConstraints.Add(userConstraint);
                }

                // بارگذاری شیفت‌های دپارتمان
                var shifts = await _shiftRepository.GetByFilterAsync(
                    filter: null,
                    includes: new[] { "Department", "RequiredSpecialties", "RequiredSpecialties.Specialty" }
                );

                var departmentShifts = shifts.Items
                    .Where(s => s.DepartmentId == request.DepartmentId)
                    .ToList();

                foreach (var shift in departmentShifts)
                {
                    var shiftRequirement = new ShiftRequirement
                    {
                        ShiftId = shift.Id ?? 0,
                        ShiftLabel = shift.Label ?? ShiftLabel.Morning,
                        DepartmentId = shift.DepartmentId ?? 0,
                        StartTime = shift.StartTime ?? TimeSpan.Zero,
                        EndTime = shift.EndTime ?? TimeSpan.Zero
                    };

                    // بارگذاری نیازمندی‌های تخصص
                    if (shift.RequiredSpecialties != null)
                    {
                        foreach (var reqSpecialty in shift.RequiredSpecialties)
                        {
                            var specialtyReq = new SpecialtyRequirement
                            {
                                SpecialtyId = reqSpecialty.SpecialtyId ?? 0,
                                SpecialtyName = reqSpecialty.Specialty?.SpecialtyName ?? "",
                                RequiredMaleCount = reqSpecialty.RequiredMaleCount ?? 0,
                                RequiredFemaleCount = reqSpecialty.RequiredFemaleCount ?? 0,
                                RequiredTotalCount = reqSpecialty.RequiredTottalCount ?? 0,
                                OnCallMaleCount = reqSpecialty.OnCallMaleCount ?? 0,
                                OnCallFemaleCount = reqSpecialty.OnCallFemaleCount ?? 0,
                                OnCallTotalCount = reqSpecialty.OnCallTottalCount ?? 0
                            };

                            shiftRequirement.SpecialtyRequirements.Add(specialtyReq);
                        }
                    }

                    constraints.ShiftRequirements.Add(shiftRequirement);
                }

                return constraints;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading constraints");
                return null;
            }
        }

        /// <summary>
        /// تبدیل راه‌حل به DTO نتیجه
        /// </summary>
        private async Task<ShiftSchedulingResultDto> ConvertSolutionToResultAsync(ShiftSolution solution, ShiftConstraints constraints)
        {
            var result = new ShiftSchedulingResultDto
            {
                FinalScore = solution.Score,
                Violations = solution.Violations
            };

            // تبدیل انتساب‌ها
            foreach (var assignment in solution.Assignments.Values)
            {
                var user = constraints.UserConstraints.FirstOrDefault(u => u.UserId == assignment.UserId);
                var shift = constraints.ShiftRequirements.FirstOrDefault(s => s.ShiftId == assignment.ShiftId);

                result.Assignments.Add(new ShiftAssignmentDto
                {
                    UserId = assignment.UserId,
                    UserName = user?.UserName ?? "",
                    ShiftId = assignment.ShiftId,
                    ShiftLabel = assignment.ShiftLabel,
                    Date = assignment.Date,
                    IsOnCall = assignment.IsOnCall,
                    SpecialtyId = user?.SpecialtyId ?? 0,
                    SpecialtyName = user?.SpecialtyName ?? ""
                });
            }

            // محاسبه آمارها
            result.Statistics = new ShiftSchedulingStatisticsDto
            {
                TotalShifts = result.Assignments.Count,
                TotalUsers = constraints.UserConstraints.Count,
                SatisfiedConstraints = constraints.UserConstraints.Count - solution.Violations.Count,
                ViolatedConstraints = solution.Violations.Count,
                AverageShiftsPerUser = constraints.UserConstraints.Count > 0 ?
                    (double)result.Assignments.Count / constraints.UserConstraints.Count : 0
            };

            // آمار شیفت‌ها بر اساس نوع
            result.Statistics.ShiftsByType = result.Assignments
                .GroupBy(a => a.ShiftLabel)
                .ToDictionary(g => g.Key, g => g.Count());

            // آمار شیفت‌ها بر اساس کاربر
            result.Statistics.ShiftsByUser = result.Assignments
                .GroupBy(a => a.UserId)
                .ToDictionary(g => g.Key, g => g.Count());

            return result;
        }

        #endregion
    }
}
