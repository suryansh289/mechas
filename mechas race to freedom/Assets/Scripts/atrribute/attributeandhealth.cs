
using UnityEngine;

public class attributeandhealth : MonoBehaviour
{
    public atrributes myatribute;
    public atrributecolors data;
    public Renderer randd;

    public void Starta()
    {
        randd.sharedMaterial.color = gevecolor();
    }

    private void Start()
    {
        Starta();
    }

    public Color gevecolor()
    {
        return data.giveattribute(myatribute); 
    }
}
