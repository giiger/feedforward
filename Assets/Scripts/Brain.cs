using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Brain
{
    int inputs = 2;
    int outputs = 1;
    // If some connections should exist before evolving, they may be initialized here
    List<List<int>> initialConnections = new List<List<int>> {

    };
    Genome genome;

    public Brain(List<List<int>> initialConnections) {
        this.initialConnections = initialConnections;
        genome = new Genome(inputs, outputs, initialConnections);
    }

    public void updateInput(List<double> input) {
        genome.updateNetwork(input);
    }

    public List<double> getOutput() {
        return genome.feedforward();
    }
}
