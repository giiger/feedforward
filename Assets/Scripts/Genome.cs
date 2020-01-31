using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;

public class Genome
{
    Random random = new Random();
    List<ConnectionGene> connections;
    List<NodeGene> nodes;
    int innovation = 0;

    public Genome(int inputSize, int outputSize) {
        // Add input nodes of type INPUT
        for (int i = 0; i < inputSize; i ++) {
            nodes.Add(new NodeGene(NodeGene.TYPE.INPUT, i));
        }
    }

    void addConnection() {

    }
    void addNode() {

    }
}
