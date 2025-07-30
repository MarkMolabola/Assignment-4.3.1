namespace Assignment_4._3._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Prompt();
        }
        static void Prompt()
        {
            Console.Write("Enter ID Number: ");
            string idNumber = Console.ReadLine();
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Unit Consumed: ");
            int.TryParse(Console.ReadLine(), out int unitConsumed);
            DisplayReceipt(idNumber, firstName, lastName, unitConsumed);
        }
        static void DisplayReceipt(string idNumber, string firstName, string lastName, int unitConsumed)
        {
            double surcharge = 0;
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"ID Number: {idNumber}");
            Console.WriteLine($"First Name: {firstName}");
            Console.WriteLine($"Last Name: {lastName}");
            Console.WriteLine($"Unit Consumed: {unitConsumed}");
            Console.WriteLine($"Total Bill: {CalculateBill(unitConsumed):C}");
            if (CalculateBill(unitConsumed) > 400)
            {
                surcharge = CalculateBill(unitConsumed) * 0.15;
            }
            Console.WriteLine($"Surcharge Amount: {surcharge:C}");
            Console.WriteLine($"Total Amount Due: {(CalculateBill(unitConsumed) + surcharge):C}");
            Console.WriteLine("---------------------------------------------");


        }
        static double CalculateBill(int unitConsumed)
        {
            const double tier1 = 199 * 1.2;
            const double tier2 = (200 * 1.5) + tier1;
            const double tier3 = (200 * 1.8) + tier2;

            switch (unitConsumed)
            {
                case <= 199:
                return unitConsumed * 1.2;
                case <= 400:
                return tier1 + ((unitConsumed - 199) * 1.5);
                case <= 600:
                return tier2 + ((unitConsumed - 399) * 1.8);
                default:
                return tier3 + ((unitConsumed - 599) * 2.0);
            }
        }

    }
}
