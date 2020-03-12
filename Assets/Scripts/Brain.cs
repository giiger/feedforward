using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Brain
{
    int inputs = 2;
    int outputs = 3;
    // If some connections should exist before evolving, they may be initialized here
    List<List<int>> initialConnections = new List<List<int>> {

    };
    Genome genome;

    public Brain(List<List<int>> initialConnections) {
        genome = new Genome(inputs, outputs, initialConnections);
        this.initialConnections = initialConnections;
    }

    List<double> getOutput() {
        List<double> output = genome.feedforward();
        return output;
    }
}
