using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ConnectionGene
{
    private NodeGene inNode;
    private NodeGene outNode;
    private double weight;
    private bool enabled;
    private int innovation;

    public ConnectionGene(NodeGene inNode, NodeGene outNode, double weight, int innovation) {
        this.inNode = inNode;
        this.outNode = outNode;
        this.weight = weight;
        this.innovation = innovation;
        outNode.inputs.Add(inNode);
        outNode.weights.Add(weight);
    }
}
