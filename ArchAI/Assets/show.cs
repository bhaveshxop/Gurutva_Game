using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class show : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wait());
        
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public IEnumerator wait()
    {
        button.image.enabled = false;
        yield return new WaitForSeconds(6);
        button.image.enabled = true;

    }
}
