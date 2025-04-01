using System;

class Program
{
    static void Main()
    {
        // Solicita ao usuário a data de nascimento
        Console.Write("Digite sua data de nascimento (dd/MM/yyyy): ");
        DateTime dataNascimento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null); // Converte para DateTime

        DateTime hoje = DateTime.Today; // Data atual

        // Verifica se a data de nascimento é no futuro
        if (dataNascimento > hoje)
        {
            Console.WriteLine("A data de nascimento não pode ser no futuro!!!");
            return;
        }

        DateTime proximoAniversario = new DateTime(hoje.Year, dataNascimento.Month, dataNascimento.Day); // Próximo aniversário

        // Se o aniversário já passou este ano, passa para o próximo ano
        if (proximoAniversario < hoje)
        {
            proximoAniversario = proximoAniversario.AddYears(1);
        }

        int diasFaltando = (proximoAniversario - hoje).Days; // Calcula os dias que faltam para o próximo aniversário

        // Exibe a quantidade de dias restantes para o próximo aniversário
        Console.WriteLine($"Faltam {diasFaltando} dias para seu próximo aniversário!");

        // Exibe uma mensagem especial se faltar menos de 7 dias
        if (diasFaltando < 7)
        {
            Console.WriteLine("Está chegando!!!:) Feliz quase aniversário!!!");
        }
    }
}
