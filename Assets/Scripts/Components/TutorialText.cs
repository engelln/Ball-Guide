using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialText : MonoBehaviour
{
    public Animator animator;
    public float timeActive = 5f;
    private bool finishedAnimation = false;

    public void Enable()
    {
        gameObject.SetActive(true);
        
    }

    public void Disable()
    {
        animator.Play("FadeOut");
    }

    public IEnumerator Animate()
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(timeActive);
        animator.Play("FadeOut");
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        finishedAnimation = true;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        finishedAnimation = true;
    }

    public bool IsAnimationFinished { get { return finishedAnimation; } }



}
