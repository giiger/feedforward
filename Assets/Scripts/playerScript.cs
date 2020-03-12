using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public List<List<int>> initialConnections = new List<List<int>> {
        new List<int> {0,2},
        new List<int> {0,3},
        new List<int> {1,3},
        new List<int> {1,4}
    };
    void Awake() {
        Brain brain = new Brain(initialConnections);
    }

    public List<double> getInput() {
        return new List<double>() {
            transform.position.x,
            transform.position.y
        };
    }
}
