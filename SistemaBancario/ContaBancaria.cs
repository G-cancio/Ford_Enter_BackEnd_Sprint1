namespace SistemaBancario
{
    public abstract class ContaBancaria
    {
        public int NumeroConta {  get; private set; }
        public string Titular { get; private set; }
        public double Saldo { get; protected set; }

        protected ContaBancaria (int numeroConta, string titular, double saldo)
        {
            NumeroConta = numeroConta;
            Titular = titular;
            Saldo = saldo;
        }

        public abstract void Sacar(double valor);

        public void Depositar(double valor)
        {
            if (valor > 0)
            {
                Saldo += valor;
                Console.WriteLine($"\nUm valor de R${valor} foi depositado com sucesso!");
            } else
            {
                Console.WriteLine("\nErro! O valor depositado precisa ser maior que zero.");
            }
        }

        public void ConsultarSaldo ()
        {
            Console.WriteLine ($"\nSaldo atual: R${Saldo}");
        }
    }
}