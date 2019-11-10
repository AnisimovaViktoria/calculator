using System;
using System.Collections.Generic;
using System.Text;

namespace ComplexCalculator
{
    public class Operations
    {
        public ComplexNum Sum(ComplexNum num1, ComplexNum num2) { return new ComplexNum(num1.real + num2.real, num1.imaginary + num2.imaginary); }
        public ComplexNum Dif(ComplexNum num1, ComplexNum num2) { return new ComplexNum(num1.real - num2.real, num1.imaginary - num2.imaginary); }
        public ComplexNum Prod(ComplexNum num1, ComplexNum num2)
        {
            var newReal = num1.real * num2.real - num1.imaginary * num2.imaginary;
            var newImaginary = num1.real * num2.imaginary + num1.imaginary * num2.real;
            return new ComplexNum(newReal, newImaginary);
        }


        public ComplexNum Pow(ComplexNum num, int pow)
        {
            if (pow > 0)
            {
                var res = num;
                --pow;
                while (pow != 0)
                {
                    --pow;
                    res = (Prod(res, num));
                }
                return res;
            }
            else throw new ArithmeticException("Incorrect power");
        }

        public ComplexNum Div(ComplexNum num1, ComplexNum num2)
        {
            if (num2.real == 0 && num2.imaginary == 0)
                throw new ArithmeticException("Division by 0");
            else
            {
                var denominator = (int)(num2.real * num2.real + num2.imaginary * num2.imaginary);
                var realNumerator = num1.real * num2.real + num1.imaginary * num2.imaginary;
                var imNumerator = num2.real * num1.imaginary - num1.real * num2.imaginary;
                return new ComplexNum(realNumerator / denominator, imNumerator / denominator);
            }
        }
    }
}

