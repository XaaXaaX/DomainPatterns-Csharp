namespace Specification.Domain.Specifications;
public static class CompositeSpecificationExtensions
{
    public static ISpecification<T> And<T>(this ISpecification<T> spec, ISpecification<T> specification)
    {
        return new AndSpecification<T>(spec, specification);
    }
    public static ISpecification<T> Or<T>(this ISpecification<T> spec, ISpecification<T> specification)
    {
        return new OrSpecification<T>(spec, specification);
    }   
    public static ISpecification<T> Not<T>(this ISpecification<T> spec)
    {
        return new NotSpecification<T>(spec);
    }
    public static ISpecification<T> XAnd<T>(this ISpecification<T> spec, ISpecification<T> specification)
    {
        return new XAndSpecification<T>(spec, specification);
    } 
}