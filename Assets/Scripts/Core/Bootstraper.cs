using System.Collections.Generic;
using UnityEngine;
using Score;
using State;
using TMPro;
using Tower;
using Bullet;
using Level;
using Player;

namespace Core
{
    public class Bootstraper : MonoBehaviour
    {
        [SerializeField] private Cannon cannon;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI recordScoreText;
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private List<SceneObjectData> towerFloors;
        [SerializeField] private Transform spawnpoint;
        [SerializeField] private Transform obstacleSpanwpoint;
        [SerializeField] private int amountOfFloors;
        [SerializeField] private BulletModel bulletModel;
        [SerializeField] private LevelData levelData;
        [SerializeField] private Transform towerFloorParent;
        [SerializeField] private Menus menus;

        private BulletController bulletController;
        private BulletView bulletView;
        private Spawner spawner;
        private Game game;
        private ScoreView scoreView;
        private ScoreObservable scoreObservable;
        private StateMachine stateMachine;
        private LevelView levelView;
        private LevelEndChecker levelEndChecker;
        private RecordChecker recordChecker;

        void Start()
        {
            bulletController = new BulletController();
            bulletView = new BulletView(bulletModel, bulletController);
            stateMachine = new StateMachine(menus, bulletView);
            game = new Game();
            recordChecker = new RecordChecker();
            levelEndChecker = new LevelEndChecker(towerFloorParent);
            cannon.Construct(bulletPrefab, bulletModel.BulletAmount);
            spawner = new Spawner(levelData, spawnpoint, towerFloorParent, obstacleSpanwpoint);
            scoreObservable = new ScoreObservable();
            scoreView = new ScoreView(scoreText, scoreObservable);
            levelView = new LevelView(levelText);
            game.StartGame();
        }

        void Update()
        {
            stateMachine.Update();
            spawner.Spawn();
            game.LoseCheck(scoreObservable.Score);
            levelEndChecker.Check();
            levelView.View();
            recordChecker.Check();
        }
    }
}