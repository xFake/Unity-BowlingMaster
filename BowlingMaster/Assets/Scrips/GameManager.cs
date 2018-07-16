using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{

    public Text pinText;
    public GameObject highScoresPanel;
    public GameObject newHighScorePanel;
    public Canvas menuCanvas;

    private int i = 1;
    private bool ballLeftBox = false;
    private float lastChangeTime;
    private int lastStandingCount = -1;
    private int bowlNumber = 1;
    private int lastSettledCount = 10;
    private List<int> fallenPinList = new List<int>();
    private Ball ball;
    private PinCounter pinCounter;
    private PinSetter pinSetter;
    private ScoreDisplay scoreDisplay;
    private HighScoreManager highScoreManager;
    

    void Start()
    {
        ball = FindObjectOfType<Ball>();
        pinCounter = FindObjectOfType<PinCounter>();
        pinSetter = FindObjectOfType<PinSetter>();
        scoreDisplay = FindObjectOfType<ScoreDisplay>();
        highScoreManager = FindObjectOfType<HighScoreManager>();
    }

    private void Update()
    {
        pinText.text = pinCounter.CountStanding().ToString();
        if (ballLeftBox)
        {
            pinText.color = Color.red;
            CheckStanding();
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            menuCanvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void CheckStanding()
    {
        int currentStanding = pinCounter.CountStanding();
        if (lastStandingCount != currentStanding)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        float settleTime = 3f;
        if ((Time.time - lastChangeTime) > settleTime)
        {
            PinsHaveSettled();
        }
    }

    void PinsHaveSettled()
    {
        ball.Reset();
        ballLeftBox = false;

        int pinCountFallen = lastSettledCount - lastStandingCount;
        lastSettledCount = lastStandingCount;
        fallenPinList.Add(pinCountFallen);
        print(bowlNumber + " bwol number before CallAction()");
        CallAction(ActionMaster.Bowl(fallenPinList, bowlNumber));
        try
        {
            scoreDisplay.FillRolls(fallenPinList);
        }
        catch
        {
            Debug.Log("Something went wrong in scoreDisplay.FillRollCard()");
        }
        try
        {
            scoreDisplay.FillScores(ScoreMaster.ScoreCumulative(fallenPinList));
        }
        catch
        {
            Debug.Log("Something went wrong in scoreDisplay.FillScores(ScoreMaster.ScoreCumulative(fallenPinList))");
        }


        pinText.color = Color.green;
        lastStandingCount = -1;
    }

    public void SetBallLeftBox(bool value)
    {
        ballLeftBox = value;
    }

    public void CallAction(ActionMaster.Action action)
    {
        switch (action)
        {
            case ActionMaster.Action.Tidy:
                pinSetter.CallTidy();
                BowlCount();
                pinText.color = Color.black;
                return;
            case ActionMaster.Action.EndTurn:
                pinSetter.CallReset();
                pinText.color = Color.black;
                lastSettledCount = 10;
                BowlCount();
                return;
            case ActionMaster.Action.Reset:
                pinSetter.CallReset();
                pinText.color = Color.black;
                lastSettledCount = 10;
                BowlCount();
                return;
            case ActionMaster.Action.EndGame:

                if (highScoreManager.GetHighScoreList().Count < 10 || highScoreManager.GetHighScoreList()[9].Value < ScoreMaster.ScoreCumulative(fallenPinList)[9])
                {
                    newHighScorePanel.SetActive(true);
                }
                else {
                    highScoresPanel.SetActive(true);
                }
                Debug.Log("Game over!");
                return;
        }
    }

    public void BowlCount()
    {
        if (bowlNumber % 2 != 0 && fallenPinList[fallenPinList.Count - 1] == 10 && bowlNumber <18){
            bowlNumber += 2;
        }
        else{
            bowlNumber++;
        }
        print(bowlNumber + " bowl number after count");
    }

    public void UnPauseGame() {
        Time.timeScale = 1;
    }

}
