using System;

public class ComplexNum
{
    public readonly double real;
    public readonly double imaginary;

    public ComplexNum(double real, double imaginary)
    {
        this.real = real;
        this.imaginary = imaginary;
    }

    override
    public bool Equals(object num)
    {
        var newNum = (ComplexNum)num;
        return newNum.real == real && newNum.imaginary == imaginary;
    }

    override
    public int GetHashCode()
    {
        double key = 1234567891;
        return (int)(real * key + imaginary * key);
    }
}

