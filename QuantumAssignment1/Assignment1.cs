using System;

namespace ComplexNumbers
{
    class ComplexCalculator
    {
        public void Add(int a1, int b1, int a2, int b2)
        {
            Console.WriteLine("The sum is ({0}) + ({1})i.", a1 + a2, b1 + b2);
        }

        public void Subtract(int a1, int b1, int a2, int b2)
        {
            Console.WriteLine("The difference is ({0}) + ({1})i.", a1 - a2, b1 - b2);
        }
        public void Multiply(int a1, int b1, int a2, int b2)
        {
            Console.WriteLine("The product is ({0}) + ({1})i.", (a1*a2) - (b1*b2), (a1*b2) + (a2*b1));
        }
        public void Divide(int a1, int b1, int a2, int b2)
        {
            Console.WriteLine("The quotient is ({0:0.###}) + ({1:0.###})i.", (double) ((a1 * a2) + (b1 * b2)) / (Math.Pow(a2, 2) + Math.Pow(b2, 2)), (double) ((a2 * b1) - (a1 * b2)) / (Math.Pow(a2, 2) + Math.Pow(b2, 2)));
        }

        public double Modulus(int a, int b)
        {
            return Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
        }
        public void ComplexConjugate(int a1, int b1, int a2, int b2)
        {
            Console.WriteLine("The complex conjugate of C1 is ({0}) - ({1})i, and the complex conjugate of C2 is ({2}) - ({3})i.", a1, b1, a2, b2);
        }

        public void OpSet(ComplexCalculator complex, int a1, int b1, int a2, int b2)
        {
            complex.Add(a1, b1, a2, b2);
            complex.Subtract(a1, b1, a2, b2);
            complex.Multiply(a1, b1, a2, b2);
            complex.Divide(a1, b1, a2, b2);
            complex.ComplexConjugate(a1, b1, a2, b2);
        }

        public double FindAngle(double y, double x)
        {
            if (x > 0)
            {
                return Math.Atan(y/x);
            }
            else if(x < 0 && y >= 0)
            {
                return Math.Atan(y / x) + Math.PI;
            }
            else if (x < 0 && y < 0)
            {
                return Math.Atan(y / x) - Math.PI;
            }
            else if (x == 0 && y > 0)
            {
                return Math.PI / 2;
            }
            else if (x == 0 && y < 0)
            {
                return 0 - (Math.PI / 2);
            }
            else
            {
                return 0;
            }

        }


        public void PolarMultiply(double a1, double b1, double a2, double b2)
        {
            Console.WriteLine("The product of P1 and P2 is ({0:0.###}) + ({1:0.###})i.", (a1 * a2), (b1 + b2));
        }

        public void PolarDivide(double a1, double b1, double a2, double b2)
        {
            Console.WriteLine("The quotient of P1 and P2 is ({0:0.###}) + ({1:0.###})i.", (a1 / a2), (b1 - b2));
        }


        public static void Main()
        {
            bool running = true;

            while (running) {

                Console.WriteLine("Enter the real segment of the first complex number (C1):");
                string s = System.Console.ReadLine();
                int a1 = Convert.ToInt32(s);

                Console.WriteLine("Enter the imaginary segment of the first complex number (C1):");
                s = System.Console.ReadLine();
                int b1 = Convert.ToInt32(s);

                Console.WriteLine("Enter the real segment of the second complex number (C2):");
                s = System.Console.ReadLine();
                int a2 = Convert.ToInt32(s);

                Console.WriteLine("Enter the imaginary segment of the second complex number (C2):");
                s = System.Console.ReadLine();
                int b2 = Convert.ToInt32(s);

                ComplexCalculator complex = new ComplexCalculator();
                complex.OpSet(complex, a1, b1, a2, b2);

                double p1 = complex.Modulus(a1,b1);
                Console.WriteLine("The modulus of C1 is {0:0.###}, and the modulus of C2 is {1:0.###}.", complex.Modulus(a1, b1), complex.Modulus(a2, b2));

                double aP1 = complex.Modulus(a1, b1);
                double aP2 = complex.Modulus(a2, b2);
                double bP1 = complex.FindAngle(b1, a1);
                double bP2 = complex.FindAngle(b2, a2);

                Console.WriteLine("P1, the polar form of C1, is ({0:0.###}, {1:0.###}), and P2, the polar form of C2, is ({2:0.###}, {3:0.###}).", aP1, bP1, aP2, bP2);

                complex.PolarMultiply(aP1, bP1, aP2, bP2);
                complex.PolarDivide(aP1, bP1, aP2, bP2);

                Console.WriteLine("When converted back to Cartesian form, P1 becomes ({0:0.###}) + ({1:0.###})i, and P2 becomes ({2:0.###}) + ({3:0.###})i.", aP1 * Math.Cos(bP1), aP1 * Math.Sin(bP1), aP2 * Math.Cos(bP2), aP2 * Math.Sin(bP2));



                Console.WriteLine("Continue? (Y/N)");
                string input = Console.ReadLine();
                if(input.Equals("N") || input.Equals("n"))
                {
                    running = false;
                }
            }
        }
    }
}