using System.Collections;
using System;
using UnityEngine;
using UnityEngine.AI;

public class ScriptPlayer : MonoBehaviour
{
    public NavMeshAgent myNav;
    public float velocidad;

    public bool trabajandoBool;
    public bool slowedDown;

    public Player currentPlayer;

    private void Update()
    {
        switch (currentPlayer)
        {
            case Player.Player_1:
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
                {
                    myNav.Move(new Vector3((-Convert.ToInt32(Input.GetKey(KeyCode.A)) + Convert.ToInt32(Input.GetKey(KeyCode.D))) * velocidad, 0, (-Convert.ToInt32(Input.GetKey(KeyCode.S)) + Convert.ToInt32(Input.GetKey(KeyCode.W))) * velocidad));
                }
                break;
            case Player.Player_2:
                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow))
                {
                    myNav.Move(new Vector3((-Convert.ToInt32(Input.GetKey(KeyCode.LeftArrow)) + Convert.ToInt32(Input.GetKey(KeyCode.RightArrow))) * velocidad, 0, (-Convert.ToInt32(Input.GetKey(KeyCode.DownArrow)) + Convert.ToInt32(Input.GetKey(KeyCode.UpArrow))) * velocidad));
                }
                break;
            default:
                break;
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

    public void SetPlayer(Player p)
    {
        currentPlayer = p;
    }

    public enum Player
    {
        Player_1,
        Player_2
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
