using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ī�޶� ������ �׻� ���� ���ϰ��Ѵ�.
        transform.forward = Camera.main.transform.forward;
    }
}
