using System;
using System.Reflection;
using Ploeh.AutoFixture.Kernel;

namespace DemoCode.Tests
{
    public class AirportCodeSpecimenBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            // See if we are trying to create a value for a property
            var propertyInfo = request as PropertyInfo;

            if (propertyInfo == null)
            {
                // this customization does not apply to current request
                return new NoSpecimen(request);
            }

            // Now we know we're dealing with a property, are we creating 
            // a value for an airport code?
            var isAirportCodeProperty = 
                        propertyInfo.Name.Contains("AirportCode") &&
                        propertyInfo.PropertyType == typeof(string);

            if (isAirportCodeProperty)
            {
                return RandomAirportCode();
            }

            // this customization does not apply to current request
            return new NoSpecimen(request);
        }

        private string RandomAirportCode()
        {
            if (DateTime.Now.Ticks % 2 == 0)
            {
                return "AAA";
            }

            return "BBB";
        }
    }
}