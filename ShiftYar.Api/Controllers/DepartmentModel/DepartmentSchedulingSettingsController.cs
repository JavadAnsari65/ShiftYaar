using Microsoft.AspNetCore.Mvc;
using ShiftYar.Application.Common.Models.ResponseModel;
using ShiftYar.Application.DTOs.DepartmentModel;
using ShiftYar.Application.Features.DepartmentModel.Filters;
using ShiftYar.Application.Interfaces.DepartmentModel;
using ShiftYar.Infrastructure.Persistence.AppDbContext;

namespace ShiftYar.Api.Controllers.DepartmentModel
{
    public class DepartmentSchedulingSettingsController : BaseController
    {
        private readonly IDepartmentSchedulingSettingsService _service;
        public DepartmentSchedulingSettingsController(ShiftYarDbContext context, IDepartmentSchedulingSettingsService service) : base(context)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedResponse<DepartmentSchedulingSettingsDtoGet>>>> GetSettings([FromQuery] DepartmentSchedulingSettingsFilter filter)
        {
            var result = await _service.GetSettingsAsync(filter);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<DepartmentSchedulingSettingsDtoGet>>> GetSetting(int id)
        {
            var result = await _service.GetSettingAsync(id);
            if (!result.IsSuccess) return NotFound(result);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<DepartmentSchedulingSettingsDtoGet>>> CreateSetting([FromBody] DepartmentSchedulingSettingsDtoAdd dto)
        {
            var result = await _service.CreateSettingAsync(dto);
            if (!result.IsSuccess) return BadRequest(result);
            return CreatedAtAction(nameof(GetSetting), new { id = result.Data.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult<ApiResponse<DepartmentSchedulingSettingsDtoGet>>> UpdateSetting(int id, [FromBody] DepartmentSchedulingSettingsDtoAdd dto)
        {
            var result = await _service.UpdateSettingAsync(id, dto);
            if (!result.IsSuccess) return NotFound(result);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<ApiResponse<string>>> DeleteSetting(int id)
        {
            var result = await _service.DeleteSettingAsync(id);
            if (!result.IsSuccess) return NotFound(result);
            return Ok(result);
        }
    }
}
