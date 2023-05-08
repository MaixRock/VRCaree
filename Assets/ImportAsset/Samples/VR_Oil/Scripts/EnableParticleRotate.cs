using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableParticleRotate : MonoBehaviour
{
    public enum Axis
    {
        x,
        y,
        z
    }
    // The target marker.
    public ParticleSystem particleSystem;

    public float MaxAngle = 1800;
    public float MinAngle = 0;

    public Axis Axis_Rotate;
    public bool InversRotate;

    public bool debug;

    public AudioSource AS;

    public float VolumeStepUp;//+0.05
    public float VolumeStepDown; //-0.1

    private float CurrentAngle;
    private float deltaAngle;
    private int SignedRotate;



    //ParticleSystem
    private float MaxOverTime;
    private float MaxLifeTime;

    private Quaternion Q_old;
    private Quaternion Q_current;

    private ParticleSystem.EmissionModule emission;
    // Start is called before the first frame update
    void Start()
    {
        AS.volume = 0.0f;
        //for ParticleSystem
        particleSystem.Play();

        MaxOverTime = particleSystem.emission.rateOverTime.constant;
        MaxLifeTime = particleSystem.startLifetime;

        emission = particleSystem.emission;
        emission.rateOverTime = 0;

        particleSystem.startLifetime = 0;

        Q_old = transform.rotation;

        if (InversRotate)
        {
            SignedRotate = -1;
        }
        else
        {
            SignedRotate = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Q_current = transform.rotation;

        deltaAngle = Quaternion.Angle(Q_current, Q_old) * SignedRotate;
        if (GetAngle(Quaternion.Inverse(Q_current) * Q_old) < 180)
        {
            deltaAngle *= -1;
        }

        if (deltaAngle == 0)
        {
            AS.volume -= VolumeStepDown;
        }
        else AS.volume += VolumeStepUp;

        CurrentAngle += deltaAngle;

        if (debug)
        {
            Debug.Log(CurrentAngle);
        }

        ParticleSetK(CurrentAngle/MaxAngle);

        Q_old = Q_current;
    }

    private void ParticleSetK(float k)
    {
        k = Mathf.Abs(k);
        particleSystem.startLifetime = k * MaxLifeTime;
        emission.rateOverTime = k * MaxOverTime;
    }

    float GetAngle(Quaternion q)
    {
        switch (Axis_Rotate)
        {
            case Axis.x:
                return q.eulerAngles.x;
                break;
            case Axis.y:
                return q.eulerAngles.y;
                break;
            case Axis.z:
                return q.eulerAngles.z;
                break;
            default:
                return 0;
                break;
        }
    }
}
