using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TutorialManager : ModeManager
{
    public TutorialText[] texts;

    public Ball ball;
    public GameObject start;
    public GameObject finish;
    public GameObject gameMenu;
    public GameObject gameOverMenu;
    public Button startButton;

    private GameObject currentText;
    private bool levelOver;


	private void Start()
	{
        GameManager.Inst.CurrentMode = GameMode.Tutorial;
        LineManager.Inst.DisableTools();
        StartCoroutine(TutorialAnimation());
	}
	
	private void Update()
	{
        if (InputManager.TouchBegan)
        {
            currentText.SetActive(false);
        }
	}

    public override void StartLevel()
    {
        ball.SetUpTutorialBall();
        ball.Activate();
        foreach (GameObject guide in GameObject.FindGameObjectsWithTag("Guide"))
        {
            guide.SetActive(false);
        }
    }

    public override void EndLevel()
    {
        LineManager.Inst.DisableTools();
        gameMenu.SetActive(false);
        gameOverMenu.SetActive(true);
        levelOver = true;
    }

    private IEnumerator TutorialAnimation2()
    {
       foreach(TutorialText text in texts)
        {
            StartCoroutine(text.Animate());
            currentText = text.gameObject;
            yield return new WaitUntil(() => text.IsAnimationFinished);
        }
    }

    private IEnumerator TutorialAnimation()
    {
        // welcome to ball guide
        StartCoroutine(texts[0].Animate());
        currentText = texts[0].gameObject;
        yield return new WaitUntil(() => texts[0].IsAnimationFinished);

        // in this game, ...
        StartCoroutine(texts[1].Animate());
        currentText = texts[1].gameObject;
        yield return new WaitUntil(() => texts[1].IsAnimationFinished);

        // this is the start
        start.SetActive(true);
        StartCoroutine(texts[2].Animate());
        currentText = texts[2].gameObject;
        yield return new WaitUntil(() => texts[2].IsAnimationFinished);

        // this is the finish
        finish.SetActive(true);
        StartCoroutine(texts[3].Animate());
        currentText = texts[3].gameObject;
        yield return new WaitUntil(() => texts[3].IsAnimationFinished);

        // to create a line
        StartCoroutine(texts[4].Animate());
        currentText = texts[4].gameObject;
        LineManager.Inst.EnableCorrectTool();
        yield return new WaitUntil(() => MaterialManager.Inst.Materials < 95);
        yield return new WaitForSeconds(1f);
        LineManager.Inst.DisableTools();
        LineManager.Inst.ClearLines();
        yield return new WaitForSeconds(.5f);

        // Materials
        StartCoroutine(texts[5].Animate());
        currentText = texts[5].gameObject;
        yield return new WaitUntil(() => texts[5].IsAnimationFinished);

        // Mode
        StartCoroutine(texts[6].Animate());
        currentText = texts[6].gameObject;
        yield return new WaitUntil(() => texts[6].IsAnimationFinished);

        // Start
        StartCoroutine(texts[7].Animate());
        currentText = texts[7].gameObject;
        startButton.enabled = true;
        yield return new WaitUntil(() => levelOver);

        // game over
        start.SetActive(false);
        finish.SetActive(false);
        StartCoroutine(texts[8].Animate());
        currentText = texts[8].gameObject;
        yield return new WaitUntil(() => texts[8].IsAnimationFinished);

        // scores
        StartCoroutine(texts[9].Animate());
        currentText = texts[9].gameObject;
        yield return new WaitUntil(() => texts[9].IsAnimationFinished);

        // tutorial finished
        yield return new WaitForSeconds(1f);
        gameOverMenu.SetActive(false);
        StartCoroutine(texts[10].Animate());
        currentText = texts[10].gameObject;
        yield return new WaitUntil(() => texts[10].IsAnimationFinished);
        SceneManager.LoadScene(0);
    }


}
