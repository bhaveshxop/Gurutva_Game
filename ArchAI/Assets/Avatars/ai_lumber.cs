using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ai_lumber : MonoBehaviour
{
   public GameObject sam;
    Vector3 sampos;
    public ParticleSystem particle;
    public GameObject fence;
    public GameObject info_2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {
            transform.localPosition=sam.transform.position;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="archer")
        {
            particle.Play();
            collision.other.gameObject.SetActive(false);
            fence.SetActive(false);
            this.gameObject.SetActive(false);
            info_2.SetActive(false);
            MoveErika.Instance.showInfo("Get The Poison");

        }
    }
}
