using System;

class Funcionario
{
    public string Nome { get; set; }
    public string Cargo { get; set; }
    public double SalarioBase { get; set; }

    public Funcionario(string nome, string cargo, double salarioBase)
    {
        Nome = nome;
        Cargo = cargo;
        SalarioBase = salarioBase;
    }

    public virtual double CalcularSalario()
    {
        return SalarioBase;
    }

    public override string ToString()
    {
        return $"Nome: {Nome}\nCargo: {Cargo}\nSalário Base: R$ {SalarioBase}";
    }
}

// Subclasse Gerente
class Gerente : Funcionario
{
    public Gerente(string nome, string cargo, double salarioBase)
        : base(nome, cargo, salarioBase) { }

    public override double CalcularSalario()
    {
        return SalarioBase * 1.20; // Bônus de 20% no salário
    }
}

// Classe Principal
class Program
{
    static void Main()
    {
        Funcionario funcionario = new Funcionario("Jorge", "Assistente", 2500.00);
        Gerente gerente = new Gerente("Caio", "Gerente", 5000.00);

        Console.WriteLine("Funcionário:");
        Console.WriteLine(funcionario);
        Console.WriteLine($"Salário: R$ {funcionario.CalcularSalario():F2}");

        Console.WriteLine("\nGerente:");
        Console.WriteLine(gerente);
        Console.WriteLine($"Salário com bônus: R$ {gerente.CalcularSalario():F2}");
    }
}
