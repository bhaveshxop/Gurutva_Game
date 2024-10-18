using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rot : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    Transform transform;
    [SerializeField] Vector3 initialposs;
    [SerializeField] Vector3 axis;

    void Start()
    {
       
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        rotate();
    }
    void rotate()
    {
        
            transform.RotateAround(initialposs, axis, 0.5f * Time.timeScale);
            StartCoroutine(stopTreeTime());
        
        


    }
    IEnumerator stopTreeTime()
    {
        yield return new WaitForSeconds(3);

       // transform.RotateAround(initialposs, axis, 0f * Time.timeScale);
    }
}
