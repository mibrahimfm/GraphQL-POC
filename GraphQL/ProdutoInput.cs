using GraphQL.Domain;
using GraphQL.Types;

namespace GraphQL.Infrastructure
{
    internal class ProdutoInput : InputObjectGraphType<Produto>
    {
        public ProdutoInput()
        {
            Field<NonNullGraphType<StringGraphType>>(nameof(Produto.Codigo));
            Field<NonNullGraphType<StringGraphType>>(nameof(Produto.Nome));
            Field<NonNullGraphType<StringGraphType>>(nameof(Produto.Descricao));
            Field<NonNullGraphType<PrecoInput>>(nameof(Produto.Preco));
            Field<DepartamentoType>("departamento");
        }
    }
}
