using GraphQL.Domain;
using GraphQL.Infrastructure.Repository;
using GraphQL.Types;
using System.Collections.Generic;

namespace GraphQL.Infrastructure
{
    internal class ProdutosMutation : ObjectGraphType
    {
        public ProdutosMutation(ProdutoRepository produtoRepository)
        {
            Field<ListGraphType<ProdutoType>>("incluirProduto",
                arguments:
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProdutoInput>> { Name = "produto", Description = "Dados do novo produto" }
                    ),
                resolve: context =>
                {
                    Produto produto = context.GetArgument<Produto>("produto");

                    List<Produto> resultado = produtoRepository.Incluir(produto);
                    return resultado;                    
                },
                description: "Mutation para incluir produto"
                );

            Field<ProdutoType>("alterarPreco",
                arguments:
                new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "codigo", Description = "Código do produto que deseja alterar"},
                    new QueryArgument<NonNullGraphType<PrecoInput>> { Name = "preco", Description = "Novo preço do produto" }
                    ),
                resolve: context =>
                {
                    string codigo = context.GetArgument<string>("codigo");
                    Preco preco = context.GetArgument<Preco>("preco");

                    Produto resultado = produtoRepository.AlterarPreco(codigo, preco);
                    return resultado;                    
                });

            Field<ProdutoType>("excluirProduto",
                arguments:
                new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "codigo", Description = "Código do produto que deseja excluir" }
                    ),
                resolve: context =>
                {
                    string codigo = context.GetArgument<string>("codigo");

                    Produto resultado = produtoRepository.Excluir(codigo);
                    return resultado;
                },
                description: "Mutation para exclusão de produto");
        }
    }
}
