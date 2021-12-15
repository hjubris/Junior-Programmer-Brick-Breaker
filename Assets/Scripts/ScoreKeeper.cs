using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreKeeper 
{
    public static int score;
    public static int highScore;
    public static string name;
    public static string highScoreName;

    public static void ChangeHighScore()
    {
        if(score>highScore)
        {
            highScore = score;
            if (name != highScoreName)
            {
                highScoreName = name;
            }
        }
        
    }
}
