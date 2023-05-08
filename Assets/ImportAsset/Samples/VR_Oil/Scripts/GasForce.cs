using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasForce : MonoBehaviour
{
    public Rigidbody Divice;
    public GameObject Gas;
    public GameObject GrabRoatate;
    public StateDivice stateDivice;
    public float Force;
    public float WaitGrabActive;
    // Start is called before the first frame update
    private bool EnableGasPhusics;
    private bool WasClose;

    void Start()
    {
        EnableGasPhusics = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (stateDivice.CLOSE == true) WasClose = true;

        if (!EnableGasPhusics && WasClose)
        {
            if (!stateDivice.OPEN && !stateDivice.CLOSE)
            {
                EnableGasForce();
                EnableGasPhusics = true;
            }
        }

    }

    void EnableGasForce()
    {
        Gas.SetActive(true);
        GrabRoatate.SetActive(false);
        Divice.isKinematic = false;

        Divice.AddForce(new Vector3(-2, -2, 5).normalized*Force);
    }
}
