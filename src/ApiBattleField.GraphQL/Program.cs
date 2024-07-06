using ApiBattleField.GraphQL.Mutation;
using ApiBattleField.GraphQL.Queries;
using ApiBattleField.GraphQL.Service;
using ApiBattleField.GraphQL.Types;
using GraphQL.Types;
using GraphQL;
using Microsoft.AspNetCore.Builder;
using GraphiQl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Repository
builder.Services.AddTransient<IProductService, ProductService>();

//Types
builder.Services.AddTransient<ProductType>();
builder.Services.AddTransient<ProductInputType>();

//Query
builder.Services.AddTransient<ProductQuery>();
builder.Services.AddTransient<ProductMutation>();

//Bind to RootSchema
builder.Services.AddTransient<ISchema, Schema>(services => new Schema { Query = services.GetRequiredService<ProductQuery>(), Mutation = services.GetRequiredService<ProductMutation>() });

builder.Services.AddGraphQL(g => g.AddAutoSchema<ISchema>().AddSystemTextJson());

 

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseGraphiQl("/graphql");
app.UseGraphQL<ISchema>();

app.UseAuthorization();


app.Run();
