using GraphQL.Domain;
using GraphQL.Types;

namespace GraphQL.Infrastructure
{
         class ProdutoType : ObjectGraphType<Produto>
    {
        public ProdutoType()
        {
            Field("codigo", o => o.Codigo);
            Field("nome", o => o.Nome);
            Field("descricao", o => o.Descricao);
            Field<PrecoType>("preco", resolve: o => o.Source.Preco);
            Field<DepartamentoType>(nameof(Produto.Departamento), resolve: o => o.Source.Departamento);
        }
    }
}
