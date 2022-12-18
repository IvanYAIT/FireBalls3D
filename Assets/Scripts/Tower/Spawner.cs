using System.Collections.Generic;
using UnityEngine;

namespace Tower
{
    public class Spawner : Object
    {
        private List<SceneObjectData> towerFloors;
        private List<SceneObjectData> obstacles;
        private Transform spawnpoint;
        private Transform towerFloorParent;
        private int amountOfFloors;

        private int currentAmountOfFloors;
        private int firstFloor;
        private int secondFloor;

        public Spawner(Level.LevelData levelData, Transform spawnpoint, Transform towerFloorParent, Transform obstacleSpanwpoint)
        {
            towerFloors = levelData.towerFloors;
            this.spawnpoint = spawnpoint;
            this.towerFloorParent = towerFloorParent;
            amountOfFloors = PlayerPrefs.GetInt("AmountOfFloors") + levelData.amountOfFloors;
            PlayerPrefs.SetInt("AmountOfFloors", PlayerPrefs.GetInt("AmountOfFloors") + levelData.addingFloorsPerLvl);
            obstacles = levelData.obstacles;
            firstFloor = Random.Range(0, towerFloors.Count);
            secondFloor = Random.Range(0, towerFloors.Count);
            while (secondFloor == firstFloor)
                secondFloor = Random.Range(0, towerFloors.Count);
            Instantiate(obstacles[Random.Range(0, obstacles.Count)].floorPrefab, obstacleSpanwpoint);
        }

        public void Spawn()
        {
            GameObject obj;
            if (currentAmountOfFloors < amountOfFloors)
            {
                if (currentAmountOfFloors % 2 == 0)
                {
                    obj = Instantiate(towerFloors[firstFloor].floorPrefab, spawnpoint.position, spawnpoint.rotation, towerFloorParent);
                    obj.GetComponent<TowerFloor>().Cost = towerFloors[firstFloor].cost;
                }
                else
                {
                    obj = Instantiate(towerFloors[secondFloor].floorPrefab, spawnpoint.position, spawnpoint.rotation, towerFloorParent);
                    obj.GetComponent<TowerFloor>().Cost = towerFloors[secondFloor].cost;
                }
                currentAmountOfFloors++;
                spawnpoint.position += new Vector3(0, 0.5f, 0);
            }
            else
            {
                spawnpoint.position = new Vector3(0, 1, 0.5f);
            }
        }
    }
}

