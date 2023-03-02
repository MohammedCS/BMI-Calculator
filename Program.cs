namespace BMICalculator;

public partial class Program
{
    static void Main()
    {
        while(true)
        {
            User user = new();
            PrintWelcomeMessage();
            TakeUserData(user);
            CalculateBMI(user);
            ClassifyUser(user);
            PrintReport(user);
            if (!Again())
                break;
        }
    }
}