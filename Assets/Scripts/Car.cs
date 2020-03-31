using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    Brain carBrain;
    public int outputs, inputs;

    public List<List<int>> initialConnections = new List<List<int>> {
        new List<int> {0,2},
        new List<int> {1,2},
    };
    public List<double> getInput() {
        return new List<double>() {
            transform.position.x,
            transform.position.y
        };
    }

    void Awake() {
        carBrain = new Brain(inputs, outputs, initialConnections);
        carBrain.getOutput();
    }
    void Update() {
        carBrain.updateInput(getInput());
        Debug.Log(carBrain.getOutput()[0]);
    }

}
