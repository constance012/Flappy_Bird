using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [Header("References"), Space]
    [SerializeField] private new Renderer renderer;

	[Header("Settings"), Space]
	[SerializeField] private float parallaxMultiplier;

    // Private fields.
    private Material _mat;
	private float _current;

	private void Awake()
	{
		_mat = renderer.material;
	}

	private void Update()
	{
		_current = (_current + parallaxMultiplier * Time.deltaTime) % 1f;
		_mat.SetTextureOffset("_MainTex", Vector2.right * _current);
	}
}
