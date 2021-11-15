using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MerchandiseService.Domain.Exceptions.ReuqestEmailAggregate;
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
            
            throw new InvalidValueException($"Email is invalid: {emailString}");
        }
        
        public override string ToString()
            => Value;
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        private static bool IsValidEmail(string emailString)
            => Regex.IsMatch(emailString, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
    }
}