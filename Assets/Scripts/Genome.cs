using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;
using System.Linq;
using UnityEngine;

public class Genome {
    private List<List<ConnectionGene>> localConnections = new List<List<ConnectionGene>>();
    private List<NodeGene> localNodes = new List<NodeGene>();

    private List<List<bool?>> connectionsAsBools;

    int inputCount, outputCount = 0;

    public static int innovation = 0;


    public Genome(int inputSize, int outputSize, List<List<int>> connections) {
        // Add input nodes
        for (int i = 0; i < inputSize; i ++) {
            addNode(0);
            localNodes[i].assignValue(2);
            inputCount++;
        }
        // Add output nodes
        for (int i = 0; i < outputSize; i ++) {
            addNode(2);
            outputCount++;
        }
        // Add initial connections
        for (int i = 0; i < connections.Count; i ++) {
            addConnection(connections[i][0], connections[i][1], math.GetRandomDouble(-1, 1));
        }
    }

    // Update adjacency with null values
    private void addNode(int type) {
        localNodes.Add(new NodeGene(type, localNodes.Count));
        localConnections.Add(new List<ConnectionGene>());
        for (int i = 0; i < localNodes.Count; i ++) {
            localConnections[localConnections.Count-1].Add(null);
        }
        for (int i = 0; i < localConnections.Count; i ++) {
            localConnections[i].Add(null);
        }
    }

    private bool checkConnection(int inNode, int outNode) {
        if (localConnections[inNode][outNode] != null || localConnections[outNode][inNode] != null) {
            return false;
        }
        return true;
    }

    private void addConnection(int inNode, int outNode, double weight) {
        if (checkConnection(inNode, outNode)) {
            localConnections[inNode][outNode] = new ConnectionGene(localNodes[inNode], localNodes[outNode], weight, innovation);
            innovation++;
        }
    }

    //Make copy of connection list, with input connections set to true/completed and others set to false
    private void connectionsToBools(int testIn, int testOut) {
        connectionsAsBools = new List<List<bool?>>();
        for (int i = 0; i < localConnections.Count; i ++) {
            connectionsAsBools.Add(new List<bool?>());
            for (int j = 0; j < localConnections[i].Count; j ++) {
                if (localConnections[i][j] != null) {
                    if (localNodes[i].getType() == 0) {
                        connectionsAsBools[i].Add(true);
                    }
                    else {
                        connectionsAsBools[i].Add(false);
                    }
                }
                else {
                    connectionsAsBools[i].Add(null);
                }
            }
        }
    }

    public List<double> feedforward() {
        List<double> output = new List<double>();
        for (int i = inputCount; i < outputCount+inputCount; i ++) {
            output.Add(localNodes[i].getOutput());
        }
        return output;
    }
}
