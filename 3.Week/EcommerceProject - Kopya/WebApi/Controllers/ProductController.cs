using AutoMapper;
using Business.Abstract;
using DataAccess.Models.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        /// <summary>
        ///  /// <summary>
        /// Constructor ile IProductService ve IMapper'i injektion ettik
        /// </summary>
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {

            _productService = productService;
            _mapper = mapper;
        }
        /// <summary>
        /// product listesi getirir.
        /// </summary>
        /// <returns></returns>
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            if (result == null)
            {
                return BadRequest("Product listesi bulunamadı");
            }
            return Ok(result);
        }
        /// <summary>
        /// bir productId ye göre product getirir.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>

        [HttpGet("getbyId")]
        public IActionResult GetById([FromQuery] int productId)
        {
            var result = _productService.GetById(productId);
            if (result == null)
            {
                return BadRequest("Product bulunamadı");
            }
            return Ok(result);
        }

        /// <summary>
        /// bir productName göre product getirir.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>

        [HttpGet("getbyname")]
        public IActionResult GetByName([FromQuery] string productname)
        {
            if (!string.IsNullOrEmpty(productname))
            {
                var result = _productService.GetByName(productname);
                return Ok(result);
            }
            
                return BadRequest("Product bulunamadı");
            
            
        }
        /// <summary>
        /// bir product ekler
        /// </summary>
        /// <param name="createCategoryVm"></param>
        /// <returns></returns>

        [HttpPost("add")]
        public IActionResult Add([FromBody] CreateProductVm createCategoryVm)
        {
            _productService.Add(createCategoryVm);
            return Ok();
        }

        /// <summary>
        /// UpdateProductVm'ye göre bir product günceller
        /// </summary>
        /// <param name="updateProductVm"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public IActionResult Update([FromBody] UpdateProductVm updateProductVm)
        {
            _productService.Update(updateProductVm);
            return Ok();
        }

        /// <summary>
        /// bir productId 'ye göre bir product siler.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        public IActionResult Delete(int productId)
        {
            _productService.Delete(productId);
            return Ok();
        }
    }
}

