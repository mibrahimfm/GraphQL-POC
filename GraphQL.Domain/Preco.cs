namespace GraphQL.Domain
{
    public class Preco
    {
        public double Valor { get; set; }
        public decimal DescontoAVista { get; set; }

        public Preco(double valor)
        {
            Valor = valor;
        }

        public Preco(decimal descontoAVista)
        {
            DescontoAVista = descontoAVista;
        }

        public Preco(double valor, decimal descontoAVista)
        {
            Valor = valor;
            DescontoAVista = descontoAVista;
        }
    }
}
