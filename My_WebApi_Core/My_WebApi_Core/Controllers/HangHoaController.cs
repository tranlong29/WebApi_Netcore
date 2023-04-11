using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_WebApi_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace My_WebApi_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> hangHoas = new List<HangHoa>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(hangHoas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var hangHoa = hangHoas.SingleOrDefault(x => x.MaHH == Guid.Parse(id));
                if(hangHoa == null)
                {
                    return NotFound();
                }
                return Ok(hangHoa);
            }
            catch 
            {
                return BadRequest();
            }

            
        }

        [HttpPost]
        public IActionResult Create(HangHoaVM hangHoaVM)
        {
            var hanghoa = new HangHoa
            {
                MaHH = Guid.NewGuid(),
                TenHH = hangHoaVM.TenHH,
                DonGia = hangHoaVM.DonGia
            };
            hangHoas.Add(hanghoa);
            return Ok(new
            {
                 Success = true, Data = hanghoa
            });
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, HangHoa hangHoaEdit)
        {
            try
            {
                var hangHoa = hangHoas.SingleOrDefault(x => x.MaHH == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                if(id != hangHoa.MaHH.ToString())
                {
                    return BadRequest();
                }
                hangHoa.TenHH = hangHoaEdit.TenHH;
                hangHoa.DonGia = hangHoaEdit.DonGia;

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(string id)
        {
            try
            {
                var hangHoa = hangHoas.SingleOrDefault(x => x.MaHH == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                hangHoas.Remove(hangHoa);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
