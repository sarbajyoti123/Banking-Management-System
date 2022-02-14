using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace OnlineBankingSystem
{
    public class BankMain
    {
        private static string e;

        public static void Main(String[] args)
        {
            bool a = true;
            Dictionary<int, double> d1 = new Dictionary<int, double>();
            Dictionary<int, object> d2 = new Dictionary<int, object>();
            List<string> innerlist = new List<string>();
            Dictionary<int, string> debitlist = new Dictionary<int, string>();
            while (a)
            {
                Console.WriteLine("Choose any option to perform : ");
                Console.WriteLine("------------------------------------------------------------------------------");
                Console.WriteLine("1.Create an account ");
                Console.WriteLine("2.Withdraw amount ");
                Console.WriteLine("3.Deposit amount ");
                Console.WriteLine("4.Update an account ");
                Console.WriteLine("5.Delete an account ");
                Console.WriteLine("6.Apply for loan ");
                Console.WriteLine("7.Check account balance ");
                Console.WriteLine("8.Exit ");
                Console.WriteLine("------------------------------------------------------------------------------");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.Write("You choosed option : ");
                Account a1 = new Account();

                switch (n)
                {
                    case 1:
                        Console.Write("Create an acccount \n");
                        Console.Write("Enter your name : ");
                        int z;
                        string name = Convert.ToString(Console.ReadLine());
                        if (int.TryParse(name, out z) || string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                        {
                            Console.WriteLine("------------------------------------------------------------------------------");
                            Console.WriteLine("Invalid Input");
                            Console.WriteLine("------------------------------------------------------------------------------");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Select type of account : ");
                            Console.WriteLine("1.Savings account");
                            Console.WriteLine("2.Salary account");
                            int sec = Convert.ToInt32(Console.ReadLine());
                            a1.create(sec, name, d1, d2, innerlist, debitlist, a, e);
                            break;
                        }
                    case 2:
                        Console.Write("Withdraw amount \n");
                        try
                        {
                            Console.Write("Enter account number : ");
                            int accn = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter the value to withdraw : ");
                            try
                            {
                                double val = Convert.ToDouble(Console.ReadLine());
                                if (val > 0)
                                {
                                    a1.withdraw(accn, val, d1, a);
                                }
                                else
                                {
                                    Console.WriteLine("------------------------------------------------------------------------------");
                                    Console.WriteLine("Please provide valid amount");
                                    Console.WriteLine("------------------------------------------------------------------------------");
                                }

                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("------------------------------------------------------------------------------");
                                Console.WriteLine("Please provide valid amount");
                                Console.WriteLine("------------------------------------------------------------------------------");

                            }

                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("------------------------------------------------------------------------------");
                            Console.WriteLine("Please provide valid input");
                            Console.WriteLine("------------------------------------------------------------------------------");
                            break;
                        }
                    case 3:
                        Console.Write("Deposit amount \n");
                        try
                        {
                            Console.Write("Enter account number : ");
                            int accnum = Convert.ToInt32(Console.ReadLine());
                            try
                            {
                                Console.Write("Enter the value to deposit : ");
                                double val1 = Convert.ToDouble(Console.ReadLine());
                                if (val1 > 0)
                                {
                                    a1.depositAmount(accnum, val1, d1, a);
                                }
                                else
                                {
                                    Console.WriteLine("------------------------------------------------------------------------------");
                                    Console.WriteLine("Please provide valid amount");
                                    Console.WriteLine("------------------------------------------------------------------------------");
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("------------------------------------------------------------------------------");
                                Console.WriteLine("Please provide valid amount");
                                Console.WriteLine("------------------------------------------------------------------------------");
                            }

                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("------------------------------------------------------------------------------");
                            Console.WriteLine("Please provide valid input");
                            Console.WriteLine("------------------------------------------------------------------------------");
                            break;
                        }
                    case 4:
                        Console.Write("Update an account \n");
                        Console.WriteLine("");
                        try
                        {
                            Console.Write("Enter your account number : ");
                            int accnumber = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter account holders name : ");
                            string name1 = Console.ReadLine();
                            a1.update(accnumber, name1, d2, innerlist);
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("------------------------------------------------------------------------------");
                            Console.WriteLine("Please provide valid input");
                            Console.WriteLine("------------------------------------------------------------------------------");
                            break;
                        }
                    case 5:
                        Console.Write("Delete an account \n");
                        Console.Write("Enter account number to delete : ");
                        try
                        {
                            int acn = Convert.ToInt32(Console.ReadLine());
                            a1.delete(acn, d1, d2, innerlist);
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("------------------------------------------------------------------------------");
                            Console.WriteLine("Please provide valid amount");
                            Console.WriteLine("------------------------------------------------------------------------------");
                            break;
                        }
                    case 6:
                        Console.Write("Apply for loan \n");
                        Console.WriteLine("Do you want to apply for loan ?");
                        Console.WriteLine("1.Yes");
                        Console.WriteLine("2.No");
                        int y = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("You choosed option : " + y);
                        a1.loan(d1, y);
                        break;
                    case 7:
                        Console.Write("Check account balance \n");
                        try
                        {
                            Console.Write("Enter your account number : ");
                            int acc = Convert.ToInt32(Console.ReadLine());
                            a1.balancecheck(d1, acc);
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("------------------------------------------------------------------------------");
                            Console.WriteLine("Please provide valid amount");
                            Console.WriteLine("------------------------------------------------------------------------------");
                            break;
                        }         
                    default:
                        Console.Write("Exit \n");
                        Console.WriteLine("------------------------------------------------------------------------------");
                        Console.WriteLine("Thankyou");
                        Console.WriteLine("------------------------------------------------------------------------------");
                        a = false;
                        break;
                }
            }

        }
    }
}
