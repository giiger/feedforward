using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class ConnectionGene
{
    private int inNode;
    private int outNode;
    private double weight;
    private bool enabled;
    private int innovation;

    public ConnectionGene(int inNode, int outNode, double weight, int innovation)
    {
        this.inNode = inNode;
        this.outNode = outNode;
        this.weight = weight;
        this.innovation = innovation;
    }

    public void Disable()
    {
        enabled = false;
    }
}
