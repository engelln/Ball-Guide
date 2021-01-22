using UnityEngine;
using UnityEngine.UI;

public class MaterialCount : MonoBehaviour
{
    private Text materialText;

    private void Start()
    {
        materialText = GetComponent<Text>();
    }

    private void Update()
    {
        materialText.text = MaterialManager.Inst.Materials.ToString();
    }
}
