using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkRoatate : MonoBehaviour
{
    public Transform MainTransform;
    public Transform LinkTransform;

    void Update()
    {
        LinkTransform.rotation = MainTransform.rotation;
    }
}
