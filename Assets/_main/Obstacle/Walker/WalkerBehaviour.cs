Using UnityEngine;

public class WalkerMoving : ObjectBehaviour
{
    [SerializeFied] Vector2 target;
    [SerializeFied] float duration
    Transform self;
    float elapsedTime;
    Vector2 startPos;
    void Awake(){
        self = GetComponent<Transform>();
        startPos = self.position;
    }
    void OnEnable(){
        elapsedTime = 0;
    }
    bool entered;
    void Update(){
        if(entered) return;
        elapsedTime += Time.deltaTime;
        float ratio = Mathf.Clamp01(elapsedTime / duration);
        float easeOutRatio = (1f - ratio)*(1f - ratio);
        self.position = Vector2.Lerp(startPos, target, easeOutRatio);
        if (ratio >= 1){
            entered = true;
        }
    }
}
