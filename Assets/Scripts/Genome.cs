using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;
using System.Linq;

public class Genome {
    private List<List<ConnectionGene?>> localConnections = new List<List<ConnectionGene>>();
    private List<NodeGene?> localNodes = new List<NodeGene>();

    private List<List<bool?>> connectionsAsBools;

    public Genome(int inputSize, int outputSize, List<List<int>> connections) {
        // Add input nodes
        for (int i = 0; i < inputSize; i ++) {
            inputNum++;
        }
        // Add output nodes
        for (int i = 0; i < outputSize; i ++) {
            this.nodes.Add(new NodeGene(2, localNodes.Count));
            outputNum++;
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
        for (int i = 0; i < localConnections[0].Count; i ++) {
            localConnections[localConnections.Count].Add(null);
        }
        for (int i = 0; i < localConnections.Count; i ++) {
            localConnections[i].Add(null);
        }
    }

    private bool checkConnection(int inNode, int outNode) {
        if (localConnections[inNode][outNode] || localConnections[outNode][inNode]) {
            return false;
        }
    }

    private void addConnection(int inNode, int outNode, double weight) {
        if (checkConnection(inNode, outNode)) {
            localConnections[inNode][outNode] = new ConnectionGene(inNode, outNode, weight, innovation);
        }
    }

    //Make copy of connection list, with input connections set to true/completed and others set to false
    private void connectionsToBools(int testIn, int testOut) {
        connectionsToBools = new List<List<bool?>>();
        for (int i = 0; i < connections.Count; i ++) {
            connectionsToBools.Add(new List<bool?>());
            for (int j = 0; j < connections[i].Count; j ++) {
                if (connections[i][j] != null) {
                    if (localNodes[i].getType() == 0) {
                        connectionsAsBools[i][j]
                    }
                }
            }
        }
    }

}
