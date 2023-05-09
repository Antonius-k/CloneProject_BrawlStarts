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
        // 3. 이동하고 싶다. (Player가 위로 올라가는걸 방지하기 위해 아래방향으로 계속 이동하게끔 dir에 더해줌)
        cc.Move((dir + Vector3.down) * speed * Time.deltaTime);
    }
}
