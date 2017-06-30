

namespace DemoCode
{
    public class PersonValidator
    {
        public int IsValid(Person person)
        {
            int validationErrorCount = 0;

            if (string.IsNullOrWhiteSpace(person.FirstName))
            {
                validationErrorCount ++;
            }

            if (string.IsNullOrWhiteSpace(person.LastName))
            {
                validationErrorCount++;
            }

            return validationErrorCount;
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }    
    }
}
