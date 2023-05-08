using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPlay : MonoBehaviour
{
    public string Name;
    public Button Play;
    // Start is called before the first frame update
    void Start()
    {
        Play.onClick.AddListener(Simple);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Simple()
    {
        SceneManager.LoadScene(Name);
    }
}