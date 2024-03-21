using UnityEngine;

public class Pipe : MonoBehaviour
{
	[Header("Movement Settings"), Space]
	[SerializeField] private float moveSpeed = 5f;
	[SerializeField] private float edgeOffset = 1f;

	// Private fields.
	private float _leftEdge;

	private void Start()
	{
		_leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - edgeOffset;
		PipeSpawner.activePipes.Add(this);
	}

	private void Update()
	{
		transform.position += Vector3.left * moveSpeed * Time.deltaTime;

		if (transform.position.x < _leftEdge)
		{
			PipeSpawner.activePipes.Remove(this);
			Destroy(gameObject);
		}
	}
}