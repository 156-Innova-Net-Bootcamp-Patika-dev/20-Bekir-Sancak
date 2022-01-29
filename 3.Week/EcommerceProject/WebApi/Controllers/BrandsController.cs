using AutoMapper;
using Business.Abstract;
using DataAccess.Models.Brands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {

        /// <summary>
        /// Constructor ile IBrandService ve IMapper'i injektion ettik
        /// </summary>
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;
        public BrandsController(IBrandService brandService,IMapper mapper)
        {

            _brandService = brandService; 
            _mapper = mapper;
        }

        /// <summary>
        /// brand listesini getirir
        /// </summary>
        /// <returns></returns>
        
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _brandService.GetAll();
            if(result==null)
            {
                return BadRequest("Marka listesi bulunamadı");
            }
            return Ok(result);
        }

        /// <summary>
        /// brandId'ye göre brand getirir.
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        [HttpGet("getbyId")]
        public IActionResult GetById( [FromQuery] int brandId)
        {
            var result=_brandService.GetById(brandId);
            if(result==null)
            {
                return BadRequest("Brand bulunamadı");
            }
            return Ok(result);
        }


        /// <summary>
        /// brandName göre brand getirir.
        /// </summary>
        /// <param name="brandName"></param>
        /// <returns></returns>
        [HttpGet("getbyname")]
        public IActionResult GetByName([FromQuery] string brandName)
        {
            if (!string.IsNullOrEmpty(brandName))
            {
                var result = _brandService.GetByName(brandName);
                return Ok(result);
            }
           
                return BadRequest("Brand bulunamadı");
            
            
        }
        /// <summary>
        /// bir brand ekler
        /// </summary>
        /// <param name="createBrandVm"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public IActionResult Add([FromBody] CreateBrandVm  createBrandVm)
        {
            _brandService.Add(createBrandVm);
            return Ok();
        }

        /// <summary>
        /// UpdateBrandVm göre brand günceller
        /// </summary>
        /// <param name="updateBrandVm"></param>
        /// <returns></returns>

        [HttpPut("update")]
        public IActionResult Update([FromBody] UpdateBrandVm updateBrandVm)
        {
            _brandService.Update(updateBrandVm);
            return Ok();
        }

        /// <summary>
        /// brandId'ye göre brand siler
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        public IActionResult Delete(int brandId)
        {
            _brandService.Delete(brandId);
            return Ok();
        }
    }
}
