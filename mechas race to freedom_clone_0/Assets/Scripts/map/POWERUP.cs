
using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class POWERUP : MonoBehaviour
{
    public attributeandhealthvfx at;
    public VisualEffect vfx;
    public minmaxnamedata mnmd;
    public int res;
    public GameObject ball;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            attributeandhealth ath= other.GetComponent<attributeandhealth>();
            ath.myatribute = at.myatribute;
            ath.Starta();
            ball.SetActive(false);
            Invoke("unset",5f);
            StartCoroutine("cor");
        }
    }
    void unset()
    {
        ball.SetActive(true);
        for (int i = 0; i < mnmd.mmn.Length; i++)
        {
            vfx.SetFloat(mnmd.mmn[i].name, mnmd.mmn[i].max);
        }
    }
    IEnumerator cor()
    {
        float[] num = new float[mnmd.mmn.Length];
        for (int i = 0; i < mnmd.mmn.Length; i++)
        {
            num[i] = mnmd.mmn[i].max - mnmd.mmn[i].min;
        }
        for (int i = 0; i < res; i++)
        {
            for (int j = 0; j < mnmd.mmn.Length; j++)
            {
                vfx.SetFloat(mnmd.mmn[j].name, mnmd.mmn[j].max - (num[j]*i));
                yield return new WaitForSeconds(1 / res);
            }
        }
    }
}
