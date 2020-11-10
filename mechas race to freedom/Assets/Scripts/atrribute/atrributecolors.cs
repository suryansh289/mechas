
using UnityEngine;
[CreateAssetMenu(fileName ="data1",menuName ="data")]
public class atrributecolors : ScriptableObject
{
    public atributandfellowcolors[] attributeandcoloar;
    public Color giveattribute(atrributes at) {
        for (int i = 0; i < attributeandcoloar.Length; i++)
        {
            Color co= attributeandcoloar[i].checkandgive(at);
            if(co!= Color.clear)
            {
                return co;
            }
        }
        return Color.clear;
    }
}
[System.Serializable]
public class atributandfellowcolors {
    public atrributes attribute;
    public Color[] colors;
    public Color checkandgive(atrributes at)
    {
        if (at == attribute)
        {
            return colors[Random.Range(0, colors.Length - 1)];
        }
        else { return Color.clear; };
    }
}
