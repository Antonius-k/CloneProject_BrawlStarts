using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Bullet") || collision.gameObject.CompareTag("Floor"))
        {
            Destroy(collision.gameObject);
        }
        /*if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
        }*/
    }
}
