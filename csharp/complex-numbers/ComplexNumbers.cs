using System;

public struct ComplexNumber
{
    double _real;
    double _imaginary;
    public ComplexNumber(double real, double imaginary)
    {
        _real = real;
        _imaginary = imaginary;
    }

    public double Real() => _real;
    public double Imaginary() => _imaginary;

    public ComplexNumber Mul(ComplexNumber other) => new ComplexNumber(_real * other._real -_imaginary * other._imaginary,
        _imaginary * other._real + _real * other._imaginary);

    public ComplexNumber Add(ComplexNumber other) => new ComplexNumber(_real + other._real,  _imaginary + other._imaginary);

    public ComplexNumber Sub(ComplexNumber other) => new ComplexNumber(_real - other._real, _imaginary - other._imaginary);

    public ComplexNumber Div(ComplexNumber other)
    {
        double r = (_real * other._real + _imaginary * other._imaginary) / 
            (other._real*other._real + other._imaginary*other._imaginary);
        double i = (_imaginary * other._real - _real * other._imaginary) / 
            (other._real*other._real + other._imaginary*other._imaginary);
        return new ComplexNumber(r, i);
    }

    public double Abs() => Math.Sqrt(_real * _real + _imaginary * _imaginary);


    public ComplexNumber Conjugate() => new ComplexNumber(_real, _imaginary * -1);
    
    public ComplexNumber Exp() => new ComplexNumber(Math.Exp(_real) * Math.Cos(_imaginary), Math.Sin(_imaginary));

}