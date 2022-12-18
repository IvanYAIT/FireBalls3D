using TMPro;

namespace Score
{
    public class ScoreView : IObserver
    {
        private TextMeshProUGUI scoreText;
        private IObservable observable;

        public ScoreView(TextMeshProUGUI scoreText, IObservable observable)
        {
            this.scoreText = scoreText;
            this.observable = observable;
            observable.AddObserver(this);
        }

        public void Update(int score)
        {
            scoreText.text = $"Score: {score}";
        }
    }
}