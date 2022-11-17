using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;

    public int requiredAmount;
    public int currentAmount;

    public bool IsReached() => currentAmount >= requiredAmount;
    
    public bool CheckProgress(int value, GoalType questType) {
        if(goalType == questType) {
            currentAmount += value;
        }

        if (IsReached()) {
            return true;
        }

        return false;
    }
}

public enum GoalType {
    Kill,
    Gathering,
}