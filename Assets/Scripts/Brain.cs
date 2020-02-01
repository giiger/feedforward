using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Brain : MonoBehaviour
{
    int inputs = 3;
    int outputs = 2;
    List<List<int>> connections = new List<List<int>>();


    void Awake() {
        Debug.Log(connections[0][1]);
        Genome testGenome = new Genome(2, 3, connections);
    }
}
