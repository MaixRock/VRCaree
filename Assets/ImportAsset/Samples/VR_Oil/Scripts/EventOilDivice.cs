using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventOilDivice : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Rotate_Divice;
    public GameObject Grab_Divice;
    public GameObject Colider_Object;
    public GameObject Gas;


    public bool EnableRotateDivice;

    void Start()
    {
        if (!EnableRotateDivice)
        {
            Rotate_Divice.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.name == Colider_Object.name)
        {
            EnableRotateDivice = true;

            Rotate_Divice.SetActive(true);

            Grab_Divice.SetActive(false);
            Gas.SetActive(false);
        }
    }
}
