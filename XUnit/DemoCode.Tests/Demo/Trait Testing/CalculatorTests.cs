﻿using System;
using System.Threading;
using Xunit;

namespace DemoCode.Tests.Demo.Trait_Testing
{
    [Trait("Category", "Error Checking")]
    public class CalculatorTests
    {

        [Fact]
        public void ShouldErrorWhenDivideByZero()
        {
            var sut = new Calculator();

            Assert.Throws<DivideByZeroException>(() => sut.Divide(10, 0));
        }


        [Fact]
        [Trait("Category", "Slow Running")]
        public void ShouldErrorWhenNumberTooBig_SLOW()
        {
            var sut = new Calculator();

            // Simulate long running test
            Thread.Sleep(TimeSpan.FromSeconds(2));

            ArgumentOutOfRangeException thrownException =
                Assert.Throws<ArgumentOutOfRangeException>(() => sut.Divide(201, 1));

            Assert.Equal("value", thrownException.ParamName);
        }


    }
}
