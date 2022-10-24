using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SorterRadium : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Radium"))
        {
            collision.gameObject.tag = "Destroy";
            collision.transform.SetParent(SortingManager.Instance.transform);
            SortingManager.Instance.countRadium();
        }
    }
}