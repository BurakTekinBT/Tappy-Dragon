using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.UI;

public class Medal : MonoBehaviour
{
    public Sprite metalMedal, bronzeMedal, silverMedal, goldMedal;
    Image img;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();

        int gameScore = GameManager.gameScore;

        if (gameScore >= 0 && gameScore <=3)
        {
            img.sprite = metalMedal;
        }
        else if(gameScore > 3 && gameScore<=5)
        {
            img.sprite = metalMedal;
        }
        else if (gameScore > 5 && gameScore <= 10)
        {
            img.sprite = silverMedal;
        }
        else
        {
            img.sprite = goldMedal;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
