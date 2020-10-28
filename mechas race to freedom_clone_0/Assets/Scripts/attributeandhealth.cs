
using UnityEngine;

public class attributeandhealth : MonoBehaviour
{
    public atrributes myatribute;
    public atrributecolors data;
    public Renderer randd;

    private void Start()
    {
        randd.material.color = data.giveattribute(myatribute);
    }

}
