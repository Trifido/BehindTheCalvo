using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        ScriptPlayer player = other.GetComponent<ScriptPlayer>();

        if (player != null)
        {
            GameManager.Instance.GoalReached(player.currentPlayer);
        }
    }


}
