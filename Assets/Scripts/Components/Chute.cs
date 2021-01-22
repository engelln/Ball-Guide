using UnityEngine;
using System.Collections.Generic;

// used to run each chute during the game
public class Chute : MonoBehaviour
{
    private void Start()
    {
        if(tag == "Finish")
        {
            SetWidth();
        }
    }

    private void SetWidth()
    {
        foreach (Transform child in transform)
        {
            if (child.name == "Wall 1")
                child.transform.localPosition = new Vector3(0, ChuteSpawner.Inst.ChuteWidth, 0);
            else if (child.name == "Wall 2")
                child.transform.localPosition = new Vector3(0, -ChuteSpawner.Inst.ChuteWidth, 0);
            else if (child.name == "Backplate")
                child.transform.localScale = new Vector3(.05f, ChuteSpawner.Inst.ChuteWidth * 2f, 1f);
                
        }
    }

}
