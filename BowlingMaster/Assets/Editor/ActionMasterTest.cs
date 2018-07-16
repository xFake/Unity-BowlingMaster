using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;


[TestFixture]
public class ActionMasterTest {

    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster.Action reset = ActionMaster.Action.Reset;
    private ActionMaster.Action endGame = ActionMaster.Action.EndGame;


    [Test]
    public void T00PassingTest() {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01OneStrikeReturnsEndTurn() {
        List<int> pinList = new List<int> { 10 };
        Assert.AreEqual(endTurn, ActionMaster.Bowl(pinList,1));
    }

    [Test]
    public void T02FirstBallOfTurnReturnsTidy()
    {
        List<int> pinList = new List<int> { 8 };
        Assert.AreEqual(tidy, ActionMaster.Bowl(pinList, 1));
    }

    [Test]
    public void T03SecondBallOfTurnRetrunsEndTurn()
    {
        List<int> pinList = new List<int> { 3, 2 };
        Assert.AreEqual(endTurn, ActionMaster.Bowl(pinList, 2));
    }

    [Test]
    public void T04StrikeOn19thBallReturnsReset()
    {
        List<int> pinList = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10 };
        Assert.AreEqual(reset, ActionMaster.Bowl(pinList, 19));
    }

    [Test]
    public void T05SpareOn20thBallReturnsReset()
    {
        List<int> pinList = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 8 };
        Assert.AreEqual(reset, ActionMaster.Bowl(pinList, 20));
    }

    [Test]
    public void T06LessThan10PinsOn19thAnd20thBallReturnsEndGame()
    {
        List<int> pinList = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 4 };
        Assert.AreEqual(endGame, ActionMaster.Bowl(pinList, 20));
    }

    [Test]
    public void T07StrikeOn19thBallAndLessThan10On20thBallReturnsTidy()
    {
        List<int> pinList = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 4 };
        Assert.AreEqual(tidy, ActionMaster.Bowl(pinList, 20));
    }

    [Test]
    public void T08StrikeOn19thBallAndStrikeOn20thBallReturnsReset()
    {
        List<int> pinList = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 10 };
        Assert.AreEqual(reset, ActionMaster.Bowl(pinList, 20));
    }

    [Test]
    public void T09LastBallOfTheGameReturnsEndGame()
    {
        List<int> pinList = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 10, 5 };
        Assert.AreEqual(endGame, ActionMaster.Bowl(pinList, 21));
    }

    [Test]
    public void T10FirstBall0PinsAndSecondBallStrike()
    {
        List<int> pinList = new List<int> { 0, 10, 5 };
        Assert.AreEqual(tidy, ActionMaster.Bowl(pinList, 3));
    }
}
