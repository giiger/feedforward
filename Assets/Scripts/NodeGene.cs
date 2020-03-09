using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class NodeGene
{
    int idNum;
    int type;
    int node;
    public bool done = false;
    public double value;
    List<NodeGene> inputs = new List<NodeGene>();

    public NodeGene(int nodeType, int id) {
        type = nodeType;
        idNum = id;
    }

    public int getID() {
        return idNum;
    }
    public int getType() {
        return type;
    }

    public void getOutput() {
        if (type != 0) {
            for (int i = 0; i < inputs.Count; i ++) {
                if (!inputs[i].done) {
                    inputs[i].getOutput();
                }
            }
            value = Genome.calcNode(idNum);
        }
    }

    //Use for input nodes
    public void assignValue(double newValue) {
        value = newValue;
        done = true;
    }

}
