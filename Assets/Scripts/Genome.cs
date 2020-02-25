using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;
using System.Linq;

public class Genome
{
    List<NodeGene> nodes = new List<NodeGene>();
    int inputNum = 0;
    int outputNum = 0;

    /* innovation is an ID assigned to each unique connection
     * We keep a list of connections so that a preexisting connection is assigned a preexisting innovation number
     * Once we get the index of the preexisting connection, we match it to this array
    */
    public static int innovation = 0;

    // Adjacency matrix with relevant innovation number at existing connection index
    // [input node][output node] = innovation number
    public static List<List<int?>> adjacency = new List<List<int?>>();

    // Another adjacency matrix for local connections
    List<List<ConnectionGene?>> localAdjacency = new List<List<ConnectionGene?>>();

    // Adjacency list without null values used for dot product
    List<List<double>> weights = new List<List<double>>();

    // Used when checking for circular structure
    List<bool> connectionIsBacktracing = new List<bool>();

    public Genome(int inputSize, int outputSize, List<List<int>> connections) {
        // Add input nodes
        for (int i = 0; i < inputSize; i ++) {
            this.nodes.Add(new NodeGene(0, nodes.Count));
            inputNum++;
        }
        // Add output nodes
        for (int i = 0; i < outputSize; i ++) {
            this.nodes.Add(new NodeGene(2, nodes.Count));
            outputNum++;
        }
        // Add initial connections
        for (int i = 0; i < connections.Count; i ++) {
            addConnection(connections[i][0], connections[i][1], math.GetRandomDouble(-1, 1));
        }
    }

    // Used when adding new connections
    private int? updateAdjacencies(int input, int output) {
        return adjacency[input][output] == null ? innovation++ : adjacency[input][output];
    }
    // Check if connection is possible
    private bool checkValid(int input, int output) {
        // If connection or reversed connection exists already: return false
        if (localAdjacency[input][output] != null || localAdjacency[output][input] != null) {
            return false;
        }
        // Reset backtracing list
        connectionIsBacktracing.Clear();
        for (int i = 0; i < localAdjacency.Count; i ++) {
            connectionIsBacktracing.Add(new List<bool>());
            for (int j = 0; j < localAdjacency[i].Count; j ++) {
                connectionIsBacktracing[i].Add(false);
            }
        }

        //
        for (int j = inputNum; j < outputNum; j ++) {
            if (!backtrace(j)) {
                return false;
            }
        }
        return true;
    }

    private bool backtrace(int in, int out) {
        if (nodeIsBacktracing[node]) {
            return false;
        }
        nodeIsBacktracing[node] = true;
        for (int i = 0; i < localAdjacency[node].Count; i ++) {
            if (!backtrace(i)) {
                return false;
            }
        }
        return true;
    }

    //feedforward the network
    List<double> calculate() {
        //todo Get inputs
        List<double> output = new List<double>();
        for (int i = inputNum; i < outputNum; i ++) {
            output.Add(nodes[i].getOutput());
        }
        return output;
    }

    // Mutations
    // Add new connection between nodes
    public bool addConnection(int input, int output, double weight) {
        if (!checkValid(input, output)) {
            connections.Add(new ConnectionGene(input, output, weight, updateAdjacencies(input, output)));
            return true;
        }
        return false;
    }

    // Split existing connection, adding a hidden node in the middle
    // Incoming weight is set to 1, outgoing is the same as the previous weight
    private void addNode(ConnectionGene connection) {
        double oldWeight = connection.Split();
        int[] oldConnections = connection.getNodes();
        nodes.Add(new NodeGene(1, nodes.Count));
        addConnection(oldConnections[0], nodes.Count-1, 1);
        addConnection(nodes.Count-1, oldConnections[1], oldWeight);
    }
}
