﻿using System;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ExtendedArithmetic
{
	public class Term : ICloneable<Term>
	{
		[DataMember]
		public int Exponent { get; set; }

		[DataMember]
		public BigInteger CoEfficient { get; set; }

		[IgnoreDataMember]
		private const string IndeterminateSymbol = "X";

		public Term()
		{
		}

		public Term(BigInteger coefficient, int exponent)
		{
			Exponent = exponent;
			CoEfficient = coefficient.Clone();
		}

		public static Term[] GetTerms(BigInteger[] terms)
		{
			List<Term> results = new List<Term>();

			int degree = 0;
			foreach (BigInteger term in terms)
			{
				results.Add(new Term(term.Clone(), degree));

				degree += 1;
			}

			return results.ToArray();
		}

		public BigInteger Evaluate(BigInteger indeterminate)
		{
			return BigInteger.Multiply(CoEfficient, BigInteger.Pow(indeterminate, Exponent));
		}

		public Term Clone()
		{
			return new Term(this.CoEfficient.Clone(), this.Exponent);
		}

		public override int GetHashCode()
		{
			return new Tuple<BigInteger, int>(CoEfficient, Exponent).GetHashCode();
		}

		public override string ToString()
		{
			return $"{CoEfficient}*{IndeterminateSymbol}^{Exponent}";
		}
	}
}
