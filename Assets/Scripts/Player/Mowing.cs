using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts.Player
{
    public class Mowing : PlayerBase
    {
        public TileBase GrassTile;
        public TileBase CoinTile;
        public TileBase[] ObstacleTiles;
        public AudioClip MowClip;
        public AudioClip CoinClip;
        public AudioClip RockClip;

        public void FixedUpdate()
        {
            Mow();
        }

        private void Mow()
        {
            if (!Input.GetButton("Jump")) return;

            var cell = GetCurrentCell();
            var tile = Tilemap.GetTile(cell);
            if (tile == GrassTile)
            {
                Tilemap.SetTile(cell, null);
                AudioSource.PlayOneShot(MowClip);
                ScoreManager.Score++;
            }
            else if (tile == CoinTile)
            {
                Tilemap.SetTile(cell, null);
                AudioSource.PlayOneShot(CoinClip);
                ScoreManager.Score += 10;
            }
            else if (ObstacleTiles.Contains(tile))
            {
                Tilemap.SetTile(cell, null);
                AudioSource.PlayOneShot(RockClip);
                ScoreManager.Health -= 10;
            }
        }
    }
}
