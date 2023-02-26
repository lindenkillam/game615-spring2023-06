using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int playerScore = 0;
    public int enemyScore = 0;
    public TMP_Text scoreText;
    public bool lose = false;
    public PlayerController player;
    public EnemyController greenZombie;
    public EnemyController grayZombie;
    public EnemyController ghoul;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
