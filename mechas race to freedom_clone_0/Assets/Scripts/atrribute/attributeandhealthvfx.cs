
using UnityEngine;
using UnityEngine.VFX;

public class attributeandhealthvfx : MonoBehaviour
{
    public atrributes myatribute;
    public atrributecolors data;
    public Renderer rand;
    public VisualEffect vfx;
    public float intensity;

    public void Starta()
    {
        rand.sharedMaterial.color = data.giveattribute(myatribute);
        Color c = data.giveattribute(myatribute);
        vfx.SetVector4("color",new Vector4(c.r,c.g,c.b,1)*intensity);
    }
    public void Startb()
    {
        rand.material.color = data.giveattribute(myatribute);
        Color c = data.giveattribute(myatribute);
        vfx.SetVector4("color", new Vector4(c.r, c.g, c.b, 1) * intensity);
    }

    private void Start()
    {
        Startb();
    }

}
