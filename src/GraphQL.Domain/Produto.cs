namespace GraphQL.Domain
{
    public class Produto
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Preco Preco { get; set; }
        public Departamento Departamento { get; set; }

        public Produto(string codigo, string nome, string descricao, Preco preco, Departamento departamento)
        {
            Codigo = codigo;
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Departamento = departamento;
        }
    }
}
