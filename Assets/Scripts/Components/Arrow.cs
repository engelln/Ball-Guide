using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private AnimationCurve curve;

	private void Update()
	{
        transform.localPosition = new Vector3(curve.Evaluate(Time.timeSinceLevelLoad), 0, 0);
	}
}
