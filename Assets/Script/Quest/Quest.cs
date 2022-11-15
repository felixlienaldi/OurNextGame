[System.Serializable]
public class Quest
{
    public bool isActive;
    public bool isCompleted;
    public string title;
    public string description;
    public int goldReward;

    public void Completed() {
        isActive = false;
        isCompleted = true;
    }



}
