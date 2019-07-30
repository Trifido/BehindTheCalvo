using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ScriptPlayer : MonoBehaviour
{
    public NavMeshAgent myNav;
    public float velocidad;

    public bool trabajandoBool;
    public bool slowedDown;


    private void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            myNav.Move(new Vector3(Input.GetAxisRaw("Horizontal") * velocidad,0, Input.GetAxisRaw("Vertical") * velocidad));
        }

        if (Input.GetKeyUp(KeyCode.O))
        {
            SlowDown(0.5f);
        }
    }

    public void SafeZone()
    {
        trabajandoBool = !trabajandoBool;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Asiento"))
        {
            SafeZone();
            SlowDown(0.5f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Asiento"))
        {
            SafeZone();
            SlowDown(0.5f);
        }
    }

    public void SlowDown(float slowFactor)
    {
        if (slowedDown == false)
        {
            slowedDown = true;
            StartCoroutine("SlowDownCoroutine", slowFactor);
            Debug.Log("SLOWED BITCH!");
        }
    }

    IEnumerator SlowDownCoroutine(float slowF)
    {
        float temp = velocidad;
        velocidad = velocidad * slowF;
        while (velocidad < temp)
        {
            yield return new WaitForSeconds(0.2f);
            velocidad += 0.01f;
        }
        velocidad = temp;
        slowedDown = false;
    }
}
