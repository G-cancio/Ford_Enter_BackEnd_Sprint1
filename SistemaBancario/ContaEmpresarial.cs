namespace SistemaBancario
{
    public class ContaEmpresarial : ContaBancaria
    {
        public double EmprestimoExtra {  get; private set; }

        public ContaEmpresarial (int numeroConta, string titular, double saldo)
            : base (numeroConta, titular, saldo)
        {
            EmprestimoExtra = 5000.0;
        }

        public override void Sacar(double valor)
        {
            if (Saldo >= valor)
            {
                Saldo -= valor;
                Console.WriteLine($"\nSaque efetuado com sucesso!\n" +
                                  $"Valor do saque: R${valor}");
            }
            else
            {
                Console.WriteLine("\nErro! Saldo insuficiente para o saque.");
            }
        }

        public void FazerEmprestimo (double valor)
        {
            if (valor <= EmprestimoExtra)
            {
                Saldo += valor;
                EmprestimoExtra -= valor;

                Console.WriteLine("\nEmpréstimo aprovado!\n" +
                                  $"Valor do empréstimo: {valor}");
            }
            else
            {
                Console.WriteLine($"\nValor requisitado alto demais. Seu limite de empréstimo é de R${EmprestimoExtra}");
            }
        }
    }
}