using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefabs : MonoBehaviour
{
    public GameObject froge;
    public int frogeAmnt;
   

    public void generateFroge()
    {
        for (int ii = 0; ii < frogeAmnt; ii++)
        {
            List<GameObject> frogeList = new List<GameObject>();
        float frogePosX = 0;
        float frogePosY = 0;

        bool locationInvalid = true;
        while (locationInvalid)
        {
            frogePosX = Random.Range(-10f, 10f);
            frogePosY = Random.Range(-4f, 4f);
            Vector3 currentPosition = new Vector3(frogePosX, frogePosY, 0);
            
            for (int i = 0; i < frogeList.Count; i++)
            {
                if (Vector3.Distance(frogeList[i].transform.position, currentPosition) < 2.5f * 10)
                {
                    locationInvalid = true;
                }
                else
                {
                    locationInvalid = false;
                }
                if(locationInvalid == true)
                    {

                    }
            }
        }
            GameObject frogeClone = Instantiate(froge, new Vector3(frogePosX, frogePosY, 0), Quaternion.identity) as GameObject;
            frogeList.Add(frogeClone);
        }



    }
    void Start()
    {
        generateFroge();
    }
}
