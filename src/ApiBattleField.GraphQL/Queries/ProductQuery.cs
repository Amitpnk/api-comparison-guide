using ApiBattleField.GraphQL.Service;
using ApiBattleField.GraphQL.Types;
using GraphQL;
using GraphQL.Types;

namespace ApiBattleField.GraphQL.Queries
{
    public class ProductQuery : ObjectGraphType
    {
        public ProductQuery(IProductService productService)
        {
            Field<ListGraphType<ProductType>>(
                "products",
                resolve: context => productService.GetAll()
            );

            Field<ProductType>(
                "product",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }),
                resolve: context => productService.GetById(context.GetArgument<int>("id"))
            );
        }
    }

}
