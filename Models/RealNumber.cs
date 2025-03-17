using System;

namespace AvaloniaApp.Models
{
    public class RealNumber : IComparable<RealNumber>
    {
        public int Sign { get; private set; }
        public double Mantissa { get; private set; }
        public int Order { get; private set; }

        public RealNumber(int sign, double mantissa, int order)
        {
            if (mantissa < 0)
                throw new ArgumentException("Мантисса должна быть неотрицательной");

            if (sign != 1 && sign != -1)
                throw new ArgumentException("Знак должен быть 1 или -1");

            Sign = sign;
            Mantissa = mantissa;
            Order = order;

            Normalize();
        }

        private void Normalize()
        {
            if (Mantissa == 0)
                return;

            while (Mantissa >= 10)
            {
                Mantissa /= 10;
                Order++;
            }
            while (Mantissa < 1)
            {
                Mantissa *= 10;
                Order--;
            }
        }

        public static RealNumber FromDouble(double value)
        {
            if (value == 0)
                return new RealNumber(1, 0, 0);

            int sign = value >= 0 ? 1 : -1;
            double absValue = Math.Abs(value);
            int order = 0;
            double mantissa = absValue;

            while (mantissa >= 10)
            {
                mantissa /= 10;
                order++;
            }
            while (mantissa < 1 && mantissa != 0)
            {
                mantissa *= 10;
                order--;
            }
            return new RealNumber(sign, mantissa, order);
        }

        public double ToDouble()
        {
            return Sign * Mantissa * Math.Pow(10, Order);
        }

        public override string ToString()
        {
            string signStr = Sign >= 0 ? "+" : "-";
            return $"{signStr}{Mantissa}E{Order}";
        }

        public static RealNumber operator +(RealNumber a, RealNumber b)
        {
            double result = a.ToDouble() + b.ToDouble();
            return RealNumber.FromDouble(result);
        }

        public static RealNumber operator -(RealNumber a, RealNumber b)
        {
            double result = a.ToDouble() - b.ToDouble();
            return RealNumber.FromDouble(result);
        }

        public static RealNumber operator *(RealNumber a, RealNumber b)
        {
            double result = a.ToDouble() * b.ToDouble();
            return RealNumber.FromDouble(result);
        }

        public static RealNumber operator /(RealNumber a, RealNumber b)
        {
            if (b.ToDouble() == 0)
                throw new DivideByZeroException("Деление на ноль");

            double result = a.ToDouble() / b.ToDouble();
            return RealNumber.FromDouble(result);
        }

        public int CompareTo(RealNumber other)
        {
            return this.ToDouble().CompareTo(other.ToDouble());
        }

        public override bool Equals(object obj)
        {
            if (obj is RealNumber other)
                return this.ToDouble().Equals(other.ToDouble());
            return false;
        }

        public override int GetHashCode()
        {
            return this.ToDouble().GetHashCode();
        }

        public static bool operator ==(RealNumber a, RealNumber b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            return a.Equals(b);
        }

        public static bool operator !=(RealNumber a, RealNumber b)
        {
            return !(a == b);
        }

        public static bool operator <(RealNumber a, RealNumber b)
        {
            return a.ToDouble() < b.ToDouble();
        }

        public static bool operator >(RealNumber a, RealNumber b)
        {
            return a.ToDouble() > b.ToDouble();
        }

        public static bool operator <=(RealNumber a, RealNumber b)
        {
            return a.ToDouble() <= b.ToDouble();
        }

        public static bool operator >=(RealNumber a, RealNumber b)
        {
            return a.ToDouble() >= b.ToDouble();
        }
    }
}