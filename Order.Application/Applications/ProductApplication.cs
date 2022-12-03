using AutoMapper;
using Order.Application.DataContract.Request.Product;
using Order.Application.DataContract.Response.Product;
using Order.Application.Interfaces;
using Order.Domain.Interfaces.Services;
using Order.Domain.Validations.Base;

namespace Order.Application.Applications
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductApplication(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public Task<Response> CreateAsync(CreateProductRequest productRequest)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductResponse>> ListByFilterAsync(int productId = 0, string description = null)
        {
            throw new NotImplementedException();
        }
    }
}
