using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Vector2 bottomLeft; //static bir deðiþken oluþturuyoruz hýzlýca eriþmek için
    public static bool gameOver;

    private void Awake()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0 ));
    }
    void Start()
    {
        gameOver = false;
    }

    void GameOver()
    {
        gameOver =true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
