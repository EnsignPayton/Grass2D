using Assets.Scripts.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ScoreManager : MonoBehaviour
    {
        private int _score;
        private int _health = 100;
        private Yard _yard;
        private AudioSource _audioSource;

        public Text ScoreText;
        public string ScoreFormat;
        public Text HealthText;
        public string HealthFormat;
        public Button RestartButton;
        public GameObject[] ObjectsToKill;
        public GameObject[] ObjectsToResurrect;
        public AudioClip GameOverClip;

        public int Score
        {
            get { return _score; }
            set
            {
                _score = value;
                UpdateScore();
            }
        }

        public int Health
        {
            get { return _health; }
            set
            {
                _health = value < 0 ? 0 : value;
                UpdateHealth();
                if (_health == 0) GameOver();
            }
        }

        public void Start()
        {
            RestartButton.onClick.AddListener(() => SceneManager.LoadScene("Main"));
            UpdateScore();
            UpdateHealth();
            _yard = FindObjectOfType<Yard>();
            _audioSource = FindObjectOfType<AudioSource>();
        }

        private void UpdateScore()
        {
            ScoreText.text = string.Format(ScoreFormat, _score);
        }

        private void UpdateHealth()
        {
            HealthText.text = string.Format(HealthFormat, _health);
        }

        private void GameOver()
        {
            ObjectsToKill.ForEach(x => x.SetActive(false));
            ObjectsToResurrect.ForEach(x => x.SetActive(true));

            _yard.IsActive = false;
            _audioSource.PlayOneShot(GameOverClip);
        }
    }
}
