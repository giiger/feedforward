using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class ConnectionGene
{
    private int inNode;
    private int outNode;
    double weight;
    bool enabled;
    // static int innovation;
    public ConnectionGene(int inNode, int outNode, double weight)
    {
        this.inNode = inNode;
        this.outNode = outNode;
        this.weight = weight;
    }
}
