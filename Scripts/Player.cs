using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public CameraShake camerashake;
    public UIManager uýManager;
    public SoundManager sounds;
    public GameObject vectorBack;
    public GameObject vectorForward;
    public GameObject cam;
    Rigidbody rb;
    private Touch touch;
    [Range(20,40)]
    public float speedPlayer;
    public int forwardSpeed;
    private bool speedballForward;
    private bool firsttouchcontrol = false;
    private int soundlimitcount;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Veriables.firsttouch == 1 && speedballForward == false)
        {
            transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            vectorBack.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            vectorForward.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
        }










        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {

                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    if (firsttouchcontrol == false)
                    {
                        Veriables.firsttouch = 1;
                        uýManager.FirstTouch();
                        firsttouchcontrol = true;
                    }

                }

            }




            if (touch.phase == TouchPhase.Moved)
            {



                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {

                    rb.velocity = new Vector3(touch.deltaPosition.x * speedPlayer * Time.deltaTime, transform.position.y,
                                                             touch.deltaPosition.y * speedPlayer * Time.deltaTime);

                    if (firsttouchcontrol == false)
                    {
                        Veriables.firsttouch = 1;
                        uýManager.FirstTouch();
                        firsttouchcontrol = true;
                    }

                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    rb.velocity = Vector3.zero;
                }
            }
        }
    }
    public GameObject[] FractureItems;
    public void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("Obstacles"))
          
        {
            camerashake.CameraShakesCall();
            uýManager.StartCoroutine("WhiteEffect");
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            sounds.BlowUpSound();
            if (PlayerPrefs.GetInt("Vibration") == 1)
            {
                Vibration.Vibrate(50);
            }
            else if (PlayerPrefs.GetInt("Vibration") == 2)
            {
                Debug.Log("no vibration");
            }
            foreach (GameObject item in FractureItems)
            {
                item.GetComponent<SphereCollider>().enabled = true;
                item.GetComponent<Rigidbody>().isKinematic = false;
            }
            StartCoroutine("TimeScaleControl");
        }
        if (hit.gameObject.CompareTag("Untagged"))
        {
            sounds.ObjectHitSound();
            soundlimitcount++;
        }
         if (hit.gameObject.CompareTag("Untagged")&& soundlimitcount % 5 == 0 )
        {
            sounds.ObjectHitSound();
        }
       
    }
    public IEnumerator TimeScaleControl()
    {
        speedballForward = true;
        yield return new WaitForSecondsRealtime(0.4f);
        Time.timeScale = 0.4f;
        yield return new WaitForSecondsRealtime(0.6f);
        uýManager.RestartButtonActive();
        rb.velocity = Vector3.zero;
    }


}
