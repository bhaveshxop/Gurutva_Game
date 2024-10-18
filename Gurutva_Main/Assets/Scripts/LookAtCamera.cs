using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LookAtCamera : MonoBehaviour
{
    public static LookAtCamera Instance;

    [SerializeField] Transform cam;
    [SerializeField] GameObject camera;
    [SerializeField] CinemachineFreeLook camfree;
    private void Awake()
    {
        if(Instance==null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }
    void Start()
    {
       camera.transform.localRotation= Quaternion.Euler(0f, 90f, 0f);
      
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(0f, cam.eulerAngles.y, 0f);
    }
    public void IncreaseFreeSpeed()
    {
        camfree.m_YAxis.m_MaxSpeed = 1.5f;
        camfree.m_XAxis.m_MaxSpeed = 900f;
    }
    public void IncreaseFreeSpeed2()
    {
        camfree.m_YAxis.m_MaxSpeed = 5000f;
        camfree.m_XAxis.m_MaxSpeed = 3000000f;
    }
    public  void ResetFreeSpeed()
    {
        camfree.m_YAxis.m_MaxSpeed = 0.5f;
        camfree.m_XAxis.m_MaxSpeed = 300f;
    }
}
