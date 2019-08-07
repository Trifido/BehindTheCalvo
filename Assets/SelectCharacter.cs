using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    int characterSelected;

    public Enumerations.Player player;

    public Text characterText;
    public Image characterImage;

    private void Start()
    {
        ChangeCharacter(0);
    }

    private void Update()
    {
        switch (player)
        {
            case Enumerations.Player.Player1:
                if (Input.GetKeyUp(KeyCode.A))
                {
                    ChangeCharacter(-1);
                }
                else if (Input.GetKeyUp(KeyCode.D))
                {
                    ChangeCharacter(1);
                }
                else if (Input.GetKeyUp(KeyCode.Space))
                {
                    SetCharacter();
                }
                break;
            case Enumerations.Player.Player2:
                if (Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    ChangeCharacter(-1);
                }
                else if (Input.GetKeyUp(KeyCode.RightArrow))
                {
                    ChangeCharacter(1);
                }
                else if (Input.GetKeyUp(KeyCode.Return))
                {
                    SetCharacter();
                }
                break;
            default:
                break;
        }
    }

    public void ChangeCharacter(int dir)
    {
        characterSelected = characterSelected + dir;
        if (characterSelected > GameManager.Instance.Players.Length-1)
        {
            characterSelected = 0;
        }
        else if (characterSelected < 0)
        {
            characterSelected = GameManager.Instance.Players.Length - 1;
        }
        characterText.text = GameManager.Instance.Players[characterSelected].playerName;
        characterImage.sprite = GameManager.Instance.Players[characterSelected].charactersSprite;
    }

    public void SetCharacter()
    {
        PlayerPrefs.SetInt(player.ToString(), characterSelected);
        gameObject.SetActive(false);
        UI_Controller.instance.SetReady(player);
    }
}
