using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;

public class Genome
{
    //Random random = new Random();
    List<ConnectionGene> connections = new List<ConnectionGene>();
    public List<NodeGene> nodes = new List<NodeGene>();
    int innovation = 0;

    public Genome(int inputSize, int outputSize, List<List<int>> connections) {
        // Add input nodes of type INPUT
        for (int i = 0; i < inputSize; i ++) {
            this.nodes.Add(new NodeGene(0, i));
        }
    }

    void addConnection(int input, int output, double weight) {
        connections.Add(new ConnectionGene(input, output, weight, innovation));
        innovation ++;
    }
    void addNode(ConnectionGene connection) {
        connection.Disable();
        
    }
}
