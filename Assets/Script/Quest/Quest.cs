using UnityEngine;

[System.Serializable]
public class Quest
{
    public bool isActive;
    public bool isCompleted;
    [SerializeField] private QuestData data;
    [SerializeField] private QuestGoal goal;
    public QuestGoal Goal => goal;
    public QuestData Data => data;

    public void Completed() {
        isActive = false;
        isCompleted = true;
    }

    public Reward[] DistributeReward() {
        return data.reward;
    }

    public Reward[] AddProgress(int value, GoalType type) {
        if (goal.CheckProgress(value, type)) {
            Completed();
            return DistributeReward();
        }

        return null;
    }
}
