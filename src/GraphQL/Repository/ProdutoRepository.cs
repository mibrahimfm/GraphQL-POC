using GraphQL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphQL.Infrastructure.Repository
{
    public class ProdutoRepository
    {
        private static List<Produto> produtos = new()
        {
            new Produto("0001", "Tablet", "Tablet da última geração", new(4200.00, (decimal)0.1), Departamento.Eletronicos),
            new Produto("0002", "Notebook", "Notebook gamer", new(6000.00, (decimal)0.05), Departamento.Eletronicos),
            new Produto("0003", "Smartphone", "Smartphone com reconhecimento facial", new(5500.00, (decimal)0.00), Departamento.Eletronicos),
            new Produto("0004", "Geladeira", "Geladeira duas portas", new(3300.00, (decimal)0.15), Departamento.Eletrodomesticos),
            new Produto("0005", "Fogão", "Fogão elétrico 4 bocas", new(900.00, (decimal)0.1), Departamento.Eletrodomesticos),
            new Produto("0006", "Caneta", "Caneta tinta azul/preta", new(4.50, (decimal)0.00), Departamento.MaterialEscritorio),
            new Produto("0007", "Grampeador", "Grampeador preto", new(15.95, (decimal)0.05), Departamento.MaterialEscritorio),
        };

        public Produto ObterProduto(string codigo = "", string nome = "")
        {
            if (!string.IsNullOrEmpty(codigo))
            {
                return produtos.FirstOrDefault(x => x.Codigo == codigo);
            }
            else if (!string.IsNullOrEmpty(nome))
            {
                return produtos.FirstOrDefault(x => x.Nome == nome);
            }
            throw new ApplicationException("Query ObterProduto precisa receber código ou nome");
        }

        public List<Produto> ObterProdutos(Departamento? departamento, double? precoMaximo = 0.0)
        {
            List<Produto> produtosFiltrados = new(produtos);
            
            if (departamento.HasValue)
            {
                produtosFiltrados = produtosFiltrados.Where(x => x.Departamento == departamento).ToList();
            }
            if (precoMaximo > 0.0)
            {
                produtosFiltrados = produtosFiltrados.Where(x => x.Preco.Valor <= precoMaximo).ToList();
            }

            return produtosFiltrados;
        }

        public List<Produto> Incluir(Produto produto)
        {
            produtos.Add(produto);
            return produtos;
        }

        public Produto AlterarPreco(string codigo, Preco preco)
        {
            if (preco.Valor > 0.0)
            {
                produtos.First(x => x.Codigo == codigo).Preco.Valor = preco.Valor;
            }
            if (preco.DescontoAVista > (decimal)0.0)
            {
                produtos.First(x => x.Codigo == codigo).Preco.DescontoAVista = preco.DescontoAVista;
            }
            return produtos.First(x => x.Codigo == codigo);
        }

        public Produto Excluir(string codigo)
        {
            Produto produto = produtos.FirstOrDefault(x => x.Codigo == codigo);
            if (produto != default)
            {
                produtos.Remove(produto);
            }
            return produto;
        }
    }
}
