using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    Brain brain;
    public List<List<int>> initialConnections = new List<List<int>> {
        new List<int> {0,2},
        new List<int> {1,2},
    };
    void Awake() {
        brain = new Brain(initialConnections);
        brain.getOutput();
    }

    public List<double> getInput() {
        return new List<double>() {
            transform.position.x,
            transform.position.y
        };
    }
    void Update() {
        brain.updateInput(getInput());
        transform.Translate(Vector3.right * (float)brain.getOutput()[0]);
    }
}
