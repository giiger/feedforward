using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Brain : MonoBehaviour
{
    int inputs = 2;
    int outputs = 3;
    // If some connections should exist before evolving, they may be initialized here
    List<List<int>> initialConnections = new List<List<int>> {
        new List<int> {0,2},
        new List<int> {1,3},
        new List<int> {1,4}
    };
    Genome genome;

    void Awake() {
        genome = new Genome(inputs, outputs, initialConnections);
        List<double> output = getOutput();
        for (int i = 0; i < output.Count; i ++) {
            Debug.Log(output[i]);
        }
    }
    List<double> getOutput() {
        List<double> output = genome.feedforward();
        return output;
    }
}
