using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour
{
    // The target marker.
    public ParticleSystem particleSystem;

    public bool Trigger;
    // Angular speed in radians per sec.
    public float speed = 1.0f;

    public float MaxAngle = 90;
    public float MinAngle = 0;

    public int TriggerCount;
    public float CurrentAngle;

    //ParticleSystem
    float MaxOverTime;
    float MaxLifeTime;

    ParticleSystem.EmissionModule emission;
    // Start is called before the first frame update
    void Start()
    {
        //for Rotate
        Trigger = false;
        TriggerCount = 0;
        CurrentAngle = transform.eulerAngles.z;
        
        //for ParticleSystem
        particleSystem.Play();

        MaxOverTime = particleSystem.emission.rateOverTime.constant;
        MaxLifeTime = particleSystem.startLifetime;

        emission = particleSystem.emission;
        emission.rateOverTime = 0;

        particleSystem.startLifetime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Trigger)
        {
            if (TriggerCount % 2 == 0)
            {
                OpenRotateZ();
            }
            else
            {
                CloseRotateZ();
            }
        }

    }

    void OpenRotateZ()
    {
        CurrentAngle = transform.eulerAngles.z;
        Debug.Log(transform.eulerAngles.z);

        if(CurrentAngle <= MaxAngle)
        {   
            //Поворот крана
            float singleStep = speed * Time.deltaTime;
            transform.Rotate(0, 0, singleStep);

            //Система частиц
            float k = CurrentAngle / MaxAngle;
            ParticleSetK(k);
        }
        Debug.Log(CurrentAngle);
    }
    void CloseRotateZ()
    {
        CurrentAngle = transform.eulerAngles.z;
        Debug.Log(transform.eulerAngles.z);

        if ( CurrentAngle >= MinAngle)
        {
            //Поворот крана
            float singleStep = -speed * Time.deltaTime;
            transform.Rotate(0, 0, singleStep);
            
            //Система частиц
            float k = CurrentAngle / MaxAngle;
            ParticleSetK(k);
        }
    }
    private void ParticleSetK(float k)
    {
        particleSystem.startLifetime = k * MaxLifeTime;
        emission.rateOverTime = k * MaxOverTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "RotateObj")
        {
            Trigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "RotateObj")
        {
            Trigger = false;
            TriggerCount++;
        }
    }
    
}
