using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ShiftYar.Application.Common.Models.ResponseModel;
using ShiftYar.Application.DTOs.DepartmentModel;
using ShiftYar.Application.Features.DepartmentModel.Filters;
using ShiftYar.Application.Interfaces.DepartmentModel;
using ShiftYar.Application.Interfaces.Persistence;
using ShiftYar.Domain.Entities.DepartmentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShiftYar.Application.Features.DepartmentModel.Services
{
    public class DepartmentSchedulingSettingsService : IDepartmentSchedulingSettingsService
    {
        private readonly IEfRepository<DepartmentSchedulingSettings> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<DepartmentSchedulingSettingsService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DepartmentSchedulingSettingsService(IEfRepository<DepartmentSchedulingSettings> repository, IMapper mapper, ILogger<DepartmentSchedulingSettingsService> logger, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResponse<PagedResponse<DepartmentSchedulingSettingsDtoGet>>> GetSettingsAsync(DepartmentSchedulingSettingsFilter filter)
        {
            var result = await _repository.GetByFilterAsync(filter, "Department");
            var data = _mapper.Map<List<DepartmentSchedulingSettingsDtoGet>>(result.Items);

            var paged = new PagedResponse<DepartmentSchedulingSettingsDtoGet>
            {
                Items = data,
                TotalCount = result.TotalCount,
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                TotalPages = (int)Math.Ceiling(result.TotalCount / (double)filter.PageSize)
            };
            return ApiResponse<PagedResponse<DepartmentSchedulingSettingsDtoGet>>.Success(paged);
        }

        public async Task<ApiResponse<DepartmentSchedulingSettingsDtoGet>> GetSettingAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id, "Department");
            if (entity == null) return ApiResponse<DepartmentSchedulingSettingsDtoGet>.Fail("تنظیمات یافت نشد.");
            var dto = _mapper.Map<DepartmentSchedulingSettingsDtoGet>(entity);
            return ApiResponse<DepartmentSchedulingSettingsDtoGet>.Success(dto);
        }

        public async Task<ApiResponse<DepartmentSchedulingSettingsDtoGet>> CreateSettingAsync(DepartmentSchedulingSettingsDtoAdd dto)
        {
            var entity = _mapper.Map<DepartmentSchedulingSettings>(dto);
            entity.CreateDate = DateTime.Now;
            entity.TheUserId = Convert.ToInt16(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier));

            await _repository.AddAsync(entity);
            await _repository.SaveAsync();
            var result = _mapper.Map<DepartmentSchedulingSettingsDtoGet>(entity);
            return ApiResponse<DepartmentSchedulingSettingsDtoGet>.Success(result, "تنظیمات با موفقیت ایجاد شد.");
        }

        public async Task<ApiResponse<DepartmentSchedulingSettingsDtoGet>> UpdateSettingAsync(int id, DepartmentSchedulingSettingsDtoAdd dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return ApiResponse<DepartmentSchedulingSettingsDtoGet>.Fail("تنظیمات یافت نشد.");

            _mapper.Map(dto, entity);
            entity.CreateDate = DateTime.Now;
            entity.TheUserId = Convert.ToInt16(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier));
            _repository.Update(entity);
            await _repository.SaveAsync();
            var result = _mapper.Map<DepartmentSchedulingSettingsDtoGet>(entity);
            return ApiResponse<DepartmentSchedulingSettingsDtoGet>.Success(result, "تنظیمات با موفقیت ویرایش شد.");
        }

        public async Task<ApiResponse<string>> DeleteSettingAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return ApiResponse<string>.Fail("تنظیمات یافت نشد.");
            _repository.Delete(entity);
            await _repository.SaveAsync();
            return ApiResponse<string>.Success("تنظیمات با موفقیت حذف شد.");
        }
    }
}
