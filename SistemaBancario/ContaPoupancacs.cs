namespace SistemaBancario
{
    public class ContaPoupanca : ContaBancaria
    {
        public double TaxaRendimento { get; private set; }

        public ContaPoupanca (int numeroConta, string titular, double saldo)
            : base (numeroConta, titular, saldo)
        {
            TaxaRendimento = 0.01;
        }

        public override void Sacar(double valor)
        {
            if (Saldo >= valor)
            {
                Saldo -= valor;
                Console.WriteLine($"\nSaque efetuado com sucesso!\n" +
                                  $"Valor do saque: R${valor}");
            } else
            {
                Console.WriteLine("\nErro! Saldo insuficiente para o saque.");
            }
        }

        public void AplicarRendimento ()
        {
            double rendimentoTotal = Saldo * TaxaRendimento;
            Saldo += rendimentoTotal;

            Console.WriteLine($"\nRendimento do mês: R${rendimentoTotal}");
        }
    }
}