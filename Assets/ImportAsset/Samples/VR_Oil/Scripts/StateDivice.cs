using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateDivice : MonoBehaviour
{
    public Transform OpenPosition;
    public Transform ClosePosition;

    public float MaxErrorDistance;

    public bool OPEN;
    public bool CLOSE;

    private float DistanceOpenPoint;
    private float DistanceClosePoint;
    private float DistanceError;
    private float Length;

    void Start()
    {
        Length = (OpenPosition.position - ClosePosition.position).magnitude;
        DistanceError = MaxErrorDistance * Length;

        OPEN = true;
        CLOSE = false;
    }

    // Update is called once per frame
    void Update()
    {
        DistanceOpenPoint = (OpenPosition.position - transform.position).magnitude;
        DistanceClosePoint = (ClosePosition.position - transform.position).magnitude;

        if (DistanceOpenPoint < DistanceError)
        {
            OPEN = true;
            Debug.Log("Устройство открыто");
        }
        else OPEN = false;

        if (DistanceClosePoint < DistanceError)
        {
            CLOSE = true;
            Debug.Log("Устройство закрыто");
        }
        else CLOSE = false;
    }
}
