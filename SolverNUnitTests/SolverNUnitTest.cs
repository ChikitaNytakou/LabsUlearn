using NUnit.Framework;
using NUnit.Framework.Legacy;
using static TableParser.Solver;

namespace SolverNUnitTests
{
    [TestFixture]
    public class SolverNUnitTest
    {
        [Test]
        [TestCase(5, 2, 3, Operation.Add)]
        [TestCase(-1, 2, -3, Operation.Add)]
        [TestCase(1, -2, 3, Operation.Add)]
        [TestCase(2, 2, 0, Operation.Add)]
        public void TestOperationAdd(double expected, double x, double y, Operation operation)
        {
            ClassicAssert.AreEqual(expected, Solve(x, y, operation));
        }

        [Test]
        [TestCase(-1, 2, 3, Operation.Subtract)]
        [TestCase(1, 4, 3, Operation.Subtract)]
        [TestCase(2, 2, 0, Operation.Subtract)]
        [TestCase(-2, 0, 2, Operation.Subtract)]
        [TestCase(0, 0, 0, Operation.Subtract)]
        [TestCase(5, 2, -3, Operation.Subtract)]
        [TestCase(1, -2, -3, Operation.Subtract)]
        public void TestOperationSubtract(double expected, double x, double y, Operation operation)
        {
            ClassicAssert.AreEqual(expected, Solve(x, y, operation));
        }

        [Test]
        [TestCase(6, 2, 3, Operation.Multiply)]
        [TestCase(0, 2, 0, Operation.Multiply)]
        [TestCase(-4, 2, -2, Operation.Multiply)]
        [TestCase(4, -2, -2, Operation.Multiply)]
        public void TestOperationMultiply(double expected, double x, double y, Operation operation)
        {
            ClassicAssert.AreEqual(expected, Solve(x, y, operation));
        }

        [Test]
        [TestCase(1, 3, 3, Operation.Divide)]
        [TestCase(double.PositiveInfinity, 3, 0, Operation.Divide)]
        [TestCase(double.NaN, 0, 0, Operation.Divide)]
        [TestCase(0, 0, 3, Operation.Divide)]
        public void TestOperationDivide(double expected, double x, double y, Operation operation)
        {
            ClassicAssert.AreEqual(expected, Solve(x, y, operation));
        }
    }
}