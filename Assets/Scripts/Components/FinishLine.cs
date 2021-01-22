using UnityEngine;

public class FinishLine : MonoBehaviour
{
	private void Start()
	{
        //transform.localScale = new Vector3(.05f, ChuteSpawnValueCalculator.Inst.ChuteHalfWidth * 2, 1f);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ball")
        {
            RandomManager.Inst.WinCurrentLevel();
        }
    }

}
