using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestQuest : MonoBehaviour
{
    public int gold;
    public int experience;

    public QuestActive questActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddProgress(int value, GoalType type) {
       // questActive.AddProgress(value, type);
    }
}
