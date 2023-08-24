using System;

public class cardHolder
{
    string cardNum;
    int pin;
    string Firstname;
    string lastname;
    double balance;

    public cardHolder(string cardNum, int pin, string firstname, string lastname, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstname = firstname;
        this.lastname = lastname;
        this.balance = balance;
    }

    public string getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public string getFirstname()
    {
        return firstname;
    }

    public string getlastname()
    {
        return lastname;
    }

    public double getbalance()
    {
        return balance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from the following options below...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. withdraw");
            Console.WriteLine("3. Show balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit?");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setbalance(currentUser.getbalance() + deposit);
            Console.WriteLine("Thank you for $$.Your new balance is:" + currentUser.getbalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw?");
            double withdraw = Double.Parse(Console.ReadLine());
            //Check if user has enough money
            if (currentUser.getbalance() > withdraw)
            {
                Console.WriteLine("Insufficient Funds: (");
            }
            else
            {
                double newBlance = currentUser.getbalance() - withdraw;
                Console.WriteLine("You're goor to go! Thank you:)");
            }

        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getbalance());

        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("3476897635569683", 1234, "Salah", "Mohamed", 130));
        cardHolders.Add(new cardHolder("3576897635564658", 2345, "Leao", "Balassar", 150));
        cardHolders.Add(new cardHolder("3676897635563455", 3456, "Kante", "Mohamed", 1330));
        cardHolders.Add(new cardHolder("3776897635563378", 7891, "Kevin", "De Bryna", 1660));
        cardHolders.Add(new cardHolder("3876897635569987", 1098, "Lasihu", "Almont", 1870));

        //Prompt user
        Console.WriteLine("Welcome to NkiliATM");
        Console.WriteLine("Please insert your debit card: ");
        string debitcardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitcardNum = Console.ReadLine();
                //check against our db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitcardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized.Please try again"); }
            }
            catch { Console.WriteLine("Card not recognized.Please try again"); }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitcardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Pin not recognized. Please try again"); }
            }
            catch { Console.WriteLine("Pin not recognized. Please try again"); }
        }

        Console.WriteLine("Welcome" + currentUser.getFirstname() + " : )");
        int option = 0; a
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if (option == 1) { deposit(currentUser); }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }

        }
        while (option != 4);
        Console.WriteLine("Thank you! Have a nice day :)");
    }
}
