using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace ApiBattleField.GrpcClientConsole
{
    public class Program
    {
        private const string GrpcServerAddress = "http://localhost:5216";  

        public static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress(GrpcServerAddress);
            var client = new ProductServiceGrpc.ProductServiceGrpcClient(channel);

            await GetAllProductsAsync(client);
            await GetProductByIdAsync(client, 1);
            await CreateProductAsync(client);
            await UpdateProductAsync(client);
            await DeleteProductAsync(client, 1);
        }

        private static async Task GetAllProductsAsync(ProductServiceGrpc.ProductServiceGrpcClient client)
        {
            var response = await client.GetAllProductsAsync(new Empty());
            foreach (var product in response.Products)
            {
                Console.WriteLine($"Product ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");
            }
        }

        private static async Task GetProductByIdAsync(ProductServiceGrpc.ProductServiceGrpcClient client, int id)
        {
            var response = await client.GetProductByIdAsync(new ProductIdRequest { Id = id });
            Console.WriteLine($"Product ID: {response.Id}, Name: {response.Name}, Price: {response.Price}");
        }

        private static async Task CreateProductAsync(ProductServiceGrpc.ProductServiceGrpcClient client)
        {
            var newProduct = new Product
            {
                Name = "New Product",
                Price = 40.0f
            };
            var response = await client.CreateProductAsync(newProduct);
            Console.WriteLine($"Created Product ID: {response.Id}, Name: {response.Name}, Price: {response.Price}");
        }

        private static async Task UpdateProductAsync(ProductServiceGrpc.ProductServiceGrpcClient client)
        {
            var updatedProduct = new Product
            {
                Id = 1, // ID of the product to update
                Name = "Updated Product",
                Price = 50.0f
            };
            var response = await client.UpdateProductAsync(updatedProduct);
            Console.WriteLine($"Updated Product ID: {response.Id}, Name: {response.Name}, Price: {response.Price}");
        }

        private static async Task DeleteProductAsync(ProductServiceGrpc.ProductServiceGrpcClient client, int id)
        {
            await client.DeleteProductAsync(new ProductIdRequest { Id = id });
            Console.WriteLine($"Deleted Product with ID: {id}");
        }
    }
}
