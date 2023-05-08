using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilLVL : MonoBehaviour
{
    public ParticleSystem GasDivice;
    public GameObject TriggerObj;
    public float TimeActive;

    public float TimeWait;
    public AudioSource AS;
    public AudioSource AS1;

    private bool GasEnable;
    // Start is called before the first frame update
    void Start()
    {
        GasDivice.Pause();
        AS1.Stop();
        AS.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (GasEnable)
        {
            if(TimeActive < 0)
            {
                GasDivice.Stop();
                AS.Stop();
            }
            
            if(TimeWait < 0)
            {
                AS1.Play();
                GasEnable = false;
            }

            TimeActive -= Time.deltaTime;
            TimeWait -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == TriggerObj.name)
        {
            GasEnable = true;
            GasDivice.Play();
            AS.Play();
        }
        Debug.LogError(other.name);
    }
}
