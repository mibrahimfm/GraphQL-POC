using GraphQL.Domain;
using GraphQL.Infrastructure.Repository;
using GraphQL.Types;
using System.Collections.Generic;

namespace GraphQL.Infrastructure
{
    internal class ProdutosQuery : ObjectGraphType
    {
        public ProdutosQuery(ProdutoRepository produtoRepository)
        {
            Field<ProdutoType>("produto",
                arguments:
                new QueryArguments(
                        new QueryArgument<StringGraphType> { Name = "codigo", Description = "Código do produto" },
                        new QueryArgument<StringGraphType> { Name = "nome", Description = "Nome do produto" }
                    ),
                resolve: context =>
                {
                    string nome = context.GetArgument<string>("nome");
                    string codigo = context.GetArgument<string>("codigo");

                    Produto resultado = produtoRepository.ObterProduto(codigo, nome);
                    return resultado;
                },
                description: "Query para obter produto por nome ou código");

            Field<ListGraphType<ProdutoType>>("produtos",
                arguments:
                new QueryArguments(
                        new QueryArgument<DepartamentoType> { Name = "departamento", Description = "Departamento dos produtos que deseja obter" },
                        new QueryArgument<DecimalGraphType> { Name = "precoMaximo", Description = "Preço máximo para os produtos" }
                    ),
                resolve: context =>
                {
                    Departamento? departamento = context.GetArgument<Departamento?>("departamento");
                    double? precoMaximo = context.GetArgument<double?>("precoMaximo");

                    List<Produto> resultado = produtoRepository.ObterProdutos(departamento, precoMaximo);
                    return resultado;
                },
                description: "Query para obter produtos por departamento e/ou preço máximo");

        }
    }
}