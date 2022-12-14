using GraphQL.Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using System;

namespace GraphQL.Infrastructure.GraphQL
{
    internal class ProdutosSchema : Types.Schema
    {
        public ProdutosSchema(ProdutoRepository produtoRepository, IServiceProvider services) : base(services)
        {
            Query = new ProdutosQuery(produtoRepository);
            Mutation = new ProdutosMutation(produtoRepository);
        }
    }
}
