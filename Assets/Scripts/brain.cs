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
        public Neuron(int size)
        {
            this.inputSize = size;

            for (int i = 0; i < this.inputSize; i++) {
                this.weights.Add(1);
            }
        }

        // Return dot product of inputs and weights
        public Double feedForward(List<Double> input)
        {
            this.output = math.arrDot(input, this.weights) + this.bias;
            return math.sigmoid(this.output);
        }
    }
    class Layer 
    {
        int size;
        int inputLayer;
        NeuralNetwork parent;

        List<Neuron> neurons = new List<Neuron>();
        List<Double> input = new List<Double>();

        List<Double> output = new List<Double>();
        public Layer(int size, int inputLayer, NeuralNetwork parent) 
        {
            this.size = size;
            this.inputLayer = inputLayer;
            this.parent = parent;
            
            for (int i = 0; i < this.size; i ++) 
            {
                this.neurons.Add(new Neuron(this.parent.layerSizes[this.inputLayer]));
            }
        }

        List<Double> getInput() 
        {
            this.input.Clear();
            this.input = this.parent.layerOutputs[this.inputLayer];
        }

        List<Double> feedForward() 
        {
            this.getInput();
            this.output.clear();

            for (int i = 0; i < this.neurons.Count; i ++) 
            {
                this.output.Add(this.neurons[i].feedForward(this.input));
                Debug.Log(this.output);
            }
            return this.output;
        }
    }
    public class NeuralNetwork 
    {
        List<Layer> layers = new List<Layer>();
        public List<int> layerSizes;
        public List<Double> layerOutputs;
        public List<Double> input;
        public NeuralNetwork(List<Double> input, List<int> layerSizes) 
        {
            this.layerSizes = layerSizes;
            this.layerOutputs = input;
            this.input = input;

            for (int i = 0; i < this.layerSizes.Count; i ++)
            {
                this.layers.Add(new Layer(layerSizes[i], i, this));
            }
        }

        public void feedForward()
        {
            this.layerOutputs.clear();
            // Give neural network input to first layer
            this.layerOutputs.Add(this.input);
            // Give output of previous layer as input to next layer
            for (int i = 0; i < this.layers.Count; i ++) 
            {
                this.layerOutputs.Add(this.layers[i].feedForward());
            }
        }
    }
}

/*
    testNet = NeuralNetwork([-2, -1], [2, 3, 1])
    testNet.feedForward()

    netOutput = testNet.layers[3].output
    netLoss = mse_loss(np.array([1]), np.array(testNet.layers[3].output))

    print("output: ", netOutput)
    print("loss: ", netLoss)

    testNet.layers[1].neurons[0].backProp(netLoss, netOutput) */