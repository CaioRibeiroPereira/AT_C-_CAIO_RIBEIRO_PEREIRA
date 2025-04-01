using System;

class ContaBancaria
{
    //Público para armazenar o nome do titular da conta
    public string Titular;

    //Privado para armazenar o saldo da conta
    private decimal saldo;

    // Construtor da classe que inicializa o titular e o saldo
    public ContaBancaria(string titular)
    {
        Titular = titular;
        saldo = 0;
    }

    // Método para depositar um valor na conta
    public void Depositar(decimal valor)
    {
        if (valor > 0) // Verifica se o valor é positivo
        {
            saldo += valor;
            Console.WriteLine($"Depósito de R$ {valor:F2} realizado com sucesso!");
        }
        else
        {
            Console.WriteLine("O valor do depósito deve ser positivo!");
        }
    }

    // Sacar um valor da conta
    public void Sacar(decimal valor)
    {
        if (valor > saldo) // Verifica se há saldo suficiente
        {
            Console.WriteLine("Saldo insuficiente para realizar o saque!");
        }
        else if (valor > 0) // Verifica se o valor do saque é maior que 0
        {
            saldo -= valor;
            Console.WriteLine($"Saque de R$ {valor:F2} realizado com sucesso!");
        }
        else
        {
            Console.WriteLine("O valor do saque deve ser positivo!");
        }
    }

    // Exibir o saldo atual da conta
    public void ExibirSaldo()
    {
        Console.WriteLine($"Saldo atual: R$ {saldo:F2}");
    }
}

// Classe principal do programa
class Program
{
    static void Main()
    {
        // Cria um objeto ContaBancaria
        ContaBancaria conta = new ContaBancaria("João Silva");
        Console.WriteLine($"Titular: {conta.Titular}\n");

        // Realiza um depósito 
        conta.Depositar(500);
        conta.ExibirSaldo();

        // Tenta saque maior que o saldo disponível
        Console.WriteLine("\nTentativa de saque: R$ 700,00");
        conta.Sacar(700);

        // Realiza um saque
        conta.Sacar(200);
        conta.ExibirSaldo();
    }
}
