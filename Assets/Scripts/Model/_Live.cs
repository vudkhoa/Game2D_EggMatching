public class _Live
{
    private int live;
    private _LiveView liveView;

    public void InitLive(int live, _LiveView liveView)
    {
        this.live = live;
        this.liveView = liveView;
        liveView.SetText(live); 
    }

    public void DecreaseLive()
    {
        this.live--;
        liveView.SetText(live);
    }

    public int Getlive()
    {
        return this.live;
    }
}
