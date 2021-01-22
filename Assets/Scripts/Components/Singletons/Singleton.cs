using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T inst;

    public static T Inst { get { return inst; } }

	protected virtual void Awake()
	{
        if (inst == null) { inst = this as T; }
        else if (inst != this as T) { Destroy(gameObject);  }
    }
}
