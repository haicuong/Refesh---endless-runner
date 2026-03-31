using UnityEngine;

public class SetPositionOffset : AutoSetPosition
{
    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;

    protected override void SetPosition()
    {
        transform.position = new Vector2(spawnPosition.x + Random.Range(-1f, 1f) * offsetX, spawnPosition.y + Random.Range(-1f, 1f) * offsetY);
    }
}
