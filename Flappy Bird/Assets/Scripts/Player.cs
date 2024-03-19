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
	private Vector2 _direction;

	private void Update()
	{
		if (Input.GetButtonDown("Jump"))
		{
			_direction = Vector2.up * flapStrength;
			rb2D.rotation = maxTiltAngle;
		}
		
		_direction.y = Mathf.Max(_direction.y + gravity * Time.deltaTime, maxFallSpeed);
		rb2D.position += _direction * Time.deltaTime;

		float targetRotation = maxTiltAngle * Mathf.Sign(_direction.y);
		rb2D.rotation = Mathf.Lerp(0f, targetRotation, Mathf.Abs(_direction.y) / Mathf.Abs(maxFallSpeed));
	}
}
