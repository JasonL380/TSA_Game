using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
   public int playerOneScore;
   public int playerTwoScore;
   public int playerThreeScore;
   public int playerFourScore;

    public TMP_Text Score;

    public int MatchPoint;

    public SceneHandler SceneHandler;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = playerOneScore.ToString() + '-' + playerTwoScore.ToString();

        if(playerOneScore == MatchPoint) //finds out who won the game
        {
            SceneHandler.LoseScene(1);
        }
        else if(playerTwoScore == MatchPoint)
        {
            SceneHandler.LoseScene(2);
        }
        else if(playerThreeScore == MatchPoint)
        {
            SceneHandler.LoseScene(3);
        }
        else if(playerFourScore == MatchPoint)
        {
            SceneHandler.LoseScene(4);
        }
    } 
    public void LosePoint(int PlayerIndex) //manage score pls
    {
        /* if(PlayerIndex == 1)
         {
             playerOneScore--;
         }
         else if(PlayerIndex == 2)
         {
             playerTwoScore--;
         }
         else if(PlayerIndex == 3)
         {
             playerThreeScore--;
         }
         else if(PlayerIndex == 4)
         {
             playerFourScore--;
         } */
                if (PlayerIndex == 1)
                {
                   playerTwoScore++;
                }
                else if (PlayerIndex == 2)
                {
                   playerOneScore++;
                }
                /*else if (PlayerIndex == 3)
                {
                    GameManager.playerThreeScore--;
                }
                else if (PlayerIndex == 4)
                {
                    GameManager.playerFourScore--;
                } */
    }
}
