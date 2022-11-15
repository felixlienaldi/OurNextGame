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
    
    public void AddProgress(int value, GoalType questType) {
        if(goalType == questType) {
            currentAmount += requiredAmount;
        }


    }

    public void Finished() { 
    }
}

public enum GoalType {

}