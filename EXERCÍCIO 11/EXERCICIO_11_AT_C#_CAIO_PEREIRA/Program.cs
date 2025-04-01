using System;
using System.IO;

class Program
{
    //Coloquei o arquivo contatos.txt na mesma pasta da solução para facilitar
    static string arquivoContatos = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "contatos.txt");

    static void Main()
    {
        int option;

        do
        {
            Console.Clear();
            Console.WriteLine("=== Gerenciador de Contatos ===");
            Console.WriteLine("1 - Adicionar novo contato");
            Console.WriteLine("2 - Listar contatos cadastrados");
            Console.WriteLine("3 - Sair");
            Console.Write("Escolha uma opção: ");
            option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    AdicionarContato();
                    break;

                case 2:
                    ListarContatos();
                    break;

                case 3:
                    Console.WriteLine("Encerrando programa...");
                    break;

                default:
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    break;
            }

        } while (option != 3);
    }

    // Adicionar um novo contato
    static void AdicionarContato()
    {
        Console.Clear();
        Console.WriteLine("=== Adicionar Novo Contato ===");

        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Telefone: ");
        string telefone = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        using (StreamWriter sw = new StreamWriter(arquivoContatos, true))
        {
            sw.WriteLine($"{nome},{telefone},{email}");
        }

        Console.WriteLine("Contato cadastrado com sucesso!");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }

    //Listar os contatos cadastrados
    static void ListarContatos()
    {
        Console.Clear();
        Console.WriteLine("=== Contatos Cadastrados ===");

        if (File.Exists(arquivoContatos))
        {
            using (StreamReader sr = new StreamReader(arquivoContatos))
            {
                string linha;
                bool contatosEncontrados = false;

                while ((linha = sr.ReadLine()) != null)
                {
                    string[] dados = linha.Split(',');
                    Console.WriteLine($"Nome: {dados[0]} | Telefone: {dados[1]} | Email: {dados[2]}");
                    contatosEncontrados = true;
                }

                if (!contatosEncontrados)
                {
                    Console.WriteLine("Nenhum contato cadastrado.");
                }
            }
        }
        else
        {
            Console.WriteLine("Nenhum contato cadastrado.");
        }

        Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }
}

