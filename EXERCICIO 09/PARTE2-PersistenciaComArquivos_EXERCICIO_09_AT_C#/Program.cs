using System;
using System.IO;

class Program
{
    // Caminho absoluto para o arquivo estoque.txt na pasta da solução
    static string arquivoEstoque = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "estoque.txt");

    static void Main()
    {
        while (true)
        {
            // Menu de opções
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Inserir Produto");
            Console.WriteLine("2. Listar Produtos");
            Console.WriteLine("3. Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            // Switch para controlar a escolha do usuário
            switch (opcao)
            {
                case "1":
                    InserirProduto();
                    break;
                case "2":
                    ListarProdutos();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }

    // Função para inserir um novo produto no estoque
    static void InserirProduto()
    {
        try
        {
            Console.Write("Nome do produto: ");
            string nome = Console.ReadLine();

            Console.Write("Quantidade em estoque: ");
            int quantidade = int.Parse(Console.ReadLine());

            Console.Write("Preço unitário: ");
            decimal preco = decimal.Parse(Console.ReadLine());

            // Verifica se o arquivo de estoque existe
            if (!File.Exists(arquivoEstoque))
            {
                // Cria o arquivo e escreve os dados do produto se o arquivo não existir
                using (StreamWriter sw = File.CreateText(arquivoEstoque))
                {
                    sw.WriteLine($"{nome},{quantidade},{preco:F2}");
                }
            }
            else
            {
                // Adiciona os dados do produto ao arquivo existente
                using (StreamWriter sw = File.AppendText(arquivoEstoque))  // Evita sobrescrever o arquivo
                {
                    sw.WriteLine($"{nome},{quantidade},{preco:F2}");
                }
            }
        }
        catch (FormatException ex)
        {
            // Tratamento de erro para formato inválido
            Console.WriteLine("Erro: Formato de entrada inválido. Por favor, insira os valores corretamente.");
            Console.WriteLine($"Detalhes do erro: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Captura qualquer outro erro genérico
            Console.WriteLine($"Erro inesperado: {ex.Message}");
        }
    }

    // Função para listar todos os produtos cadastrados
    static void ListarProdutos()
    {
        // Verifica se o arquivo de estoque está vazio ou não existe
        if (!File.Exists(arquivoEstoque) || new FileInfo(arquivoEstoque).Length == 0)
        {
            Console.WriteLine("Nenhum produto cadastrado.");
            return;
        }

        Console.WriteLine("\nProdutos cadastrados:");

        // Usando StreamReader para ler o arquivo
        try
        {
            using (StreamReader sr = new StreamReader(arquivoEstoque))
            {
                string linha;
                while ((linha = sr.ReadLine()) != null)
                {
                    try
                    {
                        // Divide a linha e verificar se o formato está correto
                        string[] dados = linha.Split(',');

                        if (dados.Length != 3)  // Verifica se a linha tem exatamente 3 dados
                        {
                            Console.WriteLine($"Erro de formato na linha: {linha}. Linha ignorada.");
                            continue;
                        }

                        // Valida os dados e tenta converter
                        string nome = dados[0];
                        int quantidade = int.Parse(dados[1]);  //Exceção se o valor não for inteiro
                        decimal preco = decimal.Parse(dados[2]);  // Exceção se o valor não for decimal

                        Console.WriteLine($"Produto: {nome} | Quantidade: {quantidade} | Preço: R$ {preco:F2}");
                    }
                    catch (FormatException)
                    {
                        // Se o formato estiver incorreto 
                        Console.WriteLine($"Erro de formato na linha: {linha}. Linha ignorada.");
                    }
                }
            }
        }
        catch (IOException ex)
        {
            // Erro ao abrir ou ler o arquivo
            Console.WriteLine($"Erro ao ler o arquivo: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Captura de outros erros inesperados
            Console.WriteLine($"Erro inesperado: {ex.Message}");
        }
    }
}
