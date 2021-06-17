using System;

//Sam Howsden
//IT112
//NOTES: Didn't run into any issues really. Just took a bit of time to implement the enum.
    //Also, it took me a bit of work to get the weekly printout at the end to work. I didn't
    //run into any issues with the interface or other classes.
//BEHAVIORS NOT IMPLEMENTED AND WHY: I believe I implemented every required behavior.
namespace Howsden_CashFlowManager
{
    class Program
    {
        static void Main(string[] args)
        {
            int menuSelection;
            IPayable[] ledger = new IPayable[50];
            ledger[0] = new HourlyEmployee("Thomas", "Burbank", "135-45-4653", 21.55M, 40);
            ledger[1] = new HourlyEmployee("Sandra", "Newark", "456-86-8319", 21.55M, 40);
            ledger[2] = new HourlyEmployee("Mary", "Hardew", "947-26-7311", 24.31M, 42.5M);
            ledger[3] = new SalariedEmployee("Larry", "Daryn", "331-14-6248", 850);
            ledger[4] = new SalariedEmployee("Harold", "Kartin", "551-36-1848", 900);
            ledger[5] = new SalariedEmployee("Jerry", "Werther", "674-46-7413", 943.45M);
            ledger[6] = new Invoice("4631", "New Dell 27 in. Monitors", 25, 139.49M);
            ledger[7] = new Invoice("7916", "KE68 Multi-Device Ergonomic Keyboard", 25, 74.99M);
            ledger[8] = new Invoice("8715", "Dell Precision 5820 Business Desktop", 25, 1699.00M);

            do
            {
                do
                {
                    Console.WriteLine("Select one of the below options:\n1. Add an Hourly Employee\n" +
                        "2. Add a Salaried Employee\n3. Add an Invoice\n4. Generate Weekly Report");
                    menuSelection = Console.ReadKey().KeyChar;
                    Console.Clear();
                } while (!(menuSelection >= 49 && menuSelection <= 52));
                if (menuSelection != 52)
                {
                    int emptyLocation = 0;
                    for (int i = 9; i < ledger.Length; i++)
                    {
                        if (ledger[i] == null)
                        {
                            emptyLocation = i;
                            break;
                        }
                        else
                            emptyLocation = -1;
                    }
                    if (emptyLocation != -1)
                    {
                        if (menuSelection == 49)
                        {
                            Console.Write("Hourly Employee First Name: ");
                            string firstName = Console.ReadLine();
                            Console.Clear();
                            Console.Write("Hourly Employee Last Name: ");
                            string lastName = Console.ReadLine();
                            Console.Clear();
                            Console.Write("Hourly Employee SSN: ");
                            string SSN = Console.ReadLine();
                            Console.Clear();
                            Console.Write("Hourly Employee Wage: ");
                            decimal wage = decimal.Parse(Console.ReadLine());
                            Console.Clear();
                            Console.Write("Hourly Employee Hours Worked: ");
                            decimal hoursWorked = decimal.Parse(Console.ReadLine());
                            Console.Clear();
                            ledger[emptyLocation] = new HourlyEmployee(firstName, lastName, SSN, wage, hoursWorked);
                            Console.WriteLine("Added new Hourly Employee with following details:\n" + ledger[emptyLocation].ToString());
                        }
                        else if (menuSelection == 50)
                        {
                            Console.Write("Salaried Employee First Name: ");
                            string firstName = Console.ReadLine();
                            Console.Clear();
                            Console.Write("Salaried Employee Last Name: ");
                            string lastName = Console.ReadLine();
                            Console.Clear();
                            Console.Write("Salaried Employee SSN: ");
                            string SSN = Console.ReadLine();
                            Console.Clear();
                            Console.Write("Salaried Employee Weekly Salary: ");
                            decimal salary = decimal.Parse(Console.ReadLine());
                            Console.Clear();
                            ledger[emptyLocation] = new SalariedEmployee(firstName, lastName, SSN, salary);
                            Console.WriteLine("Added new Salaried Employee with following details:\n" + ledger[emptyLocation].ToString());
                        }
                        else
                        {
                            Console.Write("Invoice Part Number: ");
                            string partNumber = Console.ReadLine();
                            Console.Clear();
                            Console.Write("Part Description: ");
                            string partDescription = Console.ReadLine();
                            Console.Clear();
                            Console.Write("Quantity Purchased: ");
                            int quantity = int.Parse(Console.ReadLine());
                            Console.Clear();
                            Console.Write("Price Per Part: ");
                            decimal price = decimal.Parse(Console.ReadLine());
                            Console.Clear();
                            ledger[emptyLocation] = new Invoice(partNumber, partDescription, quantity, price);
                            Console.WriteLine("Added new Invoice with following details:\n" + ledger[emptyLocation].ToString());
                        }
                    }
                    else
                        Console.WriteLine("No space to add another ledger item.");
                    Console.WriteLine("Press any key to return to the menu ...");
                    Console.ReadKey(true);
                    Console.Clear();
                }
            } while (menuSelection != 52);

            decimal hourlyEmployeeTotal = 0;
            decimal salariedEmployeeTotal = 0;
            decimal invoiceTotal = 0;
            decimal weeklyTotal = 0;
            Console.WriteLine("Weekly Cash Flow Analysis is as follows:\n");
            for(int i = 0; i < ledger.Length; i++)
            {
                if (ledger[i] == null)
                    break;
                Console.WriteLine(ledger[i].ToString() + "\n");
                if (ledger[i].LedgerType == LedgerType.Hourly)
                {
                    hourlyEmployeeTotal += ledger[i].GetPayableAmount();
                }
                else if (ledger[i].LedgerType == LedgerType.Salaried)
                { 
                    salariedEmployeeTotal += ledger[i].GetPayableAmount();
                }
                else
                {
                    invoiceTotal += ledger[i].GetPayableAmount();
                }
            }
            weeklyTotal = hourlyEmployeeTotal + salariedEmployeeTotal + invoiceTotal;
            Console.WriteLine("Total Week Payout: " + weeklyTotal.ToString("C") + "\nCategory Breakdown:\n"
                + "  Hourly Payroll: " + hourlyEmployeeTotal.ToString("C") + "\n  Salaried Payroll: "
                + salariedEmployeeTotal.ToString("C") + "\n  Invoices: " + invoiceTotal.ToString("C"));
            Console.WriteLine("Press any key to close the program ...");
            Console.ReadKey(true);
        }
    }
}
