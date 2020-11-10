
using UnityEngine;

public class bullet : MonoBehaviour
{
    public short speeed;
    public Rigidbody rb;

    public atrributes myat;
    public void setattribute(attributeandhealth ath)
    {
        myat = ath.myatribute;
        ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
        settings.startColor = new ParticleSystem.MinMaxGradient(ath.gevecolor());
        TrailRenderer tr = GetComponentInChildren<TrailRenderer>();
        tr.colorGradient.colorKeys[0].color = ath.gevecolor();
        tr.colorGradient.colorKeys[1].color = ath.gevecolor();
    }
    private void Update()
    {
        Vector3 v;
        v = transform.forward * speeed * Time.deltaTime;
        rb.velocity = v;
    }


}
