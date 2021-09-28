using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour
{
    public LayerMask layer;
    private Vector3 previousPos;
    public Canvas[] images;
    public GameObject[] imgs;
    private int hp_count = 5;
    
    void Start()
    {
        //images = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1, layer))
        {
            if (Vector3.Angle(transform.position - previousPos, hit.transform.up) > 130)
            {
                Destroy(hit.transform.gameObject);
            }
            else if (hit.transform.forward.z > 16.0f)
            {
                DestroyImg();
            }
        }
        previousPos = transform.position;
    }

    void DestroyImg()
    {
        if (hp_count > 0) {
            Destroy(imgs[hp_count - 1]);
        }
    }
}
