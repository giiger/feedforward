using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Brain : MonoBehaviour
{
    int inputs = 3;
    int outputs = 2;
    // If some connections should definitely exist, they may be initialized here
    List<List<int>> initialConnections = new List<List<int>> {
        new List<int> {0,1}
    };
    Genome genome;

    void Awake() {
        genome = new Genome(1, 2, initialConnections);
        // Debug.Log(testGenome.addConnection(1, 2, 3.5));
        // Debug.Log(testGenome2.addConnection(3, 4, 5));
    }
    void mutate() {
        if (genome.addConnection())
    }
}
