using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brain
{
    class Neuron
    {
        int inputSize;
        List<Double> weights = new List<Double>();
        Double bias = 0;
        Double output;

        // Return dot product of inputs and weights
        public Double feedForward(List<Double> input)
        {
            this.output = math.arrDot(input, this.weights) + this.bias;
            return math.sigmoid(this.output);
        }
    }
    public class NeuralNetwork 
    {
        
    }
}