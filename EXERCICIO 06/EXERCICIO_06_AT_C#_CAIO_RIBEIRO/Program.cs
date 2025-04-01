using System;

class Aluno
{
    public string Nome { get; set; }
    public string Matricula { get; set; }
    public string Curso { get; set; }
    public double MediaNotas { get; set; }

    // Método que exibir os dados do aluno
    public void ExibirDados()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Matrícula: {Matricula}");
        Console.WriteLine($"Curso: {Curso}");
        Console.WriteLine($"Média das Notas: {MediaNotas}");
    }

    // Método que verifica aprovação
    public string VerificarAprovacao()
    {
        return MediaNotas >= 7 ? "Aprovado" : "Reprovado";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Criando um objeto da classe Aluno 
        Aluno aluno = new Aluno()
        {
            Nome = "Caio Ribeiro Pereira",
            Matricula = "202563525",
            Curso = "Engenharia de Software",
            MediaNotas = 8.5
        };

        aluno.ExibirDados();

        Console.WriteLine($"Situação: {aluno.VerificarAprovacao()}");
    }
}
