using UnityEngine;

public class TransformSineMover : MonoBehaviour
{
    [SerializeField] private float amplitude = 1f;
    [SerializeField] private float frequency = 1f;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        transform.position = startPosition + new Vector3(0, Mathf.Sin(Time.time * frequency) * amplitude, 0);
    }
}