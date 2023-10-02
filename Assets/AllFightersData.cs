[System.Serializable]

public struct AllFightersData 
{

    public int MovementStatInfo;

    public string theName;

    public AllFightersData(int MovementStatInfo, string theName)
    {
        this.MovementStatInfo = MovementStatInfo;
        this.theName = theName;
    }

}
