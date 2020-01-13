using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class feedForward : MonoBehaviour
{
    class Neuron
    {
        int inputSize;
        List<Double> weights = new List<double>();
        double bias = 0;
        double output;
        public Neuron(int size)
        {
            this.inputSize = size;

            for (int i = 0; i < this.inputSize; i++) {
                this.weights.Add(1);
            }
        }

        // Return dot product of inputs and weights
        public double feedForward(List<double> input)
        {
            this.output = math.arrDot(input, this.weights) + this.bias;
            return math.sigmoid(this.output);
        }
    }

    private void Start()
    {
        Neuron neuron = new Neuron(2);
        Debug.Log(neuron.feedForward(new List<double> { 10, 2 }));
    }
}



/*
class Layer :
  def __init__(self, size, inputLayer, parent):
    self.neurons = []
self.size = size
self.inputLayer = inputLayer
self.input = []

self.parent = parent

self.output = []

    for i in range(self.size):

  self.neurons.append(Neuron(self.parent.layerSizes[self.inputLayer]))

  def getInput(self):
    self.input.clear()
    self.input = self.parent.layerOutputs[self.inputLayer]

  def feedforward(self):
    self.getInput()
    self.output.clear()

    for i in range (0, len(self.neurons)):
      self.output.append(self.neurons[i].feedforward(self.input))
    print(self.output)

    ## Temporary
    #self.loss = mse_loss(np.array([1]), np.array(testNet.layers[2].output))

    return self.output

# Holds layers
class NeuralNetwork :
  def __init__(self, input, layerSizes):
    self.layers = [input]
self.layerSizes = [len(input)] + layerSizes
self.layerOutputs = [input]
    self.input = input

    for i in range (0, len(layerSizes)):
      self.layers.append(Layer(layerSizes[i], i, self))

  def feedforward(self):
    self.layerOutputs.clear()
# Give neural network input to first layer
    self.layerOutputs.append(self.input)
    # Give output of previous layer as input to next layer
    for i in range(1, len(self.layers)) :
      self.layerOutputs.append(self.layers[i].feedforward())

testNet = NeuralNetwork([-2, -1], [2, 3, 1])
testNet.feedforward()

netOutput = testNet.layers[3].output
netLoss = mse_loss(np.array([1]), np.array(testNet.layers[3].output))

print("output: ", netOutput)
print("loss: ", netLoss)

testNet.layers[1].neurons[0].backProp(netLoss, netOutput)
*/