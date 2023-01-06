using UnityEngine;

public class GameObjectAutoAdd : MonoBehaviour
{
    private void Awake()
    {
        GameObjectManager.instance.allObject.Add(gameObject);
    }
    private void OnDestroy()
    {
        GameObjectManager.instance.allObject.Remove(gameObject);
    }
}
