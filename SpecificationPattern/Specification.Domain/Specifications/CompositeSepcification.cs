namespace Specification.Domain.Specifications
{
    public abstract class PairSpecification<T>: ISpecification<T>
    {
        protected readonly ISpecification<T> left;
        protected readonly ISpecification<T> right;
        protected PairSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            this.left = left;
            this.right = right;

        }
        public abstract bool IsSatisfiedBy(T model);
    }

    public class AndSpecification<T>: PairSpecification<T>
    {
        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
            : base(left, right)
        { }
        public override bool IsSatisfiedBy(T model)
        {
            return left.IsSatisfiedBy(model) && right.IsSatisfiedBy(model);
        }
    }

    public class XAndSpecification<T>: PairSpecification<T>
    {
        public XAndSpecification(ISpecification<T> left, ISpecification<T> right)
            : base(left, right)
        { }
        public override bool IsSatisfiedBy(T model)
        {
            return (left.IsSatisfiedBy(model) && right.IsSatisfiedBy(model)) || 
                   (!left.IsSatisfiedBy(model) && !right.IsSatisfiedBy(model));
        }
    }

    public class OrSpecification<T> : PairSpecification<T>
    {
        public OrSpecification(ISpecification<T> left, ISpecification<T> right)
            : base(left, right)
        { }
        public override bool IsSatisfiedBy(T model)
        {
            return left.IsSatisfiedBy(model) || right.IsSatisfiedBy(model);
        }
    }
    public class NotSpecification<T> : ISpecification<T>
    {
        private readonly ISpecification<T> specification;
        public NotSpecification(ISpecification<T> specification)
        {
            this.specification = specification;

        }
        public bool IsSatisfiedBy(T model)
        {
            return !specification.IsSatisfiedBy(model);
        }
    }
}

