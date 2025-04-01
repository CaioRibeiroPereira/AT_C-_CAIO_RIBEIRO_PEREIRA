
using System;

class Program
{
    static void Main()
    {
        const int limiteProdutos = 5;
        string[] nomes = new string[limiteProdutos];
        int[] quantidades = new int[limiteProdutos];
        decimal[] precos = new decimal[limiteProdutos];
        int contador = 0;

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Inserir Produto");
            Console.WriteLine("2. Listar Produtos");
            Console.WriteLine("3. Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    if (contador >= limiteProdutos)
                    {
                        Console.WriteLine("Limite de produtos atingido!");
                        break;
                    }
                    Console.Write("Nome do produto: ");
                    nomes[contador] = Console.ReadLine();

                    Console.Write("Quantidade em estoque: ");
                    quantidades[contador] = int.Parse(Console.ReadLine());

                    Console.Write("Preço unitário: ");
                    precos[contador] = decimal.Parse(Console.ReadLine());

                    contador++;
                    break;

                case "2":
                    if (contador == 0)
                    {
                        Console.WriteLine("Nenhum produto cadastrado.");
                    }
                    else
                    {
                        Console.WriteLine("\nProdutos cadastrados:");
                        for (int i = 0; i < contador; i++)
                        {
                            Console.WriteLine($"Produto: {nomes[i]} | Quantidade: {quantidades[i]} | Preço: R$ {precos[i]:F2}");
                        }
                    }
                    break;

                case "3":
                    return;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }
}
//Segunda parte desenvolvida em outra solução