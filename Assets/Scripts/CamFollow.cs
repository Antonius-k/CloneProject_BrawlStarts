using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    private float distance = 10.0f;

    [SerializeField]
    private float height = 12.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool playercheck = GameObject.FindWithTag("Player");
        //print("CamFollow Player check: "+ playercheck);
        if (playercheck)
        {
            target = GameObject.FindWithTag("Player").transform;
            var wantedHeight = target.position.y + height;
            transform.position = target.position + (Vector3.back * distance);
            transform.position = new Vector3(transform.position.x, wantedHeight, transform.position.z);
            transform.LookAt(target);
        }
        else//¾ø´Ù¸é
        {
            return;
        }
    }

    /*
        private void LateUpdate()
        {
            if (!target)
            {
                return;
            }
            var wantedHeight = target.position.y + 12f;
            transform.position = target.position + (Vector3.back * distance);
            transform.position = new Vector3(transform.position.x, wantedHeight, transform.position.z);
            transform.LookAt(target);
        }
    */
}
