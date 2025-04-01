using System;

class Program
{
    static void Main()
    {
        // Data prevista da formatura
        DateTime dataFormatura = new DateTime(2026, 12, 15);

        // Data atual do usuário
        Console.Write("Digite a data atual (dd/MM/yyyy): ");
        string entrada = Console.ReadLine();

        // Converte a entrada do usuário para DateTime
        if (DateTime.TryParseExact(entrada, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dataAtual))
        {
            // Verifica se a data atual não é futura
            if (dataAtual > DateTime.Now)
            {
                Console.WriteLine("Erro: A data informada não pode ser no futuro!");
                return;
            }

            // Verificar se a data de formatura já passou
            if (dataAtual > dataFormatura)
            {
                Console.WriteLine("Parabéns! Você já deveria estar formado!");
                return;
            }

            // Calcular o tempo restante para a formatura
            int anosRestantes = dataFormatura.Year - dataAtual.Year;
            int mesesRestantes = dataFormatura.Month - dataAtual.Month;
            int diasRestantes = dataFormatura.Day - dataAtual.Day;

            if (mesesRestantes < 0)
            {
                anosRestantes--;
                mesesRestantes += 12;
            }

            if (diasRestantes < 0)
            {
                mesesRestantes--;
                diasRestantes += DateTime.DaysInMonth(dataAtual.Year, dataAtual.Month);
            }

            Console.WriteLine($"Faltam {anosRestantes} anos, {mesesRestantes} meses e {diasRestantes} dias para sua formatura!");

            // Verificar se faltar menos de 6 meses
            if (anosRestantes == 0 && mesesRestantes < 6)
            {
                Console.WriteLine("A reta final chegou! Prepare-se para a formatura!");
            }
        }
        else
        {
            Console.WriteLine("Erro: A data informada é inválida!");
        }
    }
}
