using Moq;
using System;
using Xunit;

namespace CalculatorTest.Unit.Test
{
    public class SimpleCalculatorTest
    { 
        private Mock<IDiagnostics> diagnostics;
        private ISimpleCalculator GetCalculator()
        {
            diagnostics = new Mock<IDiagnostics>();
            var calculator = new SimpleCalculator(diagnostics.Object);
            return calculator;
        }

        [Fact]
        public void Add_AnyIntegers_DiagnosticsLogInformationIsInvoked()
        {
            //Arrange
            //Mock<IDiagnostics> diagnostics = new Mock<IDiagnostics>();
            ISimpleCalculator calc = GetCalculator();
            //Act
            var result = calc.Add(2, 3);
            //Assert
            diagnostics.Verify(d => d.LogInformation(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void Subtract_AnyIntegers_DiagnosticsLogInformationIsInvoked()
        {
            //Arrange
            //Mock<IDiagnostics> diagnostics = new Mock<IDiagnostics>();
            ISimpleCalculator calc = GetCalculator();
            //Act
            var result = calc.Subtract(2, 3);
            //Assert
            diagnostics.Verify(d => d.LogInformation(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void Multiply_AnyIntegers_DiagnosticsLogInformationIsInvoked()
        {
            //Arrange
            //Mock<IDiagnostics> diagnostics = new Mock<IDiagnostics>();
            ISimpleCalculator calc = GetCalculator();
            //Act
            var result = calc.Multiply(2, 3);
            //Assert
            diagnostics.Verify(d => d.LogInformation(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void Divide_AnyIntegers_DiagnosticsLogInformationIsInvoked()
        {
            //Arrange
            //Mock<IDiagnostics> diagnostics = new Mock<IDiagnostics>();
            ISimpleCalculator calc = GetCalculator();
            //Act
            var result = calc.Divide(2, 3);
            //Assert
            diagnostics.Verify(d => d.LogInformation(It.IsAny<string>()), Times.Once);
        }

        //Format for testing name UnitUnderTest_Scenario_ExpectedOutcome
        //Unit under test is just the method name, scenario is what the parameters are
        //expected outcome is what the test should return
        [InlineData(0, 0, 0)]
        [InlineData(0, 5, 5)]
        [InlineData(5, 4, 9)]
        [Theory]

        public void Add_PositiveIntegers_ReturnIntegerSum(int input1, int input2, int expectedResult)
        {
            //Arrange
            ISimpleCalculator calc = GetCalculator();
            //Act
            int result = calc.Add(input1, input2);
            //Assert
            Assert.Equal(expectedResult, result);
        }
        [InlineData(-2, -7, -9)]
        [InlineData(-10, -2, -12)]
        [InlineData(-10, -7, -17)]
        [Theory]
        public void Add_NegativeIntegers_ReturnIntegerSum(int input1, int input2, int expectedResult)
        {
            //Arrange
            ISimpleCalculator calc = GetCalculator();
            //Act
            int result = calc.Add(input1, input2);
            //Assert
            Assert.Equal(expectedResult, result);
        }
        [InlineData(-2, 7, 5)]
        [InlineData(2, -10, -8)]
        [InlineData(10, -7, 3)]
        [Theory]
        public void Add_MixtureIntegers_ReturnIntegerSum(int input1, int input2, int expectedResult)
        {
            //Arrange
            ISimpleCalculator calc = GetCalculator();
            //Act
            int result = calc.Add(input1, input2);

            //Assert
            Assert.Equal(expectedResult, result);
        }


        [InlineData(0, 0, 0)]
        [InlineData(2, 3, -1)]
        [InlineData(5, 2, 3)]
        [Theory]
        public void Subtract_PositiveIntegers_ReturnIntegerSub(int input1, int input2, int expectedResult)
        {
            //Arrange
            ISimpleCalculator calc = GetCalculator();
            //Act
            int result = calc.Subtract(input1, input2);
            //Assert
            Assert.Equal(expectedResult, result);
        }

        [InlineData(-1, -3, 2)]
        [InlineData(-5, -1, -4)]
        [InlineData(-5, -5, 0)]
        [Theory]
        public void Subtract_NegativeIntegers_ReturnIntegerSub(int input1, int input2, int expectedResult)
        {
            //Arrange
            ISimpleCalculator calc = GetCalculator();
            //Act
            int result = calc.Subtract(input1, input2);
            //Assert
            Assert.Equal(expectedResult, result);
        }

        [InlineData(-1, 3, -4)]
        [InlineData(5, -1, 6)]
        [InlineData(5, -5, 10)]
        [Theory]
        public void Subtract_MixedIntegers_ReturnIntegerSub(int input1, int input2, int expectedResult)
        {
            //Arrange
            ISimpleCalculator calc = GetCalculator();
            //Act
            int result = calc.Subtract(input1, input2);
            //Assert
            Assert.Equal(expectedResult, result);
        }

        [InlineData(0, 0, 0)]
        [InlineData(1, 3, 3)]
        [InlineData(0, 2, 0)]
        [InlineData(5, 5, 25)]
        [Theory]
        public void Multiply_PositiveIntegers_ReturnIntegerMult(int input1, int input2, int expectedResult)
        {
            //Arrange
            ISimpleCalculator calculator = GetCalculator();

            //Act
            var result = calculator.Multiply(input1, input2);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [InlineData(-1, -3, 3)]
        [InlineData(-0, -2, 0)]
        [InlineData(-5, -5, 25)]
        [Theory]
        public void Multiply_NegativeIntegers_ReturnIntegerMult(int input1, int input2, int expectedResult)
        {
            //Arrange
            ISimpleCalculator calc = GetCalculator();

            //Act
            int result = calc.Multiply(input1, input2);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [InlineData(4, -3, -12)]
        [InlineData(0, -2, 0)]
        [InlineData(-5, 5, -25)]
        [Theory]
        public void Multiply_MixedIntegers_ReturnIntegerMult(int input1, int input2, int expectedResult)
        {
            //Arrange
            ISimpleCalculator calc = GetCalculator();

            //Act
            int result = calc.Multiply(input1, input2);

            //Assert
            Assert.Equal(expectedResult, result);
        }
        
        [InlineData(5)]
        [InlineData(-4)]
        [Theory]
        public void Divide_ZeroByIntegers_ThrowException(int input)
        {
            //Arrange
            ISimpleCalculator calculator = GetCalculator();

            //Act
            int result = calculator.Divide(0, input);
            int expectedResult = 0;

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [InlineData(0)]
        [InlineData(5)]
        [InlineData(-4)]
        [Theory]
        public void Divide_IntegersByZero_ReturnZero(int input)
        {
            //Arrange
            ISimpleCalculator calc = GetCalculator();
            
            //Assert
            Assert.Throws<DivideByZeroException>(() => calc.Divide(input, 0));
        }

        [InlineData(2, 3, 0)]
        [InlineData(4, 1, 4)]
        [InlineData(8, 3, 2)]
        [Theory]
        public void Divide_PositiveIntegersByPositiveIntegers_ReturnIntegerDiv(int input1, int input2, int expectedResult)
        {
            //Arrange
            ISimpleCalculator calc = GetCalculator();

            //Act
            int result = calc.Divide(input1, input2);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [InlineData(-2, -3, 0)]
        [InlineData(-4, -1, 4)]
        [InlineData(-8, -3, 2)]
        [Theory]
        public void Divide_NegativeIntegersByNegativeIntegers_ReturnIntegerDiv(int input1, int input2, int expectedResult)
        {
            //Arrange
            ISimpleCalculator calc = GetCalculator();

            //Act
            int result = calc.Divide(input1, input2);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [InlineData(-2, 3, -0)]
        [InlineData(4, -1, -4)]
        [InlineData(-8, 3, -2)]
        [Theory]
        public void Divide_MixedIntegers_ReturnIntegerDiv(int input1, int input2, int expectedResult)
        {
            //Arrange
            ISimpleCalculator calc = GetCalculator();

            //Act
            int result = calc.Divide(input1, input2);

            //Assert
            Assert.Equal(expectedResult, result);
        }

    }
}
