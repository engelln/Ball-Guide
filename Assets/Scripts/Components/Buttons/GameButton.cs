using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public class GameButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    protected Button button;

    protected virtual void Awake()
    {
        button = GetComponent<Button>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        LineManager.Inst.DisableTools();
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        LineManager.Inst.EnableCorrectTool();
    }
}
