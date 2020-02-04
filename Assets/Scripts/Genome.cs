using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;

public class Genome
{
    List<ConnectionGene> connections = new List<ConnectionGene>();
    List<NodeGene> nodes = new List<NodeGene>();
    List<List<int>> connectionNodes = new List<List<int>>();

    /* innovation is an ID assigned to each unique connection
     * We keep a list of connections so that a preexisting connection is assigned a preexisting innovation number
     * Once we get the index of the preexisting connection, we match it to this array
     * I am sure there is a better way to do this
    */
    public static int innovation = 0;
    public static List<List<int>> allConnections = new List<List<int>>();
    public static List<int> allInnovations = new List<int>();

    public Genome(int inputSize, int outputSize, List<List<int>> connections) {
        // Add input nodes
        for (int i = 0; i < inputSize; i ++) {
            this.nodes.Add(new NodeGene(0, nodes.Count));
        }
        // Add output nodes
        for (int i = 0; i < outputSize; i ++) {
            this.nodes.Add(new NodeGene(2, nodes.Count));
        }
        // Add initial connections
        for (int i = 0; i < connections.Count; i ++) {
            addConnection(connections[i][0], connections[i][1], math.GetRandomDouble(-1, 1));
        }
    }

    // Return innovation number of pre-existing connection or return and increment innovation number
    private int connectionExists(int input, int output) {
        int index = allConnections.IndexOf(new List<int>{input, output});
        return index == -1 ? innovation++ : allInnovations[index];
    }
    //Check if the connection has already been made inside the existing genome
    private bool connectionExistsLocal(int input, int output) {
        if (!connectionNodes.Contains(new List<int> {input, output})) {
            return false;
        }
        return false;
    }

    // Mutations
    // Add new connection between nodes
    public bool addConnection(int input, int output, double weight) {
        if (!connectionExistsLocal(input, output)) {
            connections.Add(new ConnectionGene(input, output, weight, connectionExists(input, output)));
            connectionNodes.Add(new List<int> {input, output});
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
