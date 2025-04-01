using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    //Coloquei o arquivo contatos.txt na mesma pasta da solução para facilitar
    static string arquivoContatos = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "contatos.txt");

    static void Main()
    {
        // Configurei o console para suportar caracteres Unicode, como emojis
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        List<Contato> contatos = CarregarContatos();

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
                    AdicionarContato(ref contatos);
                    break;

                case 2:
                    ExibirContatos(contatos);
                    break;

                case 3:
                    Console.WriteLine("Encerrando programa");
                    break;

                default:
                    Console.WriteLine("Opção inválida! Tente novamente!!!.");
                    break;
            }

        } while (option != 3);
    }

    static List<Contato> CarregarContatos()
    {
        List<Contato> contatos = new List<Contato>();

        if (File.Exists(arquivoContatos))
        {
            string[] linhas = File.ReadAllLines(arquivoContatos);
            if (linhas.Length == 0)
            {
                // Exceção ou mensagem caso o arquivo esteja vazio
                Console.WriteLine("Arquivo de contatos está vazio!");
                return contatos;
            }

            foreach (var linha in linhas)
            {
                string[] dados = linha.Split(',');
                if (dados.Length == 3)
                {
                    contatos.Add(new Contato(dados[0], dados[1], dados[2]));
                }
            }
        }
        else
        {
            Console.WriteLine("Arquivo de contatos não encontrado!");
        }

        return contatos;
    }

    static void AdicionarContato(ref List<Contato> contatos)
    {
        Console.Clear();
        Console.WriteLine("=== Adicionar Novo Contato ===");

        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Telefone: ");
        string telefone = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        // Adiciona o novo contato ao arquivo
        using (StreamWriter sw = new StreamWriter(arquivoContatos, true))
        {
            sw.WriteLine($"{nome},{telefone},{email}");
        }

        // Atualiza a lista de contatos
        contatos.Add(new Contato(nome, telefone, email));

        Console.WriteLine("Contato cadastrado com sucesso!");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }

    static void ExibirContatos(List<Contato> contatos)
    {
        if (contatos.Count == 0)
        {
            Console.WriteLine("Nenhum contato encontrado.");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            return;
        }

        Console.Clear();
        Console.WriteLine("Escolha o formato de exibição:");
        Console.WriteLine("1 - Markdown");
        Console.WriteLine("2 - Tabela");
        Console.WriteLine("3 - Texto Puro");
        Console.Write("Escolha uma opção: ");
        int escolha = int.Parse(Console.ReadLine());

        ContatoFormatter formato;

        switch (escolha)
        {
            case 1:
                formato = new MarkdownFormatter();
                break;
            case 2:
                formato = new TabelaFormatter();
                break;
            case 3:
                formato = new RawTextFormatter();
                break;
            default:
                Console.WriteLine("Opção inválida!");
                return;
        }

        formato.ExibirContatos(contatos);

        Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }
}

public class Contato
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }

    public Contato(string nome, string telefone, string email)
    {
        Nome = nome;
        Telefone = telefone;
        Email = email;
    }
}

public abstract class ContatoFormatter
{
    public abstract void ExibirContatos(List<Contato> contatos);
}

public class MarkdownFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        Console.WriteLine("## Lista de Contatos");
        foreach (var contato in contatos)
        {
            Console.WriteLine($"- **Nome:** {contato.Nome}");
            Console.WriteLine($"- 📞 Telefone: {contato.Telefone}");
            Console.WriteLine($"- 📧 Email: {contato.Email}");
            Console.WriteLine();
        }
    }
}

public class TabelaFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        Console.WriteLine("---------------------------------------------------------------");
        Console.WriteLine("| Nome             | Telefone        | Email           |");
        Console.WriteLine("---------------------------------------------------------------");

        foreach (var contato in contatos)
        {
            Console.WriteLine($"| {contato.Nome,-15} | {contato.Telefone,-15} | {contato.Email,-15} |");
        }

        Console.WriteLine("----------------------------------------------------------------");
    }
}

public class RawTextFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        foreach (var contato in contatos)
        {
            Console.WriteLine($"Nome: {contato.Nome} | Telefone: {contato.Telefone} | Email: {contato.Email}");
        }
    }
}

