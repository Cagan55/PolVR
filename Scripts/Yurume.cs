using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]

public class Yurume : MonoBehaviour
{
    public static Yurume instance;

    public float hiz = 2.0F;
    public bool ilerle = true;

    public CharacterController controller;
    public Transform mainCamera;
    void Start()
    {
        instance = this;
        controller = GetComponent<CharacterController>();
        mainCamera = Camera.main.transform;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ilerle = !ilerle;
        }
        if (ilerle)
        {
            Vector3 forward = mainCamera.TransformDirection(Vector3.forward);
            controller.SimpleMove(forward * hiz);
        }
        else if (!ilerle)
        {
            Vector3 forward = mainCamera.TransformDirection(Vector3.forward);
            controller.SimpleMove(forward * 0.0F);
        }
        if (Input.GetButtonDown("Fire0"))
        {
            mainCamera.transform.position = new Vector3(-13.6f, 3.23f, -2.7f);
        }
    }
}