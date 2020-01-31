using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class ConnectionGene
{
    int inNode;
    int outNode;
    Double weight;
    bool enabled;
    static int innovation;
    public ConnectionGene(int in, int out, Double weight = (new Random().NextDouble()-0.5)*2)
    {
        
    }
}
