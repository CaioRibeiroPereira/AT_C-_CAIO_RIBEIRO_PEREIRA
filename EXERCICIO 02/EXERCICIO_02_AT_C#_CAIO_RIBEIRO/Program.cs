using System;

class Program
{
    static void Main()
    {
        // Solicita o nome completo do usuário
        Console.Write("Por Favor!!!Digite seu nome completo: ");
        string nome = Console.ReadLine();

        // Aplica a cifra ao nome digitado
        string nomeCifra = CifrarNome(nome);

        // Exibe nome cifrado
        Console.WriteLine("Nome cifrado: " + nomeCifra);
    }

    // Método para cifrar o nome
    static string CifrarNome(string nome)
    {
        char[] caracteres = nome.ToCharArray(); // Converte a string em um array 

        for (int i = 0; i < caracteres.Length; i++)
        {
            if (char.IsLetter(caracteres[i])) // Verifica se o caractere é uma letra 
            {
                char letra = char.IsUpper(caracteres[i]) ? 'A' : 'a'; //Maiúsculas e minúsculas

                // Desloca a letra duas posições para frente no alfabeto
                caracteres[i] = (char)(letra + (caracteres[i] - letra + 2) % 26);
            }
        }

        return new string(caracteres); // Retorna o nome cifrado 
    }
}
