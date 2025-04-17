using Unity.Services.Analytics;

public class KeyPressedEvent : Unity.Services.Analytics.Event
{
    public KeyPressedEvent() : base("KeyPressed")
    {
    }

    // Define the parameters for the event
    public int WKey { set { SetParameter("WKey", value); } }
    public int AKey { set { SetParameter("AKey", value); } }
    public int SKey { set { SetParameter("SKey", value); } }
    public int DKey { set { SetParameter("DKey", value); } }
}
