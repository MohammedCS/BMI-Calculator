namespace BMICalculator;

public partial class Program
{
    private static bool _again = false; 
    private static List<User> _users = new();

    public static void PrintWelcomeMessage()
    {
        WriteLine("\n\n\t\tBMI Calculator\t\t");
        WriteLine("------------------------------------------------");
    }

    public static uint GetNumberOfUsers()
    {
        Write("Enter How Many Users: ");

        uint numOfUsers = default;
        while(true)
        {
            string? input = ReadLine();
            if (uint.TryParse(input, out uint num))
            {
                numOfUsers = num;
                break;
            }
            else
            {
                WriteLine("Please Provide Right Number.");
            }
        }
        return numOfUsers;
    }

    public static void TakeUserData(User user)
    {
        WriteLine("Please Enter Your Data To Calculate Your BMI: \n");

        while(true)
        {
            Write("First Name: ");
            string? input = ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                WriteLine("You Should Provide Name!!");
            }
            else
            {
                user.FirstName = input;
                break;
            }
        }

        Write("Last Name: ");
        user.LastName = ReadLine();

        while(true)
        {
            Write("Age (2 - 120): ");
            string? input = ReadLine();
            if (uint.TryParse(input, out uint age) && age >= 2 && age <= 120)
            {
                user.Age = age;
                break;
            }
            else
            {
                WriteLine("\n!! You Should Provide Age & It Should Be In Right Format!!\n");
            }
        }

        while(true)
        {
            Write("Gender (Male, Female): ");
            string? input = ReadLine()?.ToLower();
            if (input == "male" || input == "m")
            {
                user.Gender = Gender.Male;
                break;
            }
            else if (input == "female" || input == "f")
            {
                user.Gender = Gender.Female;
                break;
            }
            else
                WriteLine("\n!! You Should Provide Gender !!\n");
        }

        while(true)
        {
            Write("Height (50 - 280)(cm): ");
            string? input = ReadLine();
            if (double.TryParse(input, out double height) && height >= 50 && height <= 280)
            {
                user.Height = height;
                break;
            }
            else
            {
                WriteLine("\n!! You Should Provide Height & It Should Be In Right Format !!\n");
            }
        }

        while(true)
        {
            Write("Weight (5 - 635)(kg): ");
            string? input = ReadLine();
            if (double.TryParse(input, out double weight) && weight >= 5 && weight <= 635)
            {
                user.Weight = weight;
                break;
            }
            else
            {
                WriteLine("\n!! You Should Provide Weight & It Should Be In Right Format !!\n");
            }
        }
        WriteLine("------------------------------------------------");
    }

    public static void CalculateBMI(User user)
    {
        user.BMI = Math.Round(user.Weight / Math.Pow((user.Height / 100D), 2), 1);
    }

    public static void ClassifyUser(User user) =>
        user.Category = user.BMI switch {
            < 18.5 => BMICategory.UnderWeight,
            >= 18.5 and <= 24.9 => BMICategory.NormalWeight,
            >= 25 and <= 29.9 => BMICategory.OverWeight,
            >= 30 => BMICategory.Obseity,
            _ => default
        };
    
    public static double CalculateAvg() 
    {
        double sum = 0;
        foreach(var user in _users)
            sum += user.BMI;
        return Math.Round(sum / _users.Count, 2);
    }
    
    public static void PrintReport(User user)
    {
        WriteLine("\t\tBMI Report\t\t\n");
        WriteLine($"Hi {user.FullName} This is your BMI Report\n");
        WriteLine($"BMI Result = {user.BMI}");
        WriteLine($"BMI Classification = {user.Category}");
        WriteLine("------------------------------------------------");
    }

    public static void ListReports()
    {
        WriteLine("------------------------------------------------");
        foreach(var user in _users)
        {
            WriteLine($"{user.FullName}'s Report: \n");
            WriteLine($"Age       = {user.Age}");
            WriteLine($"Height    = {user.Height}");
            WriteLine($"Weight    = {user.Weight}");
            WriteLine($"BMI       = {user.BMI}");
            WriteLine($"Diagnosis = {user.Category}");
            WriteLine("------------------------------------------------");
        }
    }

    public static void ListOptions()
    {
        start:
        Write("\n Choose the number of the operation: \n1- Run Program Again\n2- Terminate Program\n3 - List All Reports\n4 - Print The Average For All Users\n");
        Write("=> ");
        int selected = int.Parse(ReadLine()!);
        switch(selected)
        {
            case 1:
                _again = true;
                _users.Clear();
                break;
            case 2:
            default:
                _again = false;
                break;
            case 3:
                ListReports();
                goto start;
            case 4:
                WriteLine($"BMI Average = {CalculateAvg()}");
                goto start;
        }
    }

    public static void RunApp()
    {
        while(true)
        {
            PrintWelcomeMessage();
            uint counter = GetNumberOfUsers();
            for(int i = 1; i <= counter; i++)
            {
                User user = new();
                WriteLine($"\n\t\tUser_{i} Calculation\t\t\n");
                TakeUserData(user);
                CalculateBMI(user);
                ClassifyUser(user);
                PrintReport(user);
                _users.Add(user);
            }
            ListOptions();
            if (!_again)
            {
                WriteLine("Program Has Terminated !!");
                break;
            }
        }
    }
}