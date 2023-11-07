using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad2 : MonoBehaviour
{
    [SerializeField] private Vector3 target1 = new Vector3(0, 0.5f, 0);
    [SerializeField] private Vector3 target2 = new Vector3(10, 0.5f, 0);
    [SerializeField] public float speed = 2f;
    private bool isMovingBack = false;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Vector3.Distance(transform.position, target1) < 1f)
        {
            isMovingBack = true;
        }

        if (isMovingBack == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, target1, Time.deltaTime * speed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target2, Time.deltaTime * speed);
        }
    }
 


}
