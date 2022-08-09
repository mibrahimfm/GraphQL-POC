using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
namespace GraphQL.Infrastructure
{
    public static class _Setup
    {
        public static void ConfigureGraphQL(this IServiceCollection services)
        {
            services
                .AddScoped<ProdutosQuery>()
                .AddScoped<ProdutosSchema>()
                .AddScoped<ProdutosMutation>()
                .AddGraphQL()
                .AddSystemTextJson()
                .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = false)
                .AddGraphTypes(typeof(ProdutosSchema).Assembly);
        }

        public static void UseGraphQL(this IApplicationBuilder app, IEndpointRouteBuilder endpoint)
        {
            endpoint.MapGraphQL<ProdutosSchema>("/graphql");
            endpoint.MapGraphQLPlayground(new PlaygroundOptions
            {
                GraphQLEndPoint = "/graphql"
            },"/ui/graphql");           
        }
    }
}
