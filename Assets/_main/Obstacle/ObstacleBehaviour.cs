using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    [SerializeField] protected Vector2 position;

    Transform self;
    void Awake(){
        self = GetComponent<Transform>();
    }
    protected virtual void OnEnable()
    {
        SetPosition();
    }

    protected virtual void SetPosition()
    {
        self.position = position;
    }
}
