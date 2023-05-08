using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForRotate : MonoBehaviour
{
    public enum Axis
    {
        x,
        y,
        z
    }

    public int Max_Lap;
    public Transform PointStart;
    public Transform PointEnd;

    public Axis Axis_Rotate;
    public bool InversRotate;

    public bool debug;

    private Quaternion Q_old;
    private Quaternion Q_current;

    private float CurrentAngle;
    private float step;
    private float deltaAngle;
    private int SignedRotate;
    // Start is called before the first frame update
    void Start()
    {
        step = (PointStart.position - PointEnd.position).magnitude / (Max_Lap * 360);

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

        deltaAngle = Quaternion.Angle(Q_current, Q_old)* SignedRotate;
        if (GetAngle(Quaternion.Inverse(Q_current) * Q_old) < 180)
        {
            deltaAngle *= -1;
        }

        transform.Translate(Vector3.forward * (deltaAngle * step));

        CurrentAngle += deltaAngle;
        if (debug)
        {
            Debug.Log(CurrentAngle);
        }
        
        Q_old = Q_current;
    }

    float GetAngle(Quaternion q)
    {
        switch (Axis_Rotate)
        {
            case Axis.x: return q.eulerAngles.x;
                break;
            case Axis.y: return q.eulerAngles.y;
                break;
            case Axis.z: return q.eulerAngles.z;
                break;
            default: return 0;
                break;
        }
    }
}
