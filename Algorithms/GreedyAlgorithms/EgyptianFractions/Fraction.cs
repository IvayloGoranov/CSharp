namespace Problem_5.Egyptian_Fractions
{
    using System;

    public class Fraction : IComparable<Fraction>
    {
        public Fraction(int nominator, int denominator)
        {
            this.Nominator = nominator;
            this.Denominator = denominator;
        }

        public int Denominator { get; set; }

        public int Nominator { get; set; }

        public static Fraction operator -(Fraction first, Fraction second)
        {
            int newNominator = first.Nominator * second.Denominator - second.Nominator * first.Denominator;
            int newDenominator = first.Denominator * second.Denominator;
            return new Fraction(newNominator, newDenominator);
        }

        public int CompareTo(Fraction other)
        {
            return (this.Nominator * other.Denominator).CompareTo(other.Nominator * this.Denominator);
        }

        public override string ToString()
        {
            return this.Nominator + "/" + this.Denominator;
        }
    }
}
