using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public UIManager uimanager;
    public GameObject particle;
    public GameObject particle2;
    public GameObject particle3;
    public GameObject particle4;

    public Sprite yellowImage;
    public Sprite greenImage;
    public GameObject ýtem;
    public GameObject ýtem2;
    public GameObject ýtem3;
    public GameObject ýtem4;

    public GameObject lock1;
    public GameObject lock2;
    public GameObject lock3;


    public void Awake()

    {

        if (PlayerPrefs.HasKey("itemselect") == false)
            PlayerPrefs.SetInt("itemselect", 0);

        if (PlayerPrefs.GetInt("itemselect") == 0)
            Item1Open();
        else if (PlayerPrefs.GetInt("itemselect") == 1)
            Item2Open();
        else if (PlayerPrefs.GetInt("itemselect") == 2)
            Item3Open();
        else if (PlayerPrefs.GetInt("itemselect") == 3)
            Item4Open();





        if (PlayerPrefs.HasKey("lock1control")==false)
            PlayerPrefs.SetInt("lock1control", 0);

        if (PlayerPrefs.HasKey("lock2control")==false)
            PlayerPrefs.SetInt("lock2control", 0);

        if (PlayerPrefs.HasKey("lock3control")==false)
            PlayerPrefs.SetInt("lock3control", 0);
        
        if (PlayerPrefs.GetInt("lock1control") == 1)
            lock1.SetActive(false);

        if (PlayerPrefs.GetInt("lock2control") == 1)
            lock2.SetActive(false);

        if (PlayerPrefs.GetInt("lock3control") == 1)
            lock3.SetActive(false);

    }

    public void Item1Open()
    {
        particle.SetActive(true);
        particle2.SetActive(false);
        particle3.SetActive(false);
        particle4.SetActive(false);
        ýtem.GetComponent<Image>().sprite = greenImage;
        ýtem2.GetComponent<Image>().sprite = yellowImage;
        ýtem3.GetComponent<Image>().sprite = yellowImage;
        ýtem4.GetComponent<Image>().sprite = yellowImage;
        PlayerPrefs.SetInt("itemselect", 0);
    }

    public void Item2Open()
    {
        particle.SetActive(false);
        particle2.SetActive(true);
        particle3.SetActive(false);
        particle4.SetActive(false);
        ýtem.GetComponent<Image>().sprite = yellowImage;
        ýtem2.GetComponent<Image>().sprite = greenImage;
        ýtem3.GetComponent<Image>().sprite = yellowImage;
        ýtem4.GetComponent<Image>().sprite = yellowImage;
        PlayerPrefs.SetInt("itemselect", 1);
    }

    public void Item3Open()
    {
        particle.SetActive(false);
        particle2.SetActive(false);
        particle3.SetActive(true);
        particle4.SetActive(false);
        ýtem.GetComponent<Image>().sprite = yellowImage;
        ýtem2.GetComponent<Image>().sprite = yellowImage;
        ýtem3.GetComponent<Image>().sprite = greenImage;
        ýtem4.GetComponent<Image>().sprite = yellowImage;
        PlayerPrefs.SetInt("itemselect", 2);
    }
    public void Item4Open()
    {
        particle.SetActive(false);
        particle2.SetActive(false);
        particle3.SetActive(false);
        particle4.SetActive(true);
        ýtem.GetComponent<Image>().sprite = yellowImage;
        ýtem2.GetComponent<Image>().sprite = yellowImage;
        ýtem3.GetComponent<Image>().sprite = yellowImage;
        ýtem4.GetComponent<Image>().sprite = greenImage;
        PlayerPrefs.SetInt("itemselect", 3);
    }


    public void Lock1Open()
    {

        int money = PlayerPrefs.GetInt("moneyy");
        int lock1control = PlayerPrefs.GetInt("lock1control");
        if (money>=2000 && lock1control==0 )
        {
            lock1.SetActive(false);
            PlayerPrefs.SetInt("moneyy", money - 2000);
            PlayerPrefs.SetInt("lock1control", 1);
            Item2Open();
            uimanager.CoinTextUpdate();
        }
    }

    public void Lock2Open()
    {
        int money = PlayerPrefs.GetInt("moneyy");
        int lock2control = PlayerPrefs.GetInt("lock2control");
        if (money >= 5000 && lock2control==0)
        {
            lock2.SetActive(false);
            PlayerPrefs.SetInt("moneyy", money - 5000);
            PlayerPrefs.SetInt("lock2control", 1);
            Item3Open();
            uimanager.CoinTextUpdate();
        }
    }
    public void Lock3Open()
    {

        int money = PlayerPrefs.GetInt("moneyy");
        int lock3control = PlayerPrefs.GetInt("lock3control");
        if (money >= 10000 && lock3control==0)
        {
            lock3.SetActive(false);
            PlayerPrefs.SetInt("moneyy", money - 10000);
            PlayerPrefs.SetInt("lock3control", 1);
            Item4Open();
            uimanager.CoinTextUpdate();
        }
    }
}
