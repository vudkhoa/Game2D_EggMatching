public class _Score
{
    private int score;
    private _ScoreView scoreView;

    public void InitScore(int score, _ScoreView scoreView)
    {
        this.score = score;
        this.scoreView = scoreView;
        this.scoreView.InitScoreView(this.score);
    }   

    public void AddScore(int score)
    {
        this.score += score;
        this.scoreView.SetScoreView(this.score);
    }

    public int GetScore()
    {
        return score;
    }
}
