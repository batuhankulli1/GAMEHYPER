using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public SoundManager sounds;
    public Image whiteefecctimage;
   
    private int effectControl = 0;
    private bool radialshine;

    public Image FillRateImage;
    public Animator LayoutAnimator;
    public Text coin_text;




    public GameObject settings_Open;
    public GameObject settings_Close;
    public GameObject layout_Backround;
    public GameObject sound_On;
    public GameObject sound_Off;
    public GameObject vibration_On;
    public GameObject vibration_Off;


    public GameObject intro_Hand;
    public GameObject txt_Move;
    public GameObject noAds;
    public GameObject shop_button;

    public GameObject resTart;


    public GameObject finishscreen;
    public GameObject blackBackgraund;
    public GameObject complet;
    public GameObject radial_Shane;
    public GameObject coin;
    public GameObject rewarded;
    public GameObject nothanks;
    






    public void Start()
    {
        if (PlayerPrefs.HasKey("Sound") == false)
        {
            PlayerPrefs.SetInt("Sound", 1);
        }
        if (PlayerPrefs.HasKey("Vibration") == false)
        {
            PlayerPrefs.SetInt("Vibration", 1);
        }
        CoinTextUpdate();
    }

    public void Update()
    {
        if (radialshine==true )
        {
            radial_Shane.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 15f *Time.deltaTime));
        }
    }



    public void FirstTouch()
    {
        intro_Hand.SetActive(false);
        txt_Move.SetActive(false);
        noAds.SetActive(false);
        shop_button.SetActive(false);
        settings_Open.SetActive(false);
        settings_Close.SetActive(false);
        layout_Backround.SetActive(false);
        sound_On.SetActive(false);
        sound_Off.SetActive(false);
        vibration_On.SetActive(false);
        vibration_Off.SetActive(false);
    }

    public void CoinTextUpdate()
    {
        coin_text.text = PlayerPrefs.GetInt("moneyy").ToString();

    }


    public void RestartButtonActive()
    {

        resTart.SetActive(true);
    }

    public void RestartScene()
    {
        Veriables.firsttouch = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void FinishScreen()
    {
       
        StartCoroutine("FinishLaunch");

    }
    public IEnumerator FinishLaunch()
    {
        Time.timeScale = 0.3f;
        radialshine = true;
        finishscreen.SetActive(true);
        blackBackgraund.SetActive(true);
        yield return new WaitForSecondsRealtime(0.8f);
        complet.SetActive(true);
        sounds.CompleteSound();
        yield return new WaitForSecondsRealtime(1.3f);
        sounds.CompleteSound();
        radial_Shane.SetActive(true);
        coin.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        rewarded.SetActive(true);
       // sounds.CompleteSound();
        yield return new WaitForSecondsRealtime(3f);
        nothanks.SetActive(true);


    }



    public void Settings_Open()
    {

        settings_Open.SetActive(false);
        settings_Close.SetActive(true);
        LayoutAnimator.SetTrigger("Slide_in");

        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            sound_On.SetActive(true);
            sound_Off.SetActive(false);
            AudioListener.volume = 1;
        }
        else if (PlayerPrefs.GetInt("Sound") == 2)
        {
            sound_On.SetActive(false);
            sound_Off.SetActive(true);
            AudioListener.volume = 0;
        }


        if (PlayerPrefs.GetInt("Vibration") == 1)
        {
            vibration_On.SetActive(true);
            vibration_Off.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Vibration") == 2)
        {
            vibration_On.SetActive(false);
            vibration_Off.SetActive(true);
        }
    }

    public void Settings_Close()
    {

        settings_Open.SetActive(true);
        settings_Close.SetActive(false);
        LayoutAnimator.SetTrigger("Slide_out");
    }

    public void Sound_On()
    {
        sound_On.SetActive(false);
        sound_Off.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("Sound", 2);
    }


    public void Sound_Off()
    {
        sound_On.SetActive(true);
        sound_Off.SetActive(false);
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("Sound", 1);
    }

    public void Vibration_On()
    {
        vibration_On.SetActive(false);
        vibration_Off.SetActive(true);
        PlayerPrefs.SetInt("Vibration", 2);

    }

    public void Vibration_Off()
    {
        vibration_On.SetActive(true);
        vibration_Off.SetActive(false);
        PlayerPrefs.SetInt("Vibration", 1);
    }














    public IEnumerator WhiteEffect()
    {
        whiteefecctimage.gameObject.SetActive(true);

        while (effectControl == 0)
        {
            yield return new WaitForSeconds(0.001f);
            whiteefecctimage.color += new Color(0, 0, 0, 0.1f);
            if (whiteefecctimage.color == new Color(whiteefecctimage.color.r, whiteefecctimage.color.g, whiteefecctimage.color.b, 1))
            {
                effectControl = 1;
            }
        }

        while (effectControl == 1)
        {
            yield return new WaitForSeconds(0.001f);
            whiteefecctimage.color -= new Color(0, 0, 0, 0.1f);
            if (whiteefecctimage.color == new Color(whiteefecctimage.color.r, whiteefecctimage.color.g, whiteefecctimage.color.b, 0))
            {
                effectControl = 2;

            }
        }

        if (effectControl == 2)
        {
            Debug.Log("Efekt bitti");
        }



    }
}

