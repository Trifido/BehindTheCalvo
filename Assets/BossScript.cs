using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossScript : MonoBehaviour
{
    public float velocity;
    private Vector3 target;
    private uint furiousLevel;
    private bool isPursuit;
    private int playersIn = 0;

    public Collider visionCollider;
    private Collision collisionPlayer;

    public List<GameObject> targets = new List<GameObject>(); //Arturo
    public GameObject targetToFollow;
    public bool isMovingRandom = false;

    public NavMeshAgent navCalvo;
    
    // Start is called before the first frame update
    void Start()
    {
        //velocity = 0.5f;
        navCalvo.speed = velocity;
        furiousLevel = 0;
    }

    // Update is called once per frame
    void Update()
    { 
        if(isPursuit)
        {
            FollowTarget();//Arturo
            //transform.LookAt(target);
            //navCalvo.destination = target;
        }
        else
        {
            MoveRandom();//Arturo
            //navCalvo.velocity = Vector3.zero;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            #region ArturoTarget 
            targets.Add(other.gameObject);
            NearestTarget();
            #endregion //Arturo

            /*playersIn++;
            isPursuit = true;
            Debug.Log(other.transform.name+" in");*/
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            #region Arturo leftTarget
            int length = targets.Count;
            for (int i = 0; i < length; i++)
            {
                if (other.gameObject == targets[i])
                {
                    targets.RemoveAt(i);
                    NearestTarget();
                }
            }

            #endregion //Arturo


            /*target = Vector3.zero;
            playersIn--;
            if (playersIn <= 0)
            {
                isPursuit = false; 
            }
            Debug.Log(other.transform.name + " left");*/
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

    public void NearestTarget() //Arturo
    {
        float minDis = 1000;
        int length = targets.Count;
        for (int i = 0; i < length; i++)
        {
            if (targets[i] != null)
            {
                float dist = (transform.position - targets[i].transform.position).magnitude;
                if (dist < minDis)
                {
                    minDis = dist;
                    targetToFollow = targets[i];
                }
            }           
        }
        if (targets.Count == 0)
        {
            isPursuit = false;
        }
        else
        {
            isPursuit = true;
        }
    }

    public void MoveRandom()//Arturo
    {
        if (isMovingRandom == false)
        {
            isMovingRandom = true;
            // x -> -8/8  ||  z -> -4/12
            float x = Random.Range(-8f, 8f);
            float z = Random.Range(-4f, 12f);
            Vector3 dir = new Vector3(x, 0, z);
            navCalvo.destination = dir;
            Debug.Log("Move to: " + dir);
            Debug.DrawRay(transform.position, dir);
        }
        if ((transform.position - navCalvo.destination).magnitude <= 1f && isMovingRandom == true)
        {
            isMovingRandom = false;
        }
    }

    public void FollowTarget()//Arturo
    {
        isMovingRandom = false;
        navCalvo.destination = targetToFollow.transform.position;
        Debug.Log("Player to follow: " + targetToFollow);
    }

    public void SetPursuit(bool change)
    {
        isPursuit = change;
    }
}
