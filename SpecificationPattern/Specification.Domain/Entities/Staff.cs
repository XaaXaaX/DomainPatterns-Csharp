using System;

namespace Specification.Domain.Entities
{
    public class Staff
    {
        private Name name;
        private string phone;
        private readonly StaffValidator validator = new StaffValidator();
        public Staff(string name, string phone)
        {
            this.name = new Name { Value = name };
            this.phone = phone;

            this.check();
        }

        private void check() 
        {
            if(!this.Validate()) throw new Exception("This must be a custome exception containing validation results");
        }

        private bool Validate() => this.validator.Validate(this).IsValid;
        public string GetName() => this.name.Value;
        public string GetPhone() => this.phone;
    }
}
