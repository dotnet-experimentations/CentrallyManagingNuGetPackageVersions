using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Xunit;

namespace Foo.Tests
{
    public class FooTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(7)]
        [InlineData(101)]
        public void Should_return_inut_value_When_not_a_mapping(int input)
        {
            //Given
            var foobar = new FooBar(Options.Create(new FooBarOptions()));

            //When
            var result = foobar.Compute(input);

            //Then
            Assert.Equal(input.ToString(), result);
        }

        [Fact]
        public void Should_return_foo_When_multiple_of_three()
        {
            //Given
            var foobar = new FooBar(Options.Create(new FooBarOptions()));

            //When
            var result = foobar.Compute(3);

            //Then
            Assert.Equal("foo", result);
        }

        [Fact]
        public void Should_return_bar_When_multiple_of_five()
        {
            //Given
            var foobar = new FooBar(Options.Create(new FooBarOptions()));

            //When
            var result = foobar.Compute(5);

            //Then
            Assert.Equal("bar", result);
        }

        [Fact]
        public void Should_return_foobar_When_multiple_of_three_and_five()
        {
            //Given
            var foobar = new FooBar(Options.Create(new FooBarOptions()));


            //When
            var result = foobar.Compute(3 * 5);

            //Then
            Assert.Equal("foobar", result);
        }


        [Fact]
        public void Should_return_mapping_value_When_options_is_custom()
        {
            //Given
            var options = new FooBarOptions();
            options.Mappings.Add(7, "kix");
            var foobar = new FooBar(Options.Create(options));

            //When
            var result3 = foobar.Compute(3);
            var result5 = foobar.Compute(5);
            var result7 = foobar.Compute(7);
            var result15 = foobar.Compute(3 * 5);
            var result105 = foobar.Compute(3 * 5 * 7);

            //Then
            Assert.Equal("foo", result3);
            Assert.Equal("bar", result5);
            Assert.Equal("kix", result7);
            Assert.Equal("foobarkix", result105);
        }

        [Fact]
        public void Should_remove_default_mapping_When_overriding_mapping_dictionary()
        {
            //Given
            var options = new FooBarOptions { Mappings = new Dictionary<int, string> { { 7, "kix" } } };
            var foobar = new FooBar(Options.Create(options));

            //When
            var result = foobar.Compute(7);

            //Then
            Assert.Equal("kix", result);
        }
    }
}
