using System;

namespace ExtremumScan.MathFunctions
{
	public interface IFunction
    {
		public double Calculate(double x);
    }

	public class FunctionNegative : IFunction
    {
		public IFunction function;

		public FunctionNegative(IFunction function)
        {
			this.function = function;
        }

		public double Calculate(double x)
        {
			return -1 * function.Calculate(x);
        }
    }

	// Тригонометрические
	public class Function1 : IFunction
    {
        public double Calculate(double x)
        {
            return Math.Cos(x) + (1.0 / 2) * Math.Cos(x * 2);
        }
    }
	public class Function2 : IFunction
	{
		public double Calculate(double x)
		{
			return Math.Cos(Math.Pow(Math.E, x));
		}
	}

	// Экспоненциальные
	public class Function3 : IFunction
	{
		public double Calculate(double x)
		{
			return Math.Exp(x);
		}
	}
	public class Function4 : IFunction
	{
		public double Calculate(double x)
		{
			return Math.Log(Math.Exp(x));
		}
	}

	// Параболические
	public class Function5 : IFunction
	{
		public double Calculate(double x)
		{
			return Math.Pow(x, 2);
		}
	}
	public class Function6 : IFunction
	{
		public double Calculate(double x)
		{
			return Math.Pow(x, 3);
		}
	}
}
