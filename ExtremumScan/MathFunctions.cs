using System;

namespace ExtremumScan
{
	public static class MathFunctions
	{
		// Тригонометрические
		public static double Function1(double x)
        {
			return Math.Sin(x);
        }
		public static double Function2(double x)
		{
			return Math.Cos(x);
		}

		// Экспоненциальные

		public static double Function3(double x)
		{
			return Math.Exp(x);
		}

		public static double Function4(double x)
		{
			return Math.Exp(x) * x;
		}

		// Параболические
		public static double Function5(double x)
		{
			return Math.Pow(x,2);
		}

		public static double Function6(double x)
		{
			return Math.Pow(x,3);
		}
	}
}
