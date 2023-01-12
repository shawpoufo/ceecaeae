using Artisanal.Web.Models;
using Artisanal.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Artisanal.Web.Controllers
{
    [Authorize(policy:"AdminOnly")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private ProductService _productService;
        public ProductController(ILogger<ProductController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var rs = await _productService.GetAllProductsAsync<ResponseDto>();
            var ls = JsonConvert.DeserializeObject<List<ProductDto>>(rs.Result.ToString());
            return View(ls);
        }

        [HttpGet]
        public IActionResult New()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(ProductViewModel productViewModel)
        {

            if(!ModelState.IsValid)
                return View(productViewModel);

            var responseDto = await _productService.CreateProductAsync<ResponseDto>(new ProductDto
            {
                ProductName = productViewModel.ProductName,
                CategoryName = productViewModel.CategoryName,
                ImageURL = productViewModel.ImageURL,
                Price = productViewModel.Price
            });
            if (responseDto != null && !responseDto.IsSuccess)
            {
                return View(productViewModel);
            }
            return RedirectToAction(nameof(Index));

        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var responseDto = await _productService.GetProductByIdAsync<ResponseDto>(id);
            var product = JsonConvert.DeserializeObject<ProductDto>(responseDto.Result.ToString());
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return View(productDto);

            var responseDto = await _productService.UpdateProductAsync<ResponseDto>(productDto);
            if (!responseDto.IsSuccess)
            {
                ViewBag.ErrorMessages = responseDto.ErrorMessages;
                return View(productDto);
            }
            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromForm] int productId)
        {
            var responseDto = await _productService.DeleteProductAsync<ResponseDto>(productId);
            if (!responseDto.IsSuccess)
            {
                ViewBag.ErrorMessages = responseDto.ErrorMessages;
                // return View(productDto);
            }
            return RedirectToAction(nameof(Index));

        }

    }
}