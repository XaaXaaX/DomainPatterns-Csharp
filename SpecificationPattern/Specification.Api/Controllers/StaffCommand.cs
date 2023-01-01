using Specification.Domain;
using Specification.Domain.Specifications;
using Specification.Domain.ValidationRules;
using Specification.Domain.Entities;

public record StaffCommand
{
    
    public string Name {get; set; }
    public string Phone {get; set; }

    public static implicit operator Staff(StaffCommand staff) => new (staff.Name, staff.Phone); 
}

public class StaffValidator : Validator<StaffCommand>
{
    public StaffValidator()
        : base(new StaffValidationRule()) {}
}

public sealed class StaffValidationRule: ISpecification<StaffCommand>
{
    public readonly NameValidationRule NameValidationRule = new NameValidationRule();
    public readonly PhoneValidationRule PhoneValidationRule = new PhoneValidationRule();

    public bool IsSatisfiedBy(StaffCommand model) 
        => NameValidationRule
            .XAnd(PhoneValidationRule)
            .IsSatisfiedBy(model);
}