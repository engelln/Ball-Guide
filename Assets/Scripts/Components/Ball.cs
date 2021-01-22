using System.Linq;
using UnityEngine;

// used to run the ball during the game
public class Ball : MonoBehaviour
{
    private GameObject start;
    private Rigidbody2D rb;
    private bool activated = false;


    public void Activate()
    {
        if (!activated)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.AddForce(transform.up * 5, ForceMode2D.Impulse);
            //GameObject.FindGameObjectWithTag("Guide").SetActive(false);
            activated = true;
        }
    }

    public void SetUpBall()
    {
        start = ChuteSpawner.Inst.StartChute;
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
        DetermineRotation();
    }

    public void SetUpTutorialBall()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void DetermineRotation()
    {
        transform.position = start.transform.position;
        Vector3 rotation = start.transform.rotation.eulerAngles;
        rotation.z += 90;
        transform.rotation = Quaternion.Euler(rotation);
    }

    private void OnBecameInvisible()
    {
        Invoke("Disable", 0.5f);
    }

    private void Disable()
    {
        rb.bodyType = RigidbodyType2D.Static;
        activated = false;
        ModeManager.Inst.EndLevel();
    }


}
