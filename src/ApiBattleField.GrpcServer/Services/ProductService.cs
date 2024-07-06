using Grpc.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiBattleField.GrpcServer;

namespace ApiBattleField.GrpcServer.Services
{
    public class ProductService : ProductServiceGrpc.ProductServiceGrpcBase
    {
        private readonly List<Product> _products;

        public ProductService()
        {
            // Seed data
            _products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Price = 10.0f },
                new Product { Id = 2, Name = "Product 2", Price = 20.0f },
                new Product { Id = 3, Name = "Product 3", Price = 30.0f }
            };
        }

        public override Task<ProductsResponse> GetAllProducts(Empty request, ServerCallContext context)
        {
            var response = new ProductsResponse();
            response.Products.AddRange(_products);
            return Task.FromResult(response);
        }

        public override Task<Product> GetProductById(ProductIdRequest request, ServerCallContext context)
        {
            var product = _products.FirstOrDefault(p => p.Id == request.Id);
            if (product == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Product with ID '{request.Id}' not found."));
            }
            return Task.FromResult(product);
        }

        public override Task<Product> CreateProduct(Product request, ServerCallContext context)
        {
            request.Id = _products.Max(p => p.Id) + 1;
            _products.Add(request);
            return Task.FromResult(request);
        }

        public override Task<Product> UpdateProduct(Product request, ServerCallContext context)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == request.Id);
            if (existingProduct == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Product with ID '{request.Id}' not found."));
            }
            existingProduct.Name = request.Name;
            existingProduct.Price = request.Price;
            return Task.FromResult(existingProduct);
        }

        public override Task<Empty> DeleteProduct(ProductIdRequest request, ServerCallContext context)
        {
            var product = _products.FirstOrDefault(p => p.Id == request.Id);
            if (product == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Product with ID '{request.Id}' not found."));
            }
            _products.Remove(product);
            return Task.FromResult(new Empty());
        }
    }
}