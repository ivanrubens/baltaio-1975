using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
                  .Requires()
                  .HasMinLen(FirstName, 3, "Name.FirstName", "Mínimo de 3 caracteres inválido")
                  .HasMinLen(LastName, 3, "Name.LastName", "Mínimo de 3 caracteres inválido")
                  .HasMaxLen(FirstName, 40, "Name.FirstName", "Máximo de 40 caracteres inválido")
                  .HasMaxLen(LastName, 40, "Name.LastName", "Máximo de 40 caracteres inválido")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

    }
}