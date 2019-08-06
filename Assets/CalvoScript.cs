using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CalvoScript : MonoBehaviour
{
    public float velocity;
    private Vector3 target;
    private uint furiousLevel;
    private bool isPursuit;
    private int playersIn = 0;

    public Collider visionCollider;
    private Collision collisionPlayer;

    public NavMeshAgent navCalvo;
    
    // Start is called before the first frame update
    void Start()
    {
        //velocity = 0.5f;
        furiousLevel = 0;
        Debug.Log(navCalvo.speed);
    }

    // Update is called once per frame
    void Update()
    { 
        if(isPursuit)
        {
            transform.LookAt(target);
            navCalvo.destination = target;
        }
        else
        {
            navCalvo.velocity = Vector3.zero;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            target = other.transform.position;
            playersIn++;
            isPursuit = true;
            Debug.Log(other.transform.name+" in");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            target = Vector3.zero;
            playersIn--;
            if (playersIn <= 0)
            {
                isPursuit = false; 
            }
            Debug.Log(other.transform.name + " left");
        }
    }

    //public void OnTriggerStay(Collider other)
    //{
    //    if (other.transform.CompareTag("Player"))
    //    {
    //        target = other.transform.position;
    //        isPursuit = true;
    //    }
    //    else
    //    {
    //        target = Vector3.zero;
    //        isPursuit = false;
            
    //    }
    //}

    public void SetPursuit(bool change)
    {
        isPursuit = change;
    }
}
