using System;
using CodingAssessment.Refactor;
using FluentAssertions;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        private BirthingUnit _sut;

        public UnitTest1()
        {
            _sut = new BirthingUnit();
        }


        [Fact]
        public void GetMarried_WhenLastNameIsTest()
        {
            var people = new People("Chris", DateTime.UtcNow.Subtract(new TimeSpan(30 * 356, 0, 0, 0)));
            var name = _sut.GetMarried(people, "test");
            name.Should().Be("Chris");
        }

        [Fact]
        public void GetMarried_WhenLastNameIsEmpty()
        {
            var people = new People("Chris", DateTime.UtcNow.Subtract(new TimeSpan(30 * 356, 0, 0, 0)));
            var name = _sut.GetMarried(people, string.Empty);
            name.Should().Be("Chris");
        }

        [Fact]
        public void GetMarried_WhenFirstNameLengthIsGreaterThan255AndLastNameIsEmpty()
        {
            var name = "Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher";
            var people = new People(name, DateTime.UtcNow.Subtract(new TimeSpan(30 * 356, 0, 0, 0)));
            var result = _sut.GetMarried(people, string.Empty);
            result.Should().Be("Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Chr");
        }

        [Fact]
        public void GetMarried_WhenFirstNameLengthIsMoreThan255()
        {
            var name = "Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher";
            var people = new People(name, DateTime.UtcNow.Subtract(new TimeSpan(30 * 356, 0, 0, 0)));
            var result = _sut.GetMarried(people, "Nolan");
            result.Should().Be("Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Christopher Chr");
        }

        [Fact]
        public void GetMarried_WhenFirstNameAndLastNamePresent()
        {
            var people = new People("Chris", DateTime.UtcNow.Subtract(new TimeSpan(30 * 356, 0, 0, 0)));
            var name = _sut.GetMarried(people, "Nolan");
            name.Should().Be("Chris Nolan");
        }
    }
}
