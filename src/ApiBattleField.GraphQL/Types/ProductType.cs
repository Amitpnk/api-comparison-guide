using ApiBattleField.GraphQL.Model;
using GraphQL.Types;

namespace ApiBattleField.GraphQL.Types
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
        {
            Field(x => x.Id).Description("The ID of the product.");
            Field(x => x.Name).Description("The name of the product.");
            Field(x => x.Price).Description("The price of the product.");
        }
    }
}
