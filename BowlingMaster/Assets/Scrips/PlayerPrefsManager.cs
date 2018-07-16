using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerPrefsManager : MonoBehaviour {

    const string SCORE_LIST_KEY= "score_list";

    public static void SetScoreList(string value) {
        PlayerPrefs.SetString(SCORE_LIST_KEY, value);
    }

    public static string GetScoreList() {
        return PlayerPrefs.GetString(SCORE_LIST_KEY);
    }
}
