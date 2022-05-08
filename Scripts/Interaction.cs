using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public MoveShip mS;
    public GameObject bayrak;

    public Transform PlayerCamera;
    public float MaxDistance = 5;

    private bool opened = false;
    private bool opened2 = false;
    private bool opened3 = false;
    private bool startAudio2Check = false;
    private bool atokCheck = false;
    private bool serapCheck = false;
    private bool savasCheck = false;
    private bool ekosistemCheck = false;
    private bool TBIcheck = false;
    private bool araCheck = false;

    public Animator anim;
    public Animator anim2;
    public Animator anim3;

    AudioSource audio;
    public AudioClip startAudio;
    public AudioClip startAudio2;
    public AudioClip atokAudio;
    public AudioClip serapAudio;
    public AudioClip savasAudio;
    public AudioClip telsizAudio;
    public AudioClip meterolojiAudio;
    public AudioClip Tur1Audio;
    public AudioClip Tur2Audio;
    public AudioClip denizSes;
    public AudioClip ekoSound;
    public AudioClip ekoSound2;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.PlayOneShot(denizSes, 0.02f);
    }
    void Update()
    {
        if (mS.move == true)
        {
            audio.PlayOneShot(startAudio, 1f);
        }

        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if(Input.GetButtonDown("Fire2"))
            {
                if (hit.transform.name == "bayrak")
                {
                    bayrak.transform.localPosition = new Vector3(3.19f, 4.2f, 12.1f);
                }
                if (hit.transform.name == "Atok Karaali" && audio.isPlaying == false)
                {
                    audio.PlayOneShot(atokAudio, 1f);
                }
                if (hit.transform.name == "Serap Tilav" && audio.isPlaying == false)
                {
                    audio.PlayOneShot(serapAudio, 1f);
                }
                if (hit.transform.name == "Umran Savaş İnan" && audio.isPlaying == false)
                {
                    audio.PlayOneShot(savasAudio, 1f);
                }
                if (hit.transform.name == "Telsiz_Tekrarlayici" && audio.isPlaying == false)
                {
                    audio.PlayOneShot(telsizAudio, 1f);
                }
                if (hit.transform.name == "Meteoroloji_Istasyonu" && audio.isPlaying == false)
                {
                    audio.PlayOneShot(meterolojiAudio, 1f);
                }
                if (hit.transform.name == "TUR1_GNSS" && audio.isPlaying == false)
                {
                    audio.PlayOneShot(Tur1Audio, 1f);
                }
                else if (hit.transform.name == "TUR1_GNSS_Alici" && audio.isPlaying == false)
                {
                    audio.PlayOneShot(Tur1Audio, 1f);
                }
                if (hit.transform.name == "TUR2_GNSS" && audio.isPlaying == false)
                {
                    audio.PlayOneShot(Tur2Audio, 1f);
                }
                else if (hit.transform.name == "TUR2_GNSS_Alici" && audio.isPlaying == false)
                {
                    audio.PlayOneShot(Tur2Audio, 1f);
                }
                if (hit.transform.tag == "Animal" && ekosistemCheck == false && audio.isPlaying == false)
                {
                    ekosistemCheck = true;
                    audio.PlayOneShot(ekoSound, 1f);
                }
                if (hit.transform.name == "konteynır.004" && araCheck == false)
                {
                    audio.PlayOneShot(ekoSound2, 1f);
                    araCheck = true;
                }
            }
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Pressed();
        }
        if (audio.isPlaying == false && startAudio2Check == false && mS.cubeTekne.active == false && mS.tekne.active == true)
        {
            audio.PlayOneShot(startAudio2, 1f);
            startAudio2Check = true;
        }
    }
    void Pressed()
    {
        RaycastHit doorhit;
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out doorhit, MaxDistance))
        {
            if (doorhit.transform.name == "kapı")
            {
                anim = doorhit.transform.GetComponentInParent<Animator>();
                opened = !opened;
                anim.SetBool("Acıldı", !opened);
            }
            if (doorhit.transform.name == "kapı3")
            {
                anim2 = doorhit.transform.GetComponentInParent<Animator>();
                opened2 = !opened2;
                anim2.SetBool("Acıldı2", !opened2);
            }
            if (doorhit.transform.name == "kapı2")
            {
                anim3 = doorhit.transform.GetComponentInParent<Animator>();
                opened3 = !opened3;
                anim3.SetBool("Acıldı3", !opened3);
            }
        }
    }
}
