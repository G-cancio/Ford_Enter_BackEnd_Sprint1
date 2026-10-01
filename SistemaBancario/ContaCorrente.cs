namespace SistemaBancario
{
    public class ContaCorrente : ContaBancaria
    {
        public double TaxaSaque { get; private set; }

        public ContaCorrente (int numeroConta, string titular, double saldo)
            : base (numeroConta, titular, saldo)
        {
            TaxaSaque = 0.05;
        }

        public override void Sacar(double valor)
        {

            double valorTaxa = valor * TaxaSaque;
            double valorTotalDescontado = valor + valorTaxa;

            if (Saldo >= valorTotalDescontado)
            {
                Saldo -= valorTotalDescontado;
                Console.WriteLine($"\nSaque efetuado com sucesso!\n" +
                                  $"Saque: R${valor}\n" +
                                  $"Taxa: R${valorTaxa}\n" +
                                  $"Total descontado: R${valorTotalDescontado}");
            }
            else
            {
                Console.WriteLine("\nErro! Saldo insuficiente para o saque e a taxa.");
            }
        }
    }
}