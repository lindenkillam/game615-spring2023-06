using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public GameManager gm; //ui must see the player controller to display the score
    public TextMeshProUGUI playerScoreDisplay;
    public TextMeshProUGUI enemyScoreDisplay;
    public TextMeshProUGUI winDisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.win) //Win condition overrides lose conditions
            winDisplay.text = "You win!";
        else if(gm.lose)
        {
            winDisplay.text = "You lose...";
            gm.moveSpeed = 0f;
        }

        playerScoreDisplay.text = "Player score: " + gm.playerScore;
        enemyScoreDisplay.text = "Enemy score: " + gm.enemyScore;
    }
}
