using System;
using Ploeh.AutoFixture;
using Xunit;

namespace DemoCode.Tests
{
    public class ObjectGraphs
    {
        [Fact]
        public void ManualCreation()
        {

            // arrange

            Customer customer = new Customer()
            {
                CustomerName = "Amrit"
            };

            Order order = new Order(customer)
            {
                Id = 42,
                OrderDate = DateTime.Now,
                Items =
                              {
                                  new OrderItem
                                  {
                                      ProductName = "Rubber ducks",
                                      Quantity = 2
                                  }
                              }
            };


            // act and assert phases...
        }


        [Fact]
        public void AutoCreation()
        {

            // arrange

            var fixture = new Fixture();

            Order order = fixture.Create<Order>();


            // act and assert phases...
        }
    }
}
