using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
	[Header("UI References"), Space]
	[SerializeField] private TextMeshProUGUI scoreText;
	[SerializeField] private GameObject gameOverText;
	[SerializeField] private GameObject playButton;

	[Header("References"), Space]
	[SerializeField] private Player player;
	[SerializeField] private PipeSpawner spawner;

	// Private fields.
	private int _score;

	protected override void Awake()
	{
		base.Awake();
		Pause();
	}

	public void Pause()
	{
		Time.timeScale = 0f;
		player.enabled = false;
	}

	public void StartGame()
	{
		_score = 0;
		scoreText.text = _score.ToString();
		scoreText.gameObject.SetActive(true);

		playButton.SetActive(false);
		gameOverText.SetActive(false);

		Time.timeScale = 1f;
		player.enabled = true;
		player.ResetBehaviour();

		spawner.DestroyAll();
	}

	public void GameOver()
	{
		gameOverText.SetActive(true);
		playButton.SetActive(true);

		Pause();
	}

	public void UpdateScore()
	{
		_score++;
		scoreText.text = _score.ToString();
	}
}