using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FS2.Utility;
namespace FS2.Grid
{
    public class GridManager : MonoSingleton<GridManager>
    {
        UIDynamic UIDynamic;

        public GameObject GridPrefab;


        float offsetX = 0.75f;
        float offsetY = 0.4f;
        float offsetUp = -0.7f;

        Dictionary<string, GameObject> GridDictionarys;

        private void OnEnable()
        {
            GridDictionarys = new Dictionary<string, GameObject>();
            CreateGrid(Vector3.zero, 0f);

        }



        /// <summary>
        /// 创造一个战斗网格
        /// </summary>
        /// <param name="targetPos">生成网格的位置</param>
        /// <param name="distance">敌人和玩家的距离</param>
        public void CreateGrid(Vector2 targetPos, float distance)
        {
            //玩家网格父物体
            GameObject PlayerGrid = new GameObject("PlayerGrid");
            PlayerGrid.transform.parent = this.transform;
            PlayerGrid.transform.localPosition = Vector3.zero;

            //玩家网格父物体
            GameObject EnemyGrid = new GameObject("EnemyGrid");
            EnemyGrid.transform.parent = this.transform;
            EnemyGrid.transform.localPosition = new Vector3(offsetUp * 4, 0);

            //创立玩家网格
            CreatePlayerGrid(PlayerGrid.transform);
            //创立敌人网格
        }

        private void CreatePlayerGrid(Transform PlayerGrid)
        {
            Vector2 Origin = Vector2.zero;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; i < 5; j++)
                {
                    GameObject temp = Instantiate<GameObject>(GridPrefab, PlayerGrid);
                    temp.transform.localPosition = Origin;
                    Origin = new Vector2(Origin.x + offsetX * j, Origin.y + offsetY * j);
                    temp.name = i + "_" + j;

                }
                Origin = new Vector2(Origin.x + offsetUp * i, Origin.x);
            }
        }
    }

}