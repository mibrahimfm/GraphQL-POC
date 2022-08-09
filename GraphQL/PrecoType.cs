using GraphQL.Domain;
using GraphQL.Types;

namespace GraphQL.Infrastructure
{
    internal class PrecoType : ObjectGraphType<Preco>
    {
        public PrecoType()
        {
            Field("valor", o => o.Valor);
            Field("descontoAVista", o => o.DescontoAVista);
        }
    }
}
