using System.Collections;
using System.Collections.Generic;

public class NodeGene
{
    int idNum;
    public enum TYPE
    {
        INPUT,
        HIDDEN,
        OUTPUT
    }

    TYPE type;

    public NodeGene(TYPE type, int id) {

    }
    //nodes.Count(), math.GetRandomDouble(random, -1, 1)
}
