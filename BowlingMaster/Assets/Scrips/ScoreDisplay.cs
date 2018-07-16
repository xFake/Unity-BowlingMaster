using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    public Text[] scoreArray;
    public Text[] bowlArray;

    public void FillRolls(List<int> rolls) {

        int index = 0;
        int bowl = 0;
        foreach (int roll in rolls)
        {
            if (roll == 0)
            {
                bowlArray[index].text = "-";
            }
            else
            if (index >= 18 && roll == 10)
            {
                bowlArray[index].text = "X";
            }
            else
            if (index % 2 == 0 && roll == 10)
            {
                bowlArray[index + 1].text = "X";
                index++;
            }
            else
            if ((index % 2 != 0 || index == 20) && roll + rolls[bowl - 1] == 10)
            {
                bowlArray[index].text = "/";
            }
            else
            {
                bowlArray[index].text = roll.ToString();
            }
            index++;
            bowl++;
        }
    }
    public void FillScores(List<int> scores){
        for (int i = 0; i < scores.Count; i++) {
            scoreArray[i].text = scores[i].ToString();
        }
    }
}
