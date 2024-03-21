using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
	[Header("References"), Space]
	[SerializeField] private GameObject prefab;

	[Header("Spawn Settings"), Space]
	[SerializeField] private float spawnInterval = 1f;
	[SerializeField] private Vector2 heightRange;

	public static List<Pipe> activePipes = new List<Pipe>();

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void CleanStatic()
	{
		activePipes.Clear();
	}

	private void OnEnable()
	{
		InvokeRepeating(nameof(Spawn), spawnInterval, spawnInterval);
	}

	private void OnDisable()
	{
		CancelInvoke(nameof(Spawn));
	}

	public void DestroyAll()
	{
		foreach (Pipe pipe in activePipes)
		{
			Destroy(pipe.gameObject);
		}

		activePipes.Clear();
	}

	private void Spawn()
	{
		Vector3 spawnPos = transform.position + Vector3.up * Random.Range(heightRange.x, heightRange.y);
		Instantiate(prefab, spawnPos, Quaternion.identity);
	}
}