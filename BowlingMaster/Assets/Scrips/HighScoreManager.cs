using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HighScoreManager : MonoBehaviour {

    public Text[] names;
    public Text[] scores;
    public InputField name;
    public Text score;
    private List<KeyValuePair<string, int>> scoreList = new List<KeyValuePair<string, int>>();

    private void Start()
    {
        Unserialize();
        FillHighScores();
    }

    private void FillHighScores()
    {
        for (int i = 0; i < scoreList.Count; i++)
        {
            names[i].text = scoreList[i].Key;
            scores[i].text = scoreList[i].Value.ToString();
        }
    }

    public void SaveAndExit() {
        Serialize();
    }

    private void Serialize()
    {
        string serialized = "";
        for (int i = 0; i < scoreList.Count; i++)
        {
            serialized +=";" + scoreList[i].Key + ":" + scoreList[i].Value.ToString() ;
        }
        serialized = serialized.TrimStart(';');
        PlayerPrefsManager.SetScoreList(serialized);
    }

    private void Unserialize()
    {
        string unSerialize = PlayerPrefsManager.GetScoreList();
        string[] firstSplit;

        if (unSerialize != null)
        {
            firstSplit = unSerialize.Split(';');

            for (int i = 0; i < firstSplit.Length; i++)
            {
                string[] temp = firstSplit[i].Split(':');
                int value;
                Int32.TryParse(temp[1], out value);
                scoreList.Add(new KeyValuePair<string, int>(temp[0], value));
            }
        }
    }

    public void SortList()
    {
        KeyValuePair<string, int> temp;
        foreach (KeyValuePair<string, int> kvp in scoreList)
        {
            for (int i = 0; i < scoreList.Count - 1; i++)
            {
                if (scoreList[i].Value < scoreList[i + 1].Value)
                {
                    temp = scoreList[i];
                    scoreList[i] = scoreList[i + 1];
                    scoreList[i + 1] = temp;
                }
            }
        }
    }

    public void AddNewHighScore() {
        int newScore;
        Int32.TryParse(score.text, out newScore);
        scoreList.Add(new KeyValuePair<string, int>(name.text, newScore));
    }

    public void ManageListAfterNewScore() {

        SortList();
        if (scoreList.Count == 11)
        {
            scoreList.RemoveAt(10);
        }
        FillHighScores();
    }

    public List<KeyValuePair<string, int>> GetHighScoreList() {
        return scoreList;
    }
}
