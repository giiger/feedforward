using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class NodeGene
{
    int idNum;
    int type;
    int node;
    public bool done = false;
    double value;
    List<NodeGene> inputs = new List<NodeGene>();
    List<NodeGene> outputs = new List<NodeGene>();

    public NodeGene(int nodeType, int id) {
        type = nodeType;
        idNum = id;
    }
    //nodes.Count(), math.GetRandomDouble(random, -1, 1)
    public int getID() {
        return idNum;
    }

    public void getOutput() {
        for (int i = 0; i < inputs.Count; i ++) {
            if (!inputs[i].done) {
                inputs[i].getOutput();
            }
        }
        List<double> inputValues = inputs.Select(o => o.value).ToList();
        //value = math.arrDot(inputValues);
    }

    //Use for input nodes
    public double assignValue(double newValue) {
        value = newValue;
    }

}
