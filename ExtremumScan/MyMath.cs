using System;

namespace ExtremumScan
{
	public static class MyMath
	{
		public static double Function1(double x)
        {
			return Math.Sin(x);
        }

		public static double Function2(double x)
		{
			return Math.Cos(x);
		}

		public static double Function3(double x)
		{
			return Math.Pow(x,2);
		}

		public static double Function4(double x)
		{
			return Math.Pow(x,3);
		}
	}
}
