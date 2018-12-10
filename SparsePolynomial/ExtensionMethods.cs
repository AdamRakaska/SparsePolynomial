﻿using System;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;

namespace SparsePolynomialLibrary
{
	public static class ITermExtensionMethods
	{
		public static BigInteger[] GetCoefficients(this ITerm[] source)
		{
			return source.Select(trm => trm.CoEfficient).ToArray();
		}
	}

	public static class BigIntegerExtensionMethods
	{
		public static BigInteger Mod(this BigInteger n, BigInteger mod)
		{
			BigInteger r = n % mod;
			return (r < 0) ? r + mod : r;
		}

		public static BigInteger Square(this BigInteger input)
		{
			return input * input;
		}

		// Roots
		public static BigInteger SquareRoot(this BigInteger input)
		{
			if (input.IsZero) return new BigInteger(0);

			BigInteger n = new BigInteger(0);
			BigInteger p = new BigInteger(0);
			BigInteger low = new BigInteger(0);
			BigInteger high = BigInteger.Abs(input);

			while (high > low + 1)
			{
				n = (high + low) >> 1;
				p = n * n;

				if (input < p)
					high = n;
				else if (input > p)
					low = n;
				else
					break;
			}
			return input == p ? n : low;
		}

		// Returns the NTHs root of a BigInteger with Remainder.
		// The root must be greater than or equal to 1 or value must be a positive integer.
		public static BigInteger NthRoot(this BigInteger value, int root)
		{
			BigInteger remainder = new BigInteger();
			return value.NthRoot(root, out remainder);
		}

		public static BigInteger NthRoot(this BigInteger value, int root, out BigInteger remainder)
		{
			if (root < 1) throw new Exception("Root must be greater than or equal to 1");
			if (value.Sign == -1) throw new Exception("Value must be a positive integer");

			if (value == BigInteger.One)
			{
				remainder = 0;
				return BigInteger.One;
			}
			if (value == BigInteger.Zero)
			{
				remainder = 0;
				return BigInteger.Zero;
			}
			if (root == 1)
			{
				remainder = 0;
				return value;
			}

			BigInteger upperbound = value;
			BigInteger lowerbound = BigInteger.Zero;

			while (true)
			{
				BigInteger nval = (upperbound + lowerbound) >> 1;
				BigInteger tstsq = BigInteger.Pow(nval, root);

				if (tstsq > value) upperbound = nval;
				if (tstsq < value) lowerbound = nval;
				if (tstsq == value)
				{
					lowerbound = nval;
					break;
				}
				if (lowerbound == upperbound - 1) break;
			}
			remainder = value - BigInteger.Pow(lowerbound, root);
			return lowerbound;
		}

		public static bool IsSquare(this BigInteger source)
		{
			if (source == null || source == BigInteger.Zero)
			{
				return false;
			}

			BigInteger input = BigInteger.Abs(source);

			int base16 = (int)(input & Fifteen); // Convert to base 16 number
			if (base16 > 9)
			{
				return false; // return immediately in 6 cases out of 16.
			}

			// Squares in base 16 end in 0, 1, 4, or 9
			if (base16 != 2 && base16 != 3 && base16 != 5 && base16 != 6 && base16 != 7 && base16 != 8)
			{
				BigInteger remainder = new BigInteger();
				BigInteger sqrt = input.NthRoot(2, out remainder);

				return (remainder == 0);
				// - OR -
				//return (sqrt.Square() == input);
			}
			return false;
		}
		private static BigInteger Fifteen = new BigInteger(15);
	}

	public static class IEnumerableBigIntegerExtensionMethods
	{
		// Product
		public static BigInteger Product(this IEnumerable<int> source)
		{
			return source.Select(n => new BigInteger(n)).Aggregate((accumulator, current) => accumulator * current);
		}

		// Sum
		public static BigInteger Sum(this IEnumerable<BigInteger> source)
		{
			return source.Aggregate((accumulator, current) => accumulator + current);
		}

		// GCD
		public static BigInteger GCD(this IEnumerable<BigInteger> source)
		{
			return source.Aggregate(BigInteger.GreatestCommonDivisor);
		}
	}
}