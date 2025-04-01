using System;

class Program
{
    static void Main()
    {
        Random random = new Random();
        int numeroSecreto = random.Next(1, 51); // Usei 51 para certificar de incluir o 50
        int tentativas = 5;
        bool acertou = false;

        Console.WriteLine("Bem-vindo ao Jogo de Adivinhação!");
        Console.WriteLine("Você tem 5 tentativas para adivinhar o número entre 1 e 50.");

        while (tentativas > 0 && !acertou)
        {
            Console.Write("Digite seu palpite: ");
            string entrada = Console.ReadLine();
            int palpite;

            // Tratamento de exceção 
            if (int.TryParse(entrada, out palpite))
            {
                if (palpite < 1 || palpite > 50)
                {
                    Console.WriteLine("Erro: O número deve estar entre 1 e 50.");
                    continue;
                }

                if (palpite == numeroSecreto)
                {
                    acertou = true;
                    Console.WriteLine("Parabéns! Você acertou o número!");
                }
                else
                {
                    tentativas--;
                    if (palpite < numeroSecreto)
                    {
                        Console.WriteLine("O número secreto é maior. Tentativas restantes: " + tentativas);
                    }
                    else
                    {
                        Console.WriteLine("O número secreto é menor. Tentativas restantes: " + tentativas);
                    }
                }
            }
            else
            {
                Console.WriteLine("Erro: Por favor, insira um número válido.");
            }
        }

        if (!acertou)
        {
            Console.WriteLine("Você perdeu! O número secreto era " + numeroSecreto + ". Tente Novamente!!!");
        }
    }
}
