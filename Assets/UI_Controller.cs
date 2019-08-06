using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour
{
    #region Singleton
    public static UI_Controller instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion

    public string[] charactersName;
    public Sprite[] charactersSprite;

    bool P1_Ready;
    bool P2_Ready;

    public void SetReady(enumPlayer player)
    {
        switch (player)
        {
            case enumPlayer.Player1:
                P1_Ready = true;
                break;
            case enumPlayer.Player2:
                P2_Ready = true;
                break;
            default:
                break;
        }
        if (P1_Ready && P2_Ready)
        {
            StartCoroutine("startGameCoroutine");
        }
    }


    public enum enumPlayer
    {
        Player1,
        Player2
    }

    IEnumerator startGameCoroutine()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);
    }
}
