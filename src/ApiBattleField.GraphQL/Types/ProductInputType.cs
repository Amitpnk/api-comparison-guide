using GraphQL.Types;
using System.Xml.Linq;

namespace ApiBattleField.GraphQL.Types
{
    public class ProductInputType : InputObjectGraphType
    {
        public ProductInputType()
        {
            Name = "ProductInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<DecimalGraphType>>("price");
        }
    }

}
