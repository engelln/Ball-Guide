using UnityEngine;
using UnityEngine.UI;

class ResumeButton : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        ModeManager.Inst.UnPauseGame();
    }

}

