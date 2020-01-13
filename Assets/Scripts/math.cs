using System;
using System.Collections.Generic;
using System.Linq;


public static class math
{
    public static double E = 2.7182818284590451;

    public static List<double> arrSub(List<double> a, List<double> b)
    {
        List<double> c = new List<double>();
        for (int i = 0; i < a.Count; i ++)
        {
            c.Add(a[i] - b[i]);
        }
        return c;
    }
    public static List<double> arrAdd(List<double> a, List<double> b)
    {
        List<double> c = new List<double>();
        for (int i = 0; i < a.Count; i++)
        {
            c.Add(a[i] + b[i]);
        }
        return c;
    }
    public static List<double> arrPow(List<double> a, double power)
    {
        List<double> c = new List<double>();
        for (int i = 0; i < a.Count; i++)
        {
            c.Add(Math.Pow(a[i], power));
        }
        return c;
    }
    public static List<double> arrMean(List<double> a, double power)
    {
        List<double> c = new List<double>();
        for (int i = 0; i < a.Count; i++)
        {
            c.Add(Math.Pow(a[i], power));
        }
        return c;
    }

    public static double arrDot(List<double> a, List<double> b)
    {
        double c = 0;
        for (int i = 0; i < a.Count; i++)
        {
            c +=(a[i] * b[i]);
        }
        return c;
    }

    public static double sigmoid(double x) {
        // Sigmoid activation function: f(x) = 1 / (1 + e^(-x))
        return 1 / (1 + Math.Pow(E, -x));
    }

    public static double deriv_sigmoid(double x)
    {
        // Derivative of sigmoid: f'(x) = f(x) * (1 - f(x))
        double fx = sigmoid(x);
        return fx * (1 - fx);
    }
    public static double mse_loss(List<double> y_true, List<double> y_pred)
    {
        // y_true and y_pred are numpy arrays of the same length.
        return arrPow(arrSub(y_true, y_pred), 2).Average();
    }
}