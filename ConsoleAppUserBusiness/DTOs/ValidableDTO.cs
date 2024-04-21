using System.ComponentModel.DataAnnotations;

namespace ConsoleAppUserBusiness.DTOs;
public abstract class ValidableDTO
{
    public bool IsValid()
    {
        var validationContext = new ValidationContext(this, serviceProvider: null, items: null);
        var validationResults = new System.Collections.Generic.List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(this, validationContext, validationResults, true);

        if (!isValid)
        {
            Console.WriteLine("\n\nSome of the data entered is incorrect:\n");
            foreach (var validationResult in validationResults)
            {
                Console.WriteLine($"\t - {validationResult.ErrorMessage}");
            }

            Console.WriteLine("\n\tPlease enter your details again :)\n");
        }

        return isValid;
    }
}
