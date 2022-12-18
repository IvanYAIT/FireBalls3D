using UnityEngine;

namespace Score
{
    public class RecordChecker
    {
        private int currentScore;
        private int currentRecord;

        public void Check()
        {
            currentScore = PlayerPrefs.GetInt("Score");
            currentRecord = PlayerPrefs.GetInt("Record", 0);
            if (currentScore > currentRecord)
            {
                currentRecord = currentScore;
                PlayerPrefs.SetInt("Record", currentRecord);
            }
        }
    }
}