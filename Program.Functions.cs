namespace BMICalculator;

public partial class Program
{
    public static void PrintWelcomeMessage()
    {
        WriteLine("\n\n\t\tBMI Calculator\t\t");
        WriteLine("------------------------------------------------");
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
            Write("Age: ");
            string? input = ReadLine();
            if (int.TryParse(input, out int age))
            {
                user.Age = age;
                break;
            }
            else
            {
                WriteLine("You Should Provide Age & It Should Be In Right Format!!");
            }
        }

        while(true)
        {
            Write("Gender (Male, Female): ");
            string? input = ReadLine()?.ToLower();
            if (input == "male")
            {
                user.Gender = Gender.Male;
                break;
            }
            else if (input == "female")
            {
                user.Gender = Gender.Female;
                break;
            }
            else
                WriteLine("You Should Provide Gender!!");
        }

        while(true)
        {
            Write("Height (cm): ");
            string? input = ReadLine();
            if (double.TryParse(input, out double height))
            {
                user.Height = height;
                break;
            }
            else
            {
                WriteLine("You Should Provide Height & It Should Be In Right Format!!");
            }
        }

        while(true)
        {
            Write("Weight (kg): ");
            string? input = ReadLine();
            if (double.TryParse(input, out double weight))
            {
                user.Weight = weight;
                break;
            }
            else
            {
                WriteLine("You Should Provide Weight & It Should Be In Right Format!!");
            }
        }
        WriteLine("------------------------------------------------");
    }

    public static void CalculateBMI(User user) =>
        user.BMI = Math.Round(user.Weight / Math.Pow((user.Height / 100D), 2), 1);

    public static void ClassifyUser(User user) =>
        user.Category = user.BMI switch {
            < 18.5 => BMICategory.UnderWeight,
            >= 18.5 and <= 24.9 => BMICategory.NormalWeight,
            >= 25 and <= 29.9 => BMICategory.OverWeight,
            >= 30 => BMICategory.Obseity,
            _ => default
        };
    
    public static void PrintReport(User user)
    {
        WriteLine("\t\tBMI Report\t\t\n");
        WriteLine($"Hi {user.FullName} This is your BMI Report\n");
        WriteLine($"BMI Result = {user.BMI}");
        WriteLine($"BMI Classification = {user.Category}");
    }

    public static bool Again()
    {
        Write("\n\nDo You Want To Calculate Again Or Not (y/N): ");
        string? input = ReadLine();
        return input?.ToUpper() == "Y" ||
            input?.ToUpper() == "YES";
    }
}