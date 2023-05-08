using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuExit : MonoBehaviour
{
    public Button Exit;
    // Start is called before the first frame update
    void Start()
    {
        Exit.onClick.AddListener(Simple);

    }

    // Update is called once per frame
    void Update()
    {

    }
    void Simple()
    {
        Application.Quit();
    }
}