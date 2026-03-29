using UnityEngine;

public class BirdBehaviour : ObstacleBehaviour
{
    [SerializeField] private float offsetY;

    protected override void SetPosition()
    {
        transform.position = new Vector2(position.x, position.y + Random.Range(-1f, 1f) * offsetY);
    }
}
