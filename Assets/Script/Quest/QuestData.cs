using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Quest", menuName = "Quest/New Quest")]
public class QuestData : ScriptableObject {
    public string title;
    public string description;
    public Reward[] reward;
}
