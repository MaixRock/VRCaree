using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nitro : MonoBehaviour
{
    public GameObject nitro;
    public float nitrotime = 20f;
    public Text nitrotext;
    public AudioSource nitrosource;
    public AudioClip nitroclip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nitrotime -= Time.deltaTime;
        nitrotext.text = "время до ускоренния: " + Mathf.Round(nitrotime);
        if (nitrotime < 0)
        {
            nitrotext.text = "время до ускоренyия : 0";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Vector3 delta = nitro.transform.position - this.transform.position;
                delta.Normalize();
                this.transform.position += delta * 15f;
                nitrotime = 20f;
                nitrosource.PlayOneShot(nitroclip);
            }
        }
    }
}
