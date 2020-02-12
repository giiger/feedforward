using System.Collections;
using System.Collections.Generic;

public class NodeGene
{
    int idNum;
    int type;
    int node;
    List<NodeGene> inputs = new List<NodeGene>();

    public NodeGene(int nodeType, int id) {
        type = nodeType;
        idNum = id;
    }
    //nodes.Count(), math.GetRandomDouble(random, -1, 1)
    public int getID() {
        return idNum;
    }
}
