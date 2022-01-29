using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Models.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        /// <summary>
        /// Constructor ile ICategoryService ve IMapper'i injektion ettik
        /// </summary>

        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {

            _categoryService = categoryService;
            _mapper = mapper;
        }

         /// <summary>
         /// category listesini getirir.
         /// </summary>
         /// <returns></returns>

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetAll();
            if (result == null)
            {
                return BadRequest("Category listesi bulunamadı");
            }
            return Ok(result);
        }


        /// <summary>
        /// categoryId'ye göre category getirir.
        /// </summary>
        /// <returns></returns>

        [HttpGet("getbyId")]
        public IActionResult GetById([FromQuery] int categoryId)
        {
            var result = _categoryService.GetById(categoryId);
            if (result == null)
            {
                return BadRequest("Category bulunamadı");
            }
            return Ok(result);
        }


        /// <summary>
        ///  categoryname göre category getirir.
        /// </summary>
        /// <returns></returns>
        [HttpGet("getbyname")]
        public IActionResult GetByName([FromQuery] string categoryname)
        {

            if (!string.IsNullOrEmpty(categoryname))
            {
                var result = _categoryService.GetByName(categoryname);
                return Ok(result);
            }
                return BadRequest("Category bulunamadı");
            
           
        }
        /// <summary>
        /// category ekler
        /// </summary>
        /// <returns></returns>

        [HttpPost("add")]
        public IActionResult Add([FromBody] CreateCategoryVm createCategoryVm)
        {
            _categoryService.Add(createCategoryVm);
            return Ok();
        }

        /// <summary>
        /// UpdateCategoryVm'ye göre bir category günceller
        /// </summary>
        /// <returns></returns>

        [HttpPut("update")]
        public IActionResult Update([FromBody] UpdateCategoryVm updateCategoryVm)
        {
            _categoryService.Update(updateCategoryVm);
            return Ok();
        }

        /// <summary>
        ///categoryId'ye göre category siler
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete")]
        public IActionResult Delete(int categoryId)
        {
            _categoryService.Delete(categoryId);
            return Ok();
        }
    }
}



