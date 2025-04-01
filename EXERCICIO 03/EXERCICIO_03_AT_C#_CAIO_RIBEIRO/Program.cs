using System;

class Program
{
    static void Main()
    {
        // Solicita os dois números ao usuário
        double numero1 = NumeroSolicitado("Por favor digite o seu primeiro número: ");
        double numero2 = NumeroSolicitado("Por favor digite o segundo número: ");

        // Exibe o menu 
        Console.WriteLine("Escolha uma operação:");
        Console.WriteLine("1 para Soma");
        Console.WriteLine("2 para Subtração");
        Console.WriteLine("3 para Multiplicação");
        Console.WriteLine("4 para Divisão");

        // Escolha do usuário
        int escolha = FazerEscolhaOperacao();

        try
        {
            // Realiza o cálculo de acordo com a escolha do usuário
            double resultado = Calcular(numero1, numero2, escolha);
            Console.WriteLine($"O resultado é: {resultado}");
        }
        catch (DivideByZeroException e)
        {
            // Trata a exceção de divisão por zero
            Console.WriteLine(e.Message);
        }
    }

    // Método solicita um número
    static double NumeroSolicitado(string prompt)
    {
        double numero;
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out numero))
                return numero;
            Console.WriteLine("Tente Novamente!!! Número Inválido");
        }
    }

    // Método solicita e valida a escolha de operação
    static int FazerEscolhaOperacao()
    {
        int escolha;
        while (true)
        {
            Console.Write("Digite o número correspondente à sua operação de 1 a 4 para calcular: ");
            if (int.TryParse(Console.ReadLine(), out escolha) && escolha >= 1 && escolha <= 4)
                return escolha;
            Console.WriteLine("Tente Novamente!!! Opção Inválida, somente de 1 a 4!");
        }
    }

    // Método faz o cálculo de acordo na operação escolhida
    static double Calcular(double numero1, double numero2, int operacao)
    {
        return operacao switch
        {
            1 => numero1 + numero2, // Soma
            2 => numero1 - numero2, // Subtração
            3 => numero1 * numero2, // Multiplicação
            4 => numero2 != 0 ? numero1 / numero2 : throw new DivideByZeroException("Erro: Divisão por zero não é permitida!"), // Divisão com verificação
            _ => 0 
        };
    }
}