using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public ParticleSystem PS;
    // Start is called before the first frame update
    void Start()
    {
        PS.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        PS.Play();
    }
}
