using System.Collections;
using System.Linq;
using Assets.Scripts.Extensions;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class Yard : MonoBehaviour
    {
        public Tilemap Tilemap;
        public TileBase GrassTile;
        public TileBase CoinTile;
        public TileBase[] ObstacleTiles;
        public Vector3Int GrassAreaMax;
        public Vector3Int GrassAreaMin;
        public float WaitSeconds;
        public float ObstacleChance;
        public float CoinChance;
        public bool GrassReplacesObstacles;

        public bool IsActive { get; set; }

        private Vector3Int GrassArea => GrassAreaMax - GrassAreaMin;

        public void Start()
        {
            IsActive = true;
            StartCoroutine(SpawnCoroutine());
        }

        private IEnumerator SpawnCoroutine()
        {
            while (true)
            {
                if (IsActive)
                {
                    var randX = GrassAreaMin.x + (int) (Random.value * GrassArea.x);
                    var randY = GrassAreaMin.y + (int) (Random.value * GrassArea.y);

                    var cell = Tilemap.origin.Move(randX, randY);
                    var tile = Tilemap.GetTile(cell);
                    if (tile == null || GrassReplacesObstacles && ObstacleTiles.Contains(tile))
                    {
                        var rand = Random.value;
                        var newTile = rand < ObstacleChance
                            ? ObstacleTiles.GetRandom()
                            : rand < ObstacleChance + CoinChance
                                ? CoinTile
                                : GrassTile;
                        Tilemap.SetTile(cell, newTile);
                    }
                }

                yield return new WaitForSeconds(WaitSeconds);
            }
        }
    }
}
