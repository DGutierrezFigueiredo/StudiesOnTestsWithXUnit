using System;
using FluentValidation;
using FeaturesAndMock.Infrastructure;

namespace FeaturesAndMock.Domain.Entities
{
    public class Client : Entity
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime EntryRegistrationDate { get; private set; }
        public string Email { get; private set; }
        public bool IsActive { get; private set; }

        protected Client()
        {
        }

        public Client(Guid id, string name, string lastName, DateTime birthDate, string email, bool isActive,
            DateTime entryRegistrationDate)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            BirthDate = birthDate;
            Email = email;
            IsActive = isActive;
            EntryRegistrationDate = entryRegistrationDate;
        }

        public string GetFullName()
        {
            return $"{Name} {LastName}";
        }

        public bool IsASpecialClient()
        {
            return EntryRegistrationDate < DateTime.Now.AddYears(-3) && IsActive;
        }

        public void MakeInactive()
        {
            IsActive = false;
        }

        public override bool IsValidClient()
        {
            ValidationResult = new ClientValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class ClientValidation : AbstractValidator<Client>
    {
        public ClientValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("You must insert a name to proceed")
                .Length(2, 150).WithMessage("Name must be between 2 and 150 characters long");

            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("You must insert a last name to proceed")
                .Length(2, 150).WithMessage("Last Name must be between 2 and 150 characters long");

            RuleFor(c => c.BirthDate)
                .NotEmpty()
                .Must(HaveMinimumAge)
                .WithMessage("Client must be at least 18 years old");

            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        public static bool HaveMinimumAge(DateTime birthDate)
        {
            return birthDate <= DateTime.Now.AddYears(-18);
        }
    }
}
