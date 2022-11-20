using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestActive : MonoBehaviour
{
    public List<Quest> quests;
    public List<Reward> rewards = new List<Reward>();
    public Reward[] AddProgress(int value, GoalType type) {
        rewards.Clear();

        foreach (Quest quest in quests) {
            Reward[] reward = quest.AddProgress(value, type);
            if (reward != null) {
                for(int i = 0; i < reward.Length; i++) {
                    rewards.Add(reward[i]);
                }
            }
        }

        return rewards.ToArray();
    }
}
