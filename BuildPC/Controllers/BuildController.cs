using BuildPC.Services;
using Microsoft.AspNetCore.Mvc;
using BuildPC.SeedData;
using System.Threading.Tasks;
using System.Collections.Generic;
using BuildPC.Models;
using BuildPC.Data;

namespace BuildPC.Controllers
{
    public class BuildController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly PcCompatibilityService _pcCompatibilityService;

        public BuildController(ApplicationDbContext context, PcCompatibilityService pcCompatibilityService)
        {
            _context = context;
            _pcCompatibilityService = pcCompatibilityService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CheckCompatibility()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CheckCompatibility([FromBody] ComponentIdsModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, message = "Dữ liệu đầu vào không hợp lệ" });
            }

            try
            {
                // Lấy các linh kiện từ database
                var cpu = await _context.CpuIntels.FindAsync(model.CpuId);
                var mainboard = await _context.Mainboards.FindAsync(model.MainboardId);
                var ram = await _context.RamPCs.FindAsync(model.RamId);
                var vga = await _context.VGAs.FindAsync(model.VgaId);
                var psu = await _context.PsuPCs.FindAsync(model.PsuId);

                // Kiểm tra null
                if (cpu == null || mainboard == null || ram == null || vga == null || psu == null)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "Không tìm thấy một hoặc nhiều linh kiện được chọn."
                    });
                }

                // Kiểm tra tương thích
                var issues = _pcCompatibilityService.CheckCompatibility(cpu, mainboard, ram, vga, psu);

                // Trả về kết quả
                if (issues.Count > 0)
                {
                    return Ok(new
                    {
                        success = false,
                        message = "Có vấn đề về tương thích",
                        issues
                    });
                }

                return Ok(new
                {
                    success = true,
                    message = "Linh kiện hoàn toàn tương thích!"
                });
            }
            catch (Exception ex)
            {
                // Ghi log lỗi ở đây nếu cần
                return StatusCode(500, new
                {
                    success = false,
                    message = "Đã xảy ra lỗi khi kiểm tra tương thích",
                    error = ex.Message
                });
            }
        }

        // Model để nhận dữ liệu từ client
        public class ComponentIdsModel
        {
            public int CpuId { get; set; }
            public int MainboardId { get; set; }
            public int RamId { get; set; }
            public int VgaId { get; set; }
            public int PsuId { get; set; }
        }
    }
}