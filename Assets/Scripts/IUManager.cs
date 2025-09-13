using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IUManager : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public Image heart;


    public void Setscore(int score)
    {
        pointsText.text = "Score: " + score.ToString();

    }
    public void SetNewLife(int vidas)
       { 
        float percentage = vidas / 5f; // Assuming max lives is 5
        heart.fillAmount = percentage;
       }
}
