using System;
using Cinemachine;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private CinemachineFreeLook vcamera;

    [SerializeField] private float sensitivity = 10f;

    private float cameraDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Debug.Log(Input.GetAxis("Mouse ScrollWheel")*sensitivity-vcamera.m_Lens.FieldOfView);
            if ((Input.GetAxis("Mouse ScrollWheel") * sensitivity)-vcamera.m_Lens.FieldOfView <=-5)
            {
                if ((Input.GetAxis("Mouse ScrollWheel") * sensitivity)-vcamera.m_Lens.FieldOfView >= -80)
                {
                    cameraDistance = Input.GetAxis("Mouse ScrollWheel") * sensitivity;
                    vcamera.m_Lens.FieldOfView -= cameraDistance;
                }
            }
        }
    }
}
