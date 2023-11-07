using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad3 : MonoBehaviour
{
    [SerializeField] private Vector3 target1 = new Vector3(0, 0.5f, 0);
    [SerializeField] private Vector3 target2 = new Vector3(0, 0.5f, 10);
    [SerializeField] private Vector3 target3 = new Vector3(10, 0.5f, 10);
    [SerializeField] private Vector3 target4 = new Vector3(10, 0.5f, 0);
    [SerializeField] public float speed = 2f;
    private bool first = false;
    private bool second = false;
    private bool third = false;
    private Quaternion rotation1 = Quaternion.Euler(0, 90, 0);
    private Quaternion rotation2 = Quaternion.Euler(0, 180, 0);
    private Quaternion rotation3 = Quaternion.Euler(0, 270, 0);
    private Quaternion rotation4 = Quaternion.Euler(0, 0, 0);
    
    void Start()
    {

    }

    
    void Update()
    {
        if (Vector3.Distance(transform.position, target1) < 1f)
        {
            first = true;
            second = true;
        }
        else if (Vector3.Distance(transform.position, target2) < 1f)
        {
            second = false;
            third = true;
        }
        else if (Vector3.Distance(transform.position, target3) < 1f)
        {
            third = false;
        }
        else if (Vector3.Distance(transform.position, target4) < 1f)
        {
            first = false;
        }
     

        if (first == false)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation4, Time.time * speed);
            transform.position = Vector3.MoveTowards(transform.position, target1, Time.deltaTime * speed);
        }
        else if (second == true)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation1, Time.time * speed);
            transform.position = Vector3.MoveTowards(transform.position, target2, Time.deltaTime * speed);
        }
        else if (third == true)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation2, Time.time * speed);
            transform.position = Vector3.MoveTowards(transform.position, target3, Time.deltaTime * speed);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation3, Time.time * speed);
            transform.position = Vector3.MoveTowards(transform.position, target4, Time.deltaTime * speed);
        }
       
    }



}
