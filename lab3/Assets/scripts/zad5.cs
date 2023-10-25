using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad5 : MonoBehaviour
{
    public GameObject objectToSpawn;
    
    void Start()
    {
        for  (int i=0; i<10; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(159, 258),0.5f,Random.Range(135, 234));
            Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
        }
        
    }

    
    void Update()
    {
        
    }
}
