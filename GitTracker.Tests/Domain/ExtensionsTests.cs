using GitTracker.Domain.Helpers.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GitTracker.Tests.Domain
{
    [TestClass]
    public class ExtensionsTests
    {
        [TestMethod]
        public void GetDescription_EnumWithAnnotations()
        {
            // Arrange
            var enumValue = SimpleEnum.Annotation;
            string expected = "Description";

            // Assert
            var response = enumValue.GetDescription();

            // Act
            Assert.IsNotNull(response);
            Assert.AreEqual(expected, response);
        }

        [TestMethod]
        public void GetDescription_EnumWithoutAnnotations()
        {
            // Arrange
            var enumValue = SimpleEnum.NoAnnotation;
            string expected = nameof(SimpleEnum.NoAnnotation);

            // Assert
            var response = enumValue.GetDescription();

            // Act
            Assert.IsNotNull(response);
            Assert.AreEqual(expected, response);
        }

        [TestMethod]
        public async Task RunWithErrorHandler_NoErrorThrow()
        {
            // Arrange
            static async Task<int> divide(int a, int b) => await Task.FromResult(a / b);

            int dividend = 10;
            int divisor = 5;
            int expected = 2;

            // Assert
            var response = await divide(dividend, divisor).RunWithErrorHandler(null);

            // Act
            Assert.IsNotNull(response);
            Assert.AreEqual(expected, response);
        }

        [TestMethod]
        public async Task RunWithErrorHandler_ErrorThrow_NoErrorHandler_ShouldReturnDefault()
        {
            // Arrange
            static async Task<int> divide(int a, int b) => await Task.FromResult(a / b);

            int dividend = 10;
            int divisor = 0;
            int expected = 0;

            // Assert
            var response = await divide(dividend, divisor).RunWithErrorHandler(null);

            // Act
            Assert.IsNotNull(response);
            Assert.AreEqual(expected, response);
        }

        [TestMethod]
        public async Task RunWithErrorHandler_ErrorThrow_ErrorHandler()
        {
            // Arrange
            static async Task<int> divide(int a, int b) => await Task.FromResult(a / b);
            static void errorHandler(Exception ex) => Debug.Write(ex.Message);

            int dividend = 10;
            int divisor = 0;
            int expected = 0;

            // Assert
            var response = await divide(dividend, divisor).RunWithErrorHandler(errorHandler);

            // Act
            Assert.IsNotNull(response);
            Assert.AreEqual(expected, response);
        }

        private enum SimpleEnum
        {
            NoAnnotation,
            [System.ComponentModel.Description("Description")]
            Annotation
        }
    }
}