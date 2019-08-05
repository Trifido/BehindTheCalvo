using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Character_Texts : MonoBehaviour
{
    public TextMeshProUGUI textMesh;

    public string characterName;

    public string[] characterTexts;

    private void Start()
    {
        StartCoroutine("SaySomethingCoroutine");
    }

    void SaySomething()
    {
        byte rand = (byte)Random.Range(0, characterTexts.Length);

        textMesh.text = characterName +": "+ characterTexts[rand];
        ShowText();
    }

    void ShowText()
    {
        StartCoroutine("ShowTextCoroutine");
    }

    IEnumerator SaySomethingCoroutine()
    {
        while (true)
        {
            float rand = Random.Range(5f, 10f);
            yield return new WaitForSeconds(rand);
            SaySomething();
        }
    }

    IEnumerator ShowTextCoroutine()
    {
        textMesh.enabled = true;
        yield return new WaitForSeconds(3f);
        textMesh.enabled = false;
    }
}
