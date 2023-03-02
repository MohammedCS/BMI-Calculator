namespace BMICalculator.Models;

public class User
{
    public Guid UserId { get; set; }

    public string FirstName { get; set; } = default!;
    public string? LastName { get; set; }
    public Gender Gender { get; set; } 
    public double Height { get; set; }
    public double Weight { get; set; }
    public double BMI { get; set; }
    public int Age { get; set; }
    public BMICategory Category { get; set; }

    public string FullName => $"{FirstName} {LastName}";
}