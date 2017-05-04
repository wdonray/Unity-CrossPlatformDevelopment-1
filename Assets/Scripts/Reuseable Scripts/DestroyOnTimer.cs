using UnityEngine;
using UnityEngine.Events;

public class DestroyOnTimer : MonoBehaviour
{
    public float Time = 1.0f;
    private void OnEnable()
    {
        if(onDestroyed == null) onDestroyed = new OnDestroyed();
    }
    void Update()
    {
        if(Time < 0)
            Destroy(gameObject);
        Time -= UnityEngine.Time.deltaTime;
    }

    public class OnDestroyed : UnityEvent<GameObject> { }
    public OnDestroyed onDestroyed = new OnDestroyed();
    private void OnDestroy()
    {
        if(onDestroyed != null)
            onDestroyed.Invoke(gameObject);
    }
}