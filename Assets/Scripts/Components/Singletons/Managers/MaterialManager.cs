using UnityEngine;
using UnityEngine.UI;

// used to deal with how much material the player has left
public class MaterialManager : Singleton<MaterialManager>
{
    [SerializeField] private int startingMaterials = 100;
    [SerializeField] private AnimationCurve additionCurve;

    private int materials;

    public int Materials { get { return materials; } }


    private void Start()
    {
        materials = startingMaterials;
    }

    private void Update()
    {
        if(materials <= 0)
        {
            LineCreator.Inst.enabled = false;
        }
        if(materials == 1 && !LineCreator.Inst.enabled)
        {
            materials = 0;
        }
    }

    public void SubtractMaterial()
    {
        materials--;
    }

    public void AddMaterial(int material)
    {
        materials += material;
    }

    public void AddAfterLevelMaterial(float distance, bool doubleIt)
    {
        if (doubleIt) { materials += Mathf.RoundToInt(additionCurve.Evaluate(distance)) * 2; }
        else { materials += Mathf.RoundToInt(additionCurve.Evaluate(distance)); }
    }

    public void ResetMaterials()
    {
        materials = startingMaterials;
    }
}
