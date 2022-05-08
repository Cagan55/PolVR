using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : MonoBehaviour
{
    [Header("Bool")]
    public bool move = false;
    public bool tekneMove = false;
    public bool tekneMove2 = false;
    public bool tekneMove3 = false;

    [Header("Hız_Degerleri")]
    public float hızGemi = -0.01f;
    public float tekneHız = 0.035f;

    [Header("GameObject")]
    public GameObject tekne;
    public GameObject cube5;
    public GameObject cubeTekne2;
    public GameObject cubeTekne3;
    public GameObject cubeTekne;
    public GameObject cube10;
    public Camera camera;

    AudioSource audio;
    AudioSource audio2;
    AudioSource audio3;

    [Header("Volume")]
    public float gemiVolume;
    public float denizVolume;
    public float botVolume;

    [Header("AudioClip")]
    public AudioClip gemiSes;
    public AudioClip denizSes;
    public AudioClip botSes;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio2 = GetComponent<AudioSource>();
        audio3 = GetComponent<AudioSource>();
        audio.PlayOneShot(denizSes, denizVolume);
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            move = true;
            audio.Stop();
            audio2.PlayOneShot(gemiSes, gemiVolume);
        }
        if (move)
        {
            transform.Translate(0f, hızGemi, 0f);
            cube10.SetActive(true);
        }
        else if (move == false)
        {
            cube10.SetActive(false);
        }
        if (Input.GetButtonDown("Fire3") && hızGemi == 0)
        {
            tekneMove = true;
            tekneMove2 = true;
        }
        if (tekneMove == true)
        {
            tekne.transform.Translate(0f, 0f, tekneHız);
            audio3.PlayOneShot(botSes, botVolume);
        }
        else if (tekneMove2 == true && tekneMove == false)
        {
            audio3.Stop();
            cubeTekne.SetActive(false);
            cubeTekne2.SetActive(false);
            cubeTekne3.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "denCol")
        {
            move = false;
            hızGemi = 0;
            audio2.Stop();
            tekne.SetActive(true);
            cube5.SetActive(false);
        }
    }
}