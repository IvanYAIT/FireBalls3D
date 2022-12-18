using System.Collections.Generic;
using UnityEngine;

namespace Score
{
    public class ScoreObservable : IObservable
    {
        private List<IObserver> observers;
        public int Score { get; private set; }

        public ScoreObservable()
        {
            observers = new List<IObserver>();
            Tower.TowerFloor.OnTowerFloorDestroy += Notify;
            Obstacle.Obstacle.OnObstacleHit += Notify;
        }

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Notify(int cost)
        {
            Score += cost;
            PlayerPrefs.SetInt("CurrentScore", Score);
            foreach (IObserver observer in observers)
                observer.Update(Score);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }
    }
}