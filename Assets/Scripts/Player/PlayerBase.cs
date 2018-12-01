using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts.Player
{
    public class PlayerBase : MonoBehaviour
    {
        protected ScoreManager ScoreManager { get; private set; }
        protected AudioSource AudioSource { get; private set; }

        public Tilemap Tilemap;

        public virtual void Start()
        {
            ScoreManager = FindObjectOfType<ScoreManager>();
            AudioSource = FindObjectOfType<AudioSource>();
        }

        protected Vector3Int GetCurrentCell() => Tilemap.WorldToCell(transform.position);
    }
}
