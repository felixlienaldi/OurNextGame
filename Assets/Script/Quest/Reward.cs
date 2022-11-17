[System.Serializable]
public class Reward
{
    public RewardType rewardType;
    public int value;
}

public enum RewardType {
    Gold,
    Diamond,
    Exp,
}
