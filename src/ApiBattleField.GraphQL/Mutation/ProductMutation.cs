using ApiBattleField.GraphQL.Model;
using ApiBattleField.GraphQL.Service;
using ApiBattleField.GraphQL.Types;
using GraphQL;
using GraphQL.Types;

namespace ApiBattleField.GraphQL.Mutation
{
    public class ProductMutation : ObjectGraphType
    {
        public ProductMutation(IProductService productService)
        {
            Field<ProductType>(
                "createProduct",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ProductInputType>> { Name = "product" }),
                resolve: context =>
                {
                    var product = context.GetArgument<Product>("product");
                    productService.Add(product);
                    return product;
                }
            );

            Field<ProductType>(
                "updateProduct",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" },
                    new QueryArgument<NonNullGraphType<ProductInputType>> { Name = "product" }
                ),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var product = context.GetArgument<Product>("product");
                    product.Id = id;
                    productService.Update(product);
                    return product;
                }
            );

            Field<StringGraphType>(
                "deleteProduct",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    productService.Delete(id);
                    return "Product deleted";
                }
            );
        }
    }
}
