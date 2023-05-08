using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish: MonoBehaviour
{
    public Text Playertext;
    public Text Car1text;
    public Text Car2text;
    public Text Car3text;
    public Text Car4text;
    public int Player = 0;
    public int Car1 = 0;
    public int Car2 = 0;
    public int Car3 = 0;
    public int Car4 = 0;
    public string winmenu;
    public string menudefeat;
    public int inPlayer = 0;
    public int inCar1 = 0;
    public int inCar2 = 0;
    public int inCar3 = 0;
    public int inCar4 = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Player == 3)
        {
            SceneManager.LoadScene(winmenu);
        }
        if (Car1 == 3)
        {
            SceneManager.LoadScene(menudefeat);
        }
        if (Car2 == 3)
        {
            SceneManager.LoadScene(menudefeat);
        }
        if (Car3 == 3)
        {
            SceneManager.LoadScene(menudefeat);
        }
        if (Car4 == 3)
        {
            SceneManager.LoadScene(menudefeat);
        }
        Playertext.text = "Murza4: " + Player;
        Car1text.text = "RoboGitler: " + Car1;
        Car2text.text = "Pupa: " + Car2;
        Car3text.text = "Lupa: " + Car3;
        Car4text.text = "Boba: " + Car4;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (inPlayer == 1)
        {


            if (other.tag == "Player")
            {
                Player++;
                inPlayer = 0;
            }
        }
        if (inCar1 == 1)
        {
            if (other.tag == "Car1")
            {
                Car1++;
                inCar1 = 0;
            }
        }
        if (inCar2 == 1)
        {
            if (other.tag == "Car2")
            {
                Car2++;
                inCar2 = 0;
            }
        }
        if (inCar3 == 1)
        {
            if (other.tag == "Car3")
            {
                Car3++;
                inCar3 = 0;
            }
        }
        if (inCar4 == 1)
        {
            if (other.tag == "Car4")
            {
                Car4++;
                inCar4 = 0;
            }

        }



    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            
            inPlayer = 1;
        }
        if (other.tag == "Car1")
        {
           
            inCar1 = 1;
        }
        if (other.tag == "Car2")
        {
            
            inCar2 = 1;
        }
        if (other.tag == "Car3")
        {
            
            inCar3 = 1;
        }
        if (other.tag == "Car4")
        {
            
            inCar4 = 1;
        }


    }
}