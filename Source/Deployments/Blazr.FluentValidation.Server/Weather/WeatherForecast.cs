using FluentValidation;

public class WeatherForecast
{
    public DateOnly Date { get; set; }
    public int TemperatureC { get; set; }
    public string? Summary { get; set; }
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

public class WeatherForecastValidator : AbstractValidator<WeatherForecast>
{
    public WeatherForecastValidator()
    {
        this.RuleFor(p => p.Summary)
            .NotNull().WithMessage("You must enter a Summary of at lest 3 characters")
            .MinimumLength(3).WithMessage("Summary must have at least 3 characters")
            .WithState(p => p);

        this.RuleFor(p => p.TemperatureC)
            .GreaterThanOrEqualTo(-40).WithMessage("Temperature must be between -40 and 60 degrees")
            .LessThanOrEqualTo(60).WithMessage("Temperature must be between -40 and 60 degrees")
            .WithState(p => p);

        this.RuleFor(p => p.Date)
            .GreaterThan(DateOnly.FromDateTime(DateTime.Now))
            .WithMessage("The date mut be in the future")
            .WithState(p => p);
    }
}
