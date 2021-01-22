using UnityEngine;

// used to create new lines
public class LineCreator : Singleton<LineCreator>
{
    [SerializeField] private GameObject lineToSpawn;

    private Line currentLine;


    private void Update()
    {
        if (InputManager.TouchBegan)
        {
            currentLine = Instantiate(lineToSpawn).GetComponent<Line>();
        }

        if (InputManager.TouchEnded)
        {
            currentLine = null;
        }

        if (currentLine != null)
        {
            currentLine.UpdateLine(InputManager.WorldPosition);
        }
    }
}
