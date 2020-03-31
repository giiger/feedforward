using System;
using System.Collections;
using System.Collections.Generic;

public class Neuron
{
    List<int> inputNeuronIndices = new List<int>();
    List<Double> weights = new List<Double>();
    Double bias = 0;
    Double output;
    public Neuron(List<int> inputNeuronIndices)
    {
        
    }
    // Return dot product of inputs and weights
    public Double feedForward(List<Double> input)
    {
        this.output = math.arrDot(input, this.weights) + this.bias;
        return math.sigmoid(this.output);
    }
}