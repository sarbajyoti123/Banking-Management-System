using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace OnlineBankingSystem
{
    class Account
    {
        int accno;
        string name, type, debitno;
        public int deposit;
        bool contain = false;
        int g;

        public void create(int sec, string name, Dictionary<int, double> d1, Dictionary<int, object> d2, List<string> innerlist, Dictionary<int, string> debitlist, bool a,string e)
        {
            if (sec == 1)
            {
                while (contain == false)
                {
                    Random r = new Random();
                    this.accno = r.Next(10000);
                    this.name = name.ToLower();
                    this.type = "savings";
                    if (d1.ContainsKey(this.accno))
                    {
                        contain = true;
                        create(sec, name, d1, d2, innerlist, debitlist, a,e); //??
                    }
                    else
                    {
                        d1.Add(this.accno, this.deposit);
                        d2.Add(this.accno, innerlist);
                        innerlist.Add(this.name);
                        innerlist.Add(this.type);
                        Console.WriteLine("------------------------------------------------------------------------------");
                        Console.WriteLine("Savings Account created for " + this.name + " with account number : " + this.accno);
                        Console.WriteLine("------------------------------------------------------------------------------");
                        Console.WriteLine(" ");
                        Console.WriteLine("Do you want to opt for debit card!!!");
                        Console.WriteLine("1.Yes");
                        Console.WriteLine("2.No");
                        this.g = Convert.ToInt32(Console.ReadLine());
                        if ((this.g).ToString() == e)
                        {
                            break;
                        }
                        Console.WriteLine("You choosed option : " + this.g);
                        debit(this.accno, g, debitlist);
                        contain = true;
                    }
                }
            }
            else if(sec==2)
            {
                while (contain == false)
                {
                    Random r = new Random();
                    this.accno = r.Next(100000);
                    this.name = name.ToLower();
                    this.type = "salary";
                    if (d1.ContainsKey(this.accno))
                    {
                        contain = true;
                        create(sec, name, d1, d2, innerlist, debitlist, a,e);
                    }
                    else
                    {
                        d1.Add(this.accno, this.deposit);
                        d2.Add(this.accno, innerlist);
                        innerlist.Add(this.name);
                        innerlist.Add(this.type);
                        Console.WriteLine("------------------------------------------------------------------------------");
                        Console.WriteLine("Salary Account created for " + this.name + " with account number : " + this.accno);
                        Console.WriteLine("------------------------------------------------------------------------------");
                        Console.WriteLine(" ");
                        Console.WriteLine("Do you want to opt for debit card!!!");
                        Console.WriteLine("1.Yes");
                        Console.WriteLine("2.No");
                        this.g = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("You choosed option : " + this.g);
                        debit(this.accno, g, debitlist);
                        contain = true;
                    }
                }
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("------------------------------------------------------------------------------");
                Console.WriteLine("Invalid Input!!!!");
                Console.WriteLine("------------------------------------------------------------------------------");
            }
        }

        public void debit(int accno, int g, Dictionary<int, string> debitlist)
        {
            if (g == 1)
            {
                Random generator = new Random();
                string r = generator.Next(0, 9999).ToString("D4");
                string r1 = generator.Next(0, 9999).ToString("D4");
                string r2 = generator.Next(0, 9999).ToString("D4");
                string r3 = generator.Next(0, 9999).ToString("D4");

                this.debitno = r + " " + r1 + " " + r2 + " " + r3;
                if (debitlist.ContainsValue(this.debitno))
                {
                    debit(accno, g, debitlist);
                }
                else
                {
                    debitlist.Add(accno, r + " " + r1 + " " + r2 + " " + r3);
                    if (debitlist.ContainsKey(accno))
                    {
                        Console.WriteLine("------------------------------------------------------------------------------");
                        Console.WriteLine("Your debit card is created and the number is : " + debitlist[accno]);
                        Console.WriteLine("------------------------------------------------------------------------------");
                        Console.WriteLine("\n");
                    }
                    else
                    {
                        Console.WriteLine("------------------------------------------------------------------------------");
                        Console.WriteLine("No such account");
                        Console.WriteLine("------------------------------------------------------------------------------");
                        Console.WriteLine("\n");
                    }
                }

            }

            if (g == 2)
            {
                Console.WriteLine("------------------------------------------------------------------------------");
                Console.WriteLine("ThankYou for banking!!");
                Console.WriteLine("------------------------------------------------------------------------------");
                Console.WriteLine("\n");
            }
        }

        public void withdraw(int accn, double value, Dictionary<int, double> d1, bool a)
        {
            if (d1.ContainsKey(accn))
            {
                if (d1[accn] < 0 || d1[accn] < value)
                {
                    Console.WriteLine("------------------------------------------------------------------------------");
                    Console.WriteLine("Sorry your balance is low.");
                    Console.WriteLine("------------------------------------------------------------------------------");
                    Console.WriteLine("\n");
                }
                else
                {
                    d1[accn] = Math.Round((d1[accn] - value),2);
                    Console.WriteLine("------------------------------------------------------------------------------");
                    Console.WriteLine("Amount has been withdrawn and tha available balance is " + d1[accn]);
                    Console.WriteLine("------------------------------------------------------------------------------");
                    Console.WriteLine("\n");
                }
            }
            else
            {
                Console.WriteLine("------------------------------------------------------------------------------");
                Console.WriteLine("No such account");
                Console.WriteLine("------------------------------------------------------------------------------");
                a = false;
            }
        }

        public void depositAmount(int accnum, double value1, Dictionary<int, double> d1, bool a)
        {
            if (d1.ContainsKey(accnum))
            {
                d1[accnum] = Math.Round((d1[accnum] + value1),2);
                Console.WriteLine("------------------------------------------------------------------------------");
                Console.WriteLine("Amount has been deposited and the available balance is : " + d1[accnum]);
                Console.WriteLine("------------------------------------------------------------------------------");
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("------------------------------------------------------------------------------");
                Console.WriteLine("No such account");
                Console.WriteLine("------------------------------------------------------------------------------");
                Console.WriteLine("\n");
                a = false;
            }
        }

        public void update(int accnumber, string name, Dictionary<int, object> d2, List<string> innerlist)
        {
            this.name = name.ToLower();
            Console.WriteLine("");
            Console.WriteLine("Choose what needs to be updated ");
            Console.WriteLine("1.Name ");
            Console.WriteLine("2.Account type ");
            Console.WriteLine("3.Exit ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("You choosed option : " + n);
            switch (n)
            {
                case 1:
                    Console.WriteLine("");
                    Console.Write("Enter name to update : ");
                    string str = Console.ReadLine();
                    if (d2.ContainsKey(accnumber) || innerlist.Contains(this.name))
                    {
                        ((List<string>)d2[accnumber]).Add(str); 
                        ((List<string>)d2[accnumber]).Add(innerlist[1]); //???
                        ((List<string>)d2[accnumber]).Remove(name); 
                        ((List<string>)d2[accnumber]).Remove(innerlist[0]); //??

                        if (d2.ContainsKey(accnumber))
                        {
                            foreach (string item in innerlist)
                            {
                                if (item.Contains(str))
                                {
                                    Console.WriteLine("------------------------------------------------------------------------------");
                                    Console.WriteLine("Account updated with name as " + str);
                                    Console.WriteLine("------------------------------------------------------------------------------");
                                    Console.WriteLine("\n");
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("------------------------------------------------------------------------------");
                        Console.WriteLine("Either Account does not exists or Account name entered is incorrect!!");
                        Console.WriteLine("------------------------------------------------------------------------------");
                    }
                    
                    break;
                case 2:
                    if (innerlist[1] == "savings")
                    {
                        Console.WriteLine("Do you want to update account type from " + innerlist[1] + " to " + "salary");
                    }
                    else
                    {
                        Console.WriteLine("Do you want to update account type from " + innerlist[1] + " to " + "savings");
                    }
                    Console.WriteLine("1.Yes");
                    Console.WriteLine("2.No");
                    int x = Convert.ToInt32(Console.ReadLine());
                    if (x == 1)
                    {
                        if (innerlist[1] == "savings")
                        {
                            if (d2.ContainsKey(accnumber) && innerlist.Contains(name))
                            {
                                ((List<string>)d2[accnumber]).Add(innerlist[0]); //??
                                ((List<string>)d2[accnumber]).Add("salary"); //??
                                ((List<string>)d2[accnumber]).Remove(innerlist[0]);
                                ((List<string>)d2[accnumber]).Remove(innerlist[1]);
                            }
                            else
                            {
                                Console.WriteLine("------------------------------------------------------------------------------");
                                Console.WriteLine("Either Account does not exists or Account name entered is incorrect!!");
                                Console.WriteLine("------------------------------------------------------------------------------");
                            }
                            if (d2.ContainsKey(accnumber))
                            {
                                foreach (string item in innerlist)
                                {
                                    if (item.Contains("salary"))
                                    {
                                        Console.WriteLine("------------------------------------------------------------------------------");
                                        Console.WriteLine("Account updated with type as salary");
                                        Console.WriteLine("------------------------------------------------------------------------------");
                                        Console.WriteLine("\n");
                                    }
                                }
                            }
                        }
                        else if(innerlist[1] == "salary")
                        {
                            if (d2.ContainsKey(accnumber) && innerlist.Contains(name))
                            {
                                ((List<string>)d2[accnumber]).Add(innerlist[0]);
                                ((List<string>)d2[accnumber]).Add("savings");
                                ((List<string>)d2[accnumber]).Remove(innerlist[0]);
                                ((List<string>)d2[accnumber]).Remove(innerlist[1]);
                            }
                            else
                            {
                                Console.WriteLine("------------------------------------------------------------------------------");
                                Console.WriteLine("Either Account does not exists or Account name entered is incorrect!!");
                                Console.WriteLine("------------------------------------------------------------------------------");
                            }
                            if (d2.ContainsKey(accnumber))
                            {
                                foreach (string item in innerlist)
                                {
                                    if (item.Contains("salary"))
                                    {
                                        Console.WriteLine("------------------------------------------------------------------------------");
                                        Console.WriteLine("Account updated with type as salary");
                                        Console.WriteLine("------------------------------------------------------------------------------");
                                        Console.WriteLine("\n");
                                    }
                                }
                            }
                        }
                            
                    }
                    else if (x == 2)
                    {
                        Console.WriteLine("ThankYou for Banking");
                    }
                    break;
                default:
                    break;
            }
        }

        public void loan(Dictionary<int, double> d1, int y)
        {
            try
            {
                
                if (y == 1)
                {
                    Console.Write("Enter your account number : ");
                    int acc = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter the loan amount : ");
                    int loanvalue = Convert.ToInt32(Console.ReadLine());
                    if (d1.ContainsKey(acc))
                    {
                        if (loanvalue > 0)
                        {
                            if (d1[acc] > 0)
                            {
                                if (loanvalue < 0.5 * d1[acc])
                                {
                                    Console.WriteLine("------------------------------------------------------------------------------");
                                    Console.WriteLine("You are eligible for loan,bank will contact you shortly!!!!!!");
                                    Console.WriteLine("------------------------------------------------------------------------------");
                                }
                                else
                                {
                                    Console.WriteLine("------------------------------------------------------------------------------");
                                    Console.WriteLine("Sorry!!!! You are not eligible for loan");
                                    Console.WriteLine("------------------------------------------------------------------------------");
                                }
                            }
                            else
                            {
                                Console.WriteLine("------------------------------------------------------------------------------");
                                Console.WriteLine("No enough balance");
                                Console.WriteLine("------------------------------------------------------------------------------");
                            }
                        }
                        else
                        {
                            Console.WriteLine("------------------------------------------------------------------------------");
                            Console.WriteLine("Loan value cannot be negative");
                            Console.WriteLine("------------------------------------------------------------------------------");
                        }

                    }
                    else
                    {
                        Console.WriteLine("------------------------------------------------------------------------------");
                        Console.WriteLine("No such account");
                        Console.WriteLine("------------------------------------------------------------------------------");
                    }
                }
                else if (y == 2)
                {
                    Console.WriteLine("------------------------------------------------------------------------------");
                    Console.WriteLine("Thanks for banking with us!!");
                    Console.WriteLine("------------------------------------------------------------------------------");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("------------------------------------------------------------------------------");
                Console.WriteLine("Please provide valid account number");
                Console.WriteLine("------------------------------------------------------------------------------");
            }
            
        }

        public void delete(int acn, Dictionary<int, double> d1, Dictionary<int, object> d2, List<string> innerlist)
        {
            if (d1.ContainsKey(acn) && d2.ContainsKey(acn))
            {
                d1.Remove(acn);
                d2.Remove(acn);
                Console.WriteLine("------------------------------------------------------------------------------");
                Console.WriteLine("Account deleted successfully");
                Console.WriteLine("------------------------------------------------------------------------------");
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("------------------------------------------------------------------------------");
                Console.WriteLine("No such account");
                Console.WriteLine("------------------------------------------------------------------------------");
                Console.WriteLine("\n");
            }
        }

        public void balancecheck(Dictionary<int, double> d1, int acc)
        {

            foreach (KeyValuePair<int, double> kv in d1)
            {
                if (kv.Key == acc)
                {
                    Console.WriteLine("------------------------------------------------------------------------------");
                    Console.Write("Your account balance is : ");
                    Console.Write(kv.Value + "\n");
                    Console.WriteLine("------------------------------------------------------------------------------");
                }
            }
        }

    }
}

