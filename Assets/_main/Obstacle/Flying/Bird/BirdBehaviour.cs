using UnityEngine;

public class BirdBehaviour : ObstacleBehaviour
{
    [SerializeField] private float offsetY;

    protected override void SetPosition()
    {
        transform.position = new Vector2(spawnPosition.x, spawnPosition.y + Random.Range(-1f, 1f) * offsetY);
    }
}
