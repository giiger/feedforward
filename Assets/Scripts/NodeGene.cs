using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NodeGene
{
    int idNum;
    int type;
    int node;
    public bool done = false;
    public double value;
    public List<NodeGene> inputs = new List<NodeGene>();
    List<double> inputValues = new List<double>();

    public List<double> weights = new List<double>();

    public NodeGene(int nodeType, int id) {
        type = nodeType;
        idNum = id;
    }

    public int getType() {
        return type;
    }

    public double getOutput() {
        if (type != 0 && !done) {
            for (int i = 0; i < inputs.Count; i ++) {
                inputValues.Add(inputs[i].getOutput());
            }
            value = math.tanh(math.arrDot(inputValues, weights));
            done = true;
        }
        return value;
    }

    //Use for input nodes
    public void assignValue(double newValue) {
        value = math.tanh(newValue);
        done = true;
    }

}
