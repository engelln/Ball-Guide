using UnityEngine;

public class LineEraser : Singleton<LineEraser>
{
    [SerializeField] private Vector3 offPosition = new Vector3(500, 0, 0);


    private void Update()
    {
        transform.position = InputManager.WorldPosition;
    }

    private void OnDisable()
    {
        transform.position = offPosition;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PerformErase(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PerformErase(collision.gameObject);
    }

    private void PerformErase(GameObject GO)
    {
        if (GO.tag == "PlayerLine")
        {
            if (InputManager.Touching)
            {
                MaterialManager.Inst.AddMaterial(GO.GetComponent<Line>().Materials / 2);
                Destroy(GO);
            }
        }
    }



}
