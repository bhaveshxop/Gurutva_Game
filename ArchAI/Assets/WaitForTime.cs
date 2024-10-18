using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForTime : MonoBehaviour
{
    public int thisTime;
    // Start is called before the first frame update
    public static WaitForTime Instance;
    public float JumpTime = 1f;
    public float thisTime2;
   // public GameObject grey;
   //hello there
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
      //  grey.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void waitTime(int time)
    {
        thisTime = time;
        StartCoroutine(waitForTime());
    }
    public void waitTime2(float time)
    {
        thisTime2 = time;
        StartCoroutine(waitForTime2());
    }
    public void waitJump()
    {
        StartCoroutine(waitJumpTimer());
    }
    IEnumerator waitForTime()
    {
        yield return new WaitForSeconds(thisTime);
        Time.timeScale = 1F;
       // grey.SetActive(false);
        SlowTime.instance.ResetValues();
        LookAtCamera.Instance.ResetFreeSpeed();
    }
    IEnumerator waitForTime2()
    {
        yield return new WaitForSeconds(thisTime2);
        Time.timeScale = 1F;
        SlowTime.instance.ResetValues();
        LookAtCamera.Instance.ResetFreeSpeed();
    }
    IEnumerator waitJumpTimer()
    {
        yield return new WaitForSeconds(4);
        SlowTime.instance.SlowTimer();
    }
    public void setJumpTime()
    {
        JumpTime = 3.0f;
    }
    public void resetJumpTime()
    {
        JumpTime = 1f;
    }
    
}
