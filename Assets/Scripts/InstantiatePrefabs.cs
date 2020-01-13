using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefabs : MonoBehaviour
{
    public GameObject froge;
    public int frogeAmnt;

    public void generateFroge()
    {
        for(int ii = 0; ii < frogeAmnt; ii++)
        {
            Debug.Log("oops");
            int frogePosX = Random.Range(-100, 100);
            int frogePosY = Random.Range(-100, 100);
            GameObject frogeClone = Instantiate(froge, new Vector2(frogePosX, frogePosY), Quaternion.identity);
            List<GameObject> frogeList = new List<GameObject>();
            List<Vector3> frogePosList = new List<Vector3>();
            frogeList.Add(frogeClone);
            if (frogePosList.Contains(frogeClone.transform.position))
            {
                frogeClone.transform.position = new Vector2(frogePosX, frogePosY);
            }
            frogePosList.Add(frogeClone.transform.position);
        }
        
        
    }
    void Start()
    {
        generateFroge();
    }
}
