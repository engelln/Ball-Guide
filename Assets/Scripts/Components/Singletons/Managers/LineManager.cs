using UnityEngine;
using System.Collections.Generic;

// deals with created lines and the tools used to create them
public class LineManager : Singleton<LineManager>
{
    private List<Line> activeLines;
    private DrawMode currentMode;

    // the current active drawing tool
    public DrawMode CurrentMode { get { return currentMode; } }

    private void Start()
    {
        activeLines = new List<Line>();
        currentMode = DrawMode.Place;
    }

    // add a line to the list of active lines
    public void RegisterActiveLine(Line line)
    {
        activeLines.Add(line);
    }

    // destroy all lines
    public void ClearLines()
    {
        foreach(Line line in activeLines)
        {
            if(line != null)
                Destroy(line.gameObject);
        }
        activeLines.Clear();
    }

    // changes the selected drawing tool
    public void SwitchDrawMode()
    {
        if (currentMode == DrawMode.Place)
        {
            currentMode = DrawMode.Erase;
        }
        else if (currentMode == DrawMode.Erase)
        {
            currentMode = DrawMode.Place;
        }
    }

    public void DisableTools()
    {
        LineCreator.Inst.enabled = false;
        if(GameManager.Inst.CurrentMode != GameMode.Menu)
            LineEraser.Inst.enabled = false;
    }

    public void EnableCorrectTool()
    {
        switch (CurrentMode)
        {
            case DrawMode.Place: LineCreator.Inst.enabled = true; break;
            case DrawMode.Erase: LineEraser.Inst.enabled = true; break;
        }
    }

}
