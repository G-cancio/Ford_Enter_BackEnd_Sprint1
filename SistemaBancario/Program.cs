using System.Globalization;
using System.Runtime.CompilerServices;

namespace SistemaBancario
{
    public class Program
    {
        static void Main (string[] args)
        {
            ContaBancaria contaAtivo = null;
            int opcao = -1;

            while (opcao != 0)
            {
                try
                {
                    Console.WriteLine("==========BANCO DO BLASIR==========");
                    Console.WriteLine("Deseja criar uma conta bancária?\n" +
                                      "1 - Criar conta\n" +
                                      "0 - Sair");
                    Console.Write("Digite a opção que deseja: ");
                    string entrada = Console.ReadLine();
                    opcao = int.Parse(entrada);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nEntrada incorreta. Tente novamente.");
                    continue;
                }

                if (opcao == 1)
                {
                    try
                    {
                        Console.Write("\nDigite o nome do Titular: ");
                        string nomeTitular = Console.ReadLine();

                        while (string.IsNullOrWhiteSpace(nomeTitular) || !nomeTitular.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                        {
                            Console.WriteLine("Nome inválido! O titular deve conter apenas letras e espaços (sem números ou símbolos).");
                            Console.Write("Digite o nome do Titular novamente: ");
                            nomeTitular = Console.ReadLine();
                        }

                        Console.Write("\nDigite seu saldo inicial: ");
                        double saldoInicial = double.Parse(Console.ReadLine());

                        while (saldoInicial < 0)
                        {
                            Console.WriteLine("Valor inválido. O saldo não pode ser negativo.");
                            Console.Write("Digite o saldo novamente: ");
                            saldoInicial = double.Parse(Console.ReadLine());
                        }

                        int numeroConta = 1;

                        Console.WriteLine("\nEscolha o tipo de conta que deseja criar:\n" +
                                  "1 - Conta Corrente\n" +
                                  "2 - Conta Poupança\n" +
                                  "3 - Conta Empresarial");
                        Console.Write("Digite a opção que deseja: ");
                        int tipoConta = int.Parse(Console.ReadLine());

                        switch (tipoConta)
                        {
                            case 1:
                                contaAtivo = new ContaCorrente(numeroConta, nomeTitular, saldoInicial);
                                Console.WriteLine("\nConta Corrente criada com sucesso!");
                                break;
                            case 2:
                                contaAtivo = new ContaPoupanca(numeroConta, nomeTitular, saldoInicial);
                                Console.WriteLine("\nConta Poupança criada com sucesso!");
                                break;
                            case 3:
                                contaAtivo = new ContaEmpresarial(numeroConta, nomeTitular, saldoInicial);
                                Console.WriteLine("\nConta Empresarial criada com sucesso!");
                                break;
                            default:
                                Console.WriteLine("\n Tipo de conta inválido. A conta não foi criada.");
                                break;
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("\nErro na criação: Certifique-se de digitar apenas números válidos no saldo e tipo da conta.");
                        continue;
                    }

                    if (contaAtivo != null)
                    {
                        int opcaoConta = -1;

                        while (contaAtivo != null)
                        {
                            try
                            {
                                Console.WriteLine($"\n===CONTA DE {contaAtivo.Titular.ToUpper()}===");
                                Console.WriteLine("1 - Consultar Saldo\n" +
                                                  "2 - Sacar\n" +
                                                  "3 - Depositar");

                                if (contaAtivo is ContaPoupanca)
                                {
                                    Console.WriteLine("4 - Aplicar Rendimento");
                                }
                                else if (contaAtivo is ContaEmpresarial)
                                {
                                    Console.WriteLine("4 - Fazer empréstimo");
                                }

                                Console.WriteLine("0 - Sair da Conta");
                                Console.Write("Digite a opção que deseja: ");
                                opcaoConta = int.Parse(Console.ReadLine());

                                switch (opcaoConta)
                                {
                                    case 1:
                                        contaAtivo.ConsultarSaldo();
                                        break;
                                    case 2:
                                        Console.Write("\nDigite o valor que deseja sacar: R$");
                                        double valorSaque = double.Parse(Console.ReadLine());

                                        while (valorSaque <= 0)
                                        {
                                            Console.WriteLine("Valor inválido! O saque deve ser maior que zero.");
                                            Console.Write("Digite o valor que deseja sacar novamente: R$");
                                            valorSaque = double.Parse(Console.ReadLine());
                                        }

                                        contaAtivo.Sacar(valorSaque);
                                        break;
                                    case 3:
                                        Console.Write("\nDigite o valor que deseja depositar: R$");
                                        double valorDep = double.Parse(Console.ReadLine());

                                        while (valorDep <= 0)
                                        {
                                            Console.WriteLine("Valor inválido! O Depósito deve ser maior que zero.");
                                            Console.Write("Digite o valor que deseja depositar novamente: R$");
                                            valorDep = double.Parse(Console.ReadLine());
                                        }

                                        contaAtivo.Depositar(valorDep);
                                        break;
                                    case 4:
                                        if (contaAtivo is ContaPoupanca poupanca)
                                        {
                                            poupanca.AplicarRendimento();
                                        }
                                        else if (contaAtivo is ContaEmpresarial empresarial)
                                        {
                                            Console.Write("\nDigite o valor do empréstimo: R$");
                                            double valorEmp = double.Parse(Console.ReadLine());

                                            while (valorEmp <= 0)
                                            {
                                                Console.WriteLine("Valor inválido! O empréstimo deve ser maior que zero.");
                                                Console.Write("Digite o valor que deseja fazer o empréstimo novamente: R$");
                                                valorEmp = double.Parse(Console.ReadLine());
                                            }

                                            empresarial.FazerEmprestimo(valorEmp);
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nOpção de conta inválida.");
                                        }
                                        break;
                                    case 0:
                                        Console.WriteLine("\nSaindo da conta e Retornando ao menu principal...");
                                        contaAtivo = null;
                                        opcao = -1;
                                        break;
                                    default:
                                        Console.WriteLine("\nOpção digitada inválida.");
                                        break;
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("\nErro: Certifique-se de digitar apenas números válidos para valores e opções.");
                                continue;
                            }
                        }
                    }
                }
                else if (opcao == 0)
                {
                    Console.WriteLine("\nO sistema do Banco do Blasir está sendo encerrado... Obrigado!");
                }
                else
                {
                    Console.WriteLine("\nEntrada inválida. Escolha entre 1 para criar conta ou 0 para sair.");
                }
            }
        }
    }
}