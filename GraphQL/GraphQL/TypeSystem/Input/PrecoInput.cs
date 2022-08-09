using GraphQL.Domain;
using GraphQL.Types;

namespace GraphQL.Infrastructure.GraphQL.TypeSystem.Input
{
    internal class PrecoInput : InputObjectGraphType<Preco>
    {
        public PrecoInput()
        {
            Field<DecimalGraphType>(nameof(Preco.Valor));
            Field<DecimalGraphType>(nameof(Preco.DescontoAVista));
        }
    }
}
