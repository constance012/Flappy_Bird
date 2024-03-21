using UnityEngine;

public class Player : MonoBehaviour
{
	[Header("References"), Space]
	[SerializeField] private Rigidbody2D rb2D;

    [Header("Physics Settings"), Space]
    [SerializeField] private float gravity = -9.8f;
	[SerializeField] private float flapStrength = 5f;

	[SerializeField] private float maxFallSpeed = -10f;
	[SerializeField] private float maxTiltAngle = 45f;

	// Private fields.
	private Vector2 _movement;

	private void Update()
	{
		if (Input.GetButtonDown("Jump"))
		{
			_movement = Vector2.up * flapStrength;
			rb2D.rotation = maxTiltAngle;
		}
		
		_movement.y = Mathf.Max(_movement.y + gravity * Time.deltaTime, maxFallSpeed);
		rb2D.position += _movement * Time.deltaTime;

		float targetRotation = maxTiltAngle * Mathf.Sign(_movement.y);
		rb2D.rotation = Mathf.Lerp(0f, targetRotation, Mathf.Abs(_movement.y) / Mathf.Abs(maxFallSpeed));
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag("Obstacle"))
		{
			GameManager.Instance.GameOver();
		}
		else if (collider.CompareTag("ScoringArea"))
		{
			GameManager.Instance.UpdateScore();
		}
	}

	public void ResetBehaviour()
	{
		_movement = Vector2.zero;
		transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
	}
}
