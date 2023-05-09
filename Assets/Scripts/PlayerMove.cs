using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    CharacterController cc;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v).normalized;

        if (dir.magnitude != 0)
        {
            transform.forward = dir;
        }
        // 3. �̵��ϰ� �ʹ�. (Player�� ���� �ö󰡴°� �����ϱ� ���� �Ʒ��������� ��� �̵��ϰԲ� dir�� ������)
        cc.Move((dir + Vector3.down) * speed * Time.deltaTime);
    }
}
