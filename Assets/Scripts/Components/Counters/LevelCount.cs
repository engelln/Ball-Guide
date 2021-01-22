using UnityEngine;
using UnityEngine.UI;

public class LevelCount : MonoBehaviour
{
    private Text levelText;

    private void Start()
    {
        levelText = GetComponent<Text>();
    }

    private void Update()
    {
        levelText.text = ScoreManager.Inst.Score.ToString();
    }
}
