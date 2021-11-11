using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.RequestEmailAggregate
{
    public class Email : ValueObject
    {
        public string Value { get; }

        private Email(string emailString)
            => Value = emailString;

        public static Email Create(string emailString)
        {
            if (IsValidEmail(emailString))
            {
                return new Email(emailString);
            }

            // TODO: тут конечно же должно быть нормальное исключение
            throw new Exception($"Email is invalid: {emailString}");
        }

        /// <inheritdoc />
        public override string ToString()
            => Value;

        /// <inheritdoc />
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        private static bool IsValidEmail(string emailString)
            => Regex.IsMatch(emailString, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
    }
}