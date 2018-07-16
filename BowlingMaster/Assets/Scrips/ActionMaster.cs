using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ActionMaster{

    public enum Action {Tidy, Reset, EndTurn, EndGame};

    public static Action Bowl(List<int> pinFalls, int bowl)
    {
        if (pinFalls[pinFalls.Count-1] > 10 || pinFalls[pinFalls.Count - 1] < 0) { throw new UnityException("Invalid pin count"); }

        if (bowl == 21)
        {
            return Action.EndGame;
        }

        if (bowl == 20 && pinFalls[pinFalls.Count - 2] == 10 && pinFalls[pinFalls.Count - 1] < 10)
        {
            return Action.Tidy;
        }
        if (bowl == 20 && pinFalls[pinFalls.Count - 2] + pinFalls[pinFalls.Count - 1] >= 10)
        {
            return Action.Reset;
        }

        if (bowl == 20 && pinFalls[pinFalls.Count - 2] + pinFalls[pinFalls.Count - 1] < 10)
        {
            return Action.EndGame;
        }

        if (bowl == 19 && pinFalls[pinFalls.Count - 1] == 10)
        {
            return Action.Reset;
        }

        if (bowl % 2 != 0)
        {
            if (pinFalls[pinFalls.Count-1] == 10)
            {
                return Action.EndTurn;
            }
            else
            {
                return Action.Tidy;
            }
        }
        else if (bowl % 2 == 0)
        {
            return Action.EndTurn;
        }

        throw new UnityException("Not sure what action to return");
    }
}
