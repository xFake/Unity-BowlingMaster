using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[TestFixture]
public class ScoreMasterTest {

    private List<int> testFrameList;

    [SetUp]
    public void SetUp(){
        testFrameList = new List<int>();
    }

    [Test]
    public void T00FirstBallReturnsEmptyFrame()
    {
        List<int> testScoreList = new List<int> { 4 };
        Assert.AreEqual(testFrameList, ScoreMaster.ScoreFrames(testScoreList));
    }

    [Test]
    public void T01SecondBallNotSpareReturnsOneFrame()
    {
        testFrameList = new List<int> { 7 };
        List<int> testScoreList = new List<int> { 4, 3 };
        Assert.AreEqual(testFrameList, ScoreMaster.ScoreFrames(testScoreList));
    }

    [Test]
    public void T02SecondBallSpareReturnsEmptyFrame()
    {
        List<int> testScoreList = new List<int> { 4, 6 };
        Assert.AreEqual(testFrameList, ScoreMaster.ScoreFrames(testScoreList));
    }

    [Test]
    public void T03FirstBallStrikeReturnsEmpyFrame()
    {
        List<int> testScoreList = new List<int> { 10 };
        Assert.AreEqual(testFrameList, ScoreMaster.ScoreFrames(testScoreList));
    }

    [Test]
    public void T04SecondBallSpareAndThirdBallReturnsFrame()
    {
        testFrameList = new List<int> { 15 };
        List<int> testScoreList = new List<int> { 4, 6, 5 };
        Assert.AreEqual(testFrameList, ScoreMaster.ScoreFrames(testScoreList));
    }

    [Test]
    public void T05FirstBallStrikeAfterTwoNextBallsReturnsFrame()
    {
        testFrameList = new List<int> { 17, 7 };
        List<int> testScoreList = new List<int> { 10, 3, 4 };
        Assert.AreEqual(testFrameList, ScoreMaster.ScoreFrames(testScoreList));
    }

    [Test]
    public void T06StrikeStrikeStrikeReturnsOneFrame() {
        testFrameList = new List<int> { 30 };
        List<int> testScoreList = new List<int> { 10, 10, 10 };
        Assert.AreEqual(testFrameList, ScoreMaster.ScoreFrames(testScoreList));
    }
    [Test]
    public void T07MiddleBallTest()
    {
        testFrameList = new List<int> { 15, 7, 30 };
        List<int> testScoreList = new List<int> { 7, 3, 5, 2, 10, 10, 10 };
        Assert.AreEqual(testFrameList, ScoreMaster.ScoreFrames(testScoreList));
    }

    [Test]
    public void T08LastBallTest()
    {
        testFrameList = new List<int> { 15, 7, 30, 25, 20, 12, 5, 24, 20, 17 };
        List<int> testScoreList = new List<int> { 7, 3, 5, 2, 10, 10, 10, 5, 5, 2, 3, 10, 10, 4, 6, 7 };
        Assert.AreEqual(testFrameList, ScoreMaster.ScoreFrames(testScoreList));
    }

    [Test]
    public void T09ZeroScoreTest()
    {
        testFrameList = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        List<int> testScoreList = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        Assert.AreEqual(testFrameList, ScoreMaster.ScoreFrames(testScoreList));
    }

    [Test]
    public void T10OnesScoreTest()
    {
        testFrameList = new List<int> { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
        List<int> testScoreList = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        Assert.AreEqual(testFrameList, ScoreMaster.ScoreFrames(testScoreList));
    }

    [Test]
    public void T11CumulativeScoreTest()
    {
        testFrameList = new List<int> { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
        List<int> testScoreList = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        Assert.AreEqual(testFrameList, ScoreMaster.ScoreCumulative(testScoreList));
    }

    [Test]
    public void T12CumulativeScoreTest()
    {
        testFrameList = new List<int> { 15, 22, 52, 77, 97, 109, 114, 138, 158, 175 };
        List<int> testScoreList = new List<int> { 7, 3, 5, 2, 10, 10, 10, 5, 5, 2, 3, 10, 10, 4, 6, 7 };
        Assert.AreEqual(testFrameList, ScoreMaster.ScoreCumulative(testScoreList));
    }

    [Test]
    public void T13CumulativeScoreTest()
    {
        testFrameList = new List<int> { 15, 22, 52, 77, 97, 109, 114, 138, 158, 178 };
        List<int> testScoreList = new List<int> { 7, 3, 5, 2, 10, 10, 10, 5, 5, 2, 3, 10, 10, 4, 6, 10 };
        Assert.AreEqual(testFrameList, ScoreMaster.ScoreCumulative(testScoreList));
    }

    [Test]
    public void T14CumulativeScoreTest()
    {
        testFrameList = new List<int> { 15, 22, 52, 77, 97, 109, 114, 144, 170, 189 };
        List<int> testScoreList = new List<int> { 7, 3, 5, 2, 10, 10, 10, 5, 5, 2, 3, 10, 10, 10, 6, 3 };
        Assert.AreEqual(testFrameList, ScoreMaster.ScoreCumulative(testScoreList));
    }

    [Test]
    public void T15CumulativeScoreTest()
    {
        testFrameList = new List<int> { 15, 22, 52, 77, 97, 109, 114, 144, 174, 204 };
        List<int> testScoreList = new List<int> { 7, 3, 5, 2, 10, 10, 10, 5, 5, 2, 3, 10, 10, 10, 10, 10 };
        Assert.AreEqual(testFrameList, ScoreMaster.ScoreCumulative(testScoreList));
    }
}
