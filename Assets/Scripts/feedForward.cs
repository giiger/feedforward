import numpy as np





class Neuron :
  def __init__(self, inputSize):
    self.inputSize = inputSize
    self.weights = []
self.bias = 0 //np.random.normal()

    for i in range(0, inputSize) :
      self.weights.append(1)//np.random.normal())
    math
  // Return dot product of inputs and weights
  def feedforward(self, input):
    self.output = np.dot(input, self.weights) + self.bias
    return sigmoid(self.output)

  // Calculate derivative of each weight
def backProp(self, loss, output):
    // Derivative of loss with respect to the output of the network
    loss_d_output = -2* (1 - output[0])

    //Calculate derivative of each weight in the neuron with respect to 
    for i in range(0, len(self.weights)) :
      output_d_neuronOutput = 0
    
    //output_d_
    
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

    //// Temporary
    //self.loss = mse_loss(np.array([1]), np.array(testNet.layers[2].output))

    return self.output

// Holds layers
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
// Give neural network input to first layer
    self.layerOutputs.append(self.input)
    // Give output of previous layer as input to next layer
    for i in range(1, len(self.layers)) :
      self.layerOutputs.append(self.layers[i].feedforward())

testNet = NeuralNetwork([-2, -1], [2, 3, 1])
testNet.feedforward()

netOutput = testNet.layers[3].output
netLoss = mse_loss(np.array([1]), np.array(testNet.layers[3].output))

print("output: ", netOutput)
print("loss: ", netLoss)

testNet.layers[1].neurons[0].backProp(netLoss, netOutput)