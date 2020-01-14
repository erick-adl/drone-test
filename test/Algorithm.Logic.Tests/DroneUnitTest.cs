using System.Linq;
using Xunit;
using Algorithm.Logic.Drone;

namespace Algorithm.Logic.Tests
{
    public class ProgramUnitTest
    {


        [Fact]
        public void Input_NNNNNLLLLL()
        {
            Assert.Equal("(5, 5)", Program.Evaluate("NNNNNLLLLL"));
        }

        [Fact]
        public void Input_NLNLNLNLNL()
        {
            Assert.Equal("(5, 5)", Program.Evaluate("NLNLNLNLNL"));
        }

        [Fact]
        public void Input_NNNNNXLLLLLX()
        {
            Assert.Equal("(4, 4)", Program.Evaluate("NNNNNXLLLLLX"));
        }

        [Fact]
        public void Input_SSSSSOOOOO()
        {
            Assert.Equal("(-5, -5)", Program.Evaluate("SSSSSOOOOO"));
        }

        [Fact]
        public void Input_S5O5()
        {
            Assert.Equal("(-5, -5)", Program.Evaluate("S5O5"));
        }

        [Fact]
        public void Input_NNX2()
        {
            Assert.Equal("(999, 999)", Program.Evaluate("NNX2"));
        }
        
        [Fact]
        public void Input_N123LSX()
        {
            Assert.Equal("(1, 123)", Program.Evaluate("N123LSX"));
        }
	
		[Fact]
        public void Input_NLS3X()
        {
            Assert.Equal("(1, 1)", Program.Evaluate("NLS3X"));
        }

		[Fact]
        public void Input_NNNXLLLXX()
        {
            Assert.Equal("(1, 2)", Program.Evaluate("NNNXLLLXX"));
        }

        [Fact]
        public void Input_N40L30S20O10NLSOXX()
        {
            Assert.Equal("(21, 21)", Program.Evaluate("N40L30S20O10NLSOXX"));
        }

        [Fact]
        public void Input_NLSOXXN40L30S20O10()
        {
            Assert.Equal("(21, 21)", Program.Evaluate("NLSOXXN40L30S20O10"));
        }

        [Fact]
        public void Input_NULL()
        {
            Assert.Equal("(999, 999)", Program.Evaluate(null)); // Entrada nula
        }

        [Fact]
        public void Input_EMPTY()
        {
            Assert.Equal("(999, 999)", Program.Evaluate("")); // Entrada vazia
        }

        [Fact]
        public void Input_WHITESPACE()
        {
            Assert.Equal("(999, 999)", Program.Evaluate("   ")); // Entrada espaço vazio
        }

        [Fact]
        public void Input_123()
        {
            Assert.Equal("(999, 999)", Program.Evaluate("123")); // Entrada inválida
        }

        [Fact]
        public void Input_123N()
        {
            Assert.Equal("(999, 999)", Program.Evaluate("123N")); // passos antes da direçao
        }

        [Fact]
        public void Input_N2147483647N()
        {
            Assert.Equal("(999, 999)", Program.Evaluate("N2147483647N")); // Overflow
        }

        [Fact]
        public void Input_NNI()
        {
            Assert.Equal("(999, 999)", Program.Evaluate("NNI")); // Commando inválido
        }

        [Fact]
        public void Input_N2147483647XN()
        {
            Assert.Equal("(0, 1)", Program.Evaluate("N2147483647XN")); // Overflow cancelado
        }

        [Fact]
        public void Input_BIGSTRING()
        {
            Assert.Equal("(500, 500)", Program.Evaluate(new string(
                Enumerable.Repeat('N', 1000).Concat(
                Enumerable.Repeat('S', 500)).Concat(
                Enumerable.Repeat('L', 1000)).Concat(
                Enumerable.Repeat('O', 500)).ToArray())));
        }
    }
}
