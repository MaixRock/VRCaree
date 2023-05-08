using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torque : MonoBehaviour
{
    public float Strong_Rotation;
    public Vector3 Vector_Rotation;
    // Start is called before the first frame update

    private void Start()
    {
        Vector_Rotation = Vector_Rotation.normalized*Strong_Rotation;
    }
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rigidbody = other.GetComponentInParent<Rigidbody>();

        rigidbody.AddTorque(Vector_Rotation);
    }
}
