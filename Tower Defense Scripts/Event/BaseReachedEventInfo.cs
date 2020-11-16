
public class BaseReachedEventInfo : EventInfo
{
    public int _heartsToLose;

    public BaseReachedEventInfo(int heartsToLose)
    {
        _heartsToLose = heartsToLose;
    }

    public BaseReachedEventInfo(int heartsToLose, string descritpion)
    {
        _heartsToLose = heartsToLose;
        base.eventDescription = descritpion;
    }
}