using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 7�� 20�� ��ũ��Ʈ �߰�

public class PlayerDamageText : MonoBehaviour
{
    // text �̵��ӵ�
    public float moveSpeed;
    // ���� ��ȯ�ӵ�
    public float alphaSpeed;
    public float destroyTime;
    Text text;
    // text�� �÷��� ���� ����
    Color alpha;
    public int playerDamage;

    void Start()
    {
        //playerDamage = GameObject.Find("Player").GetComponents<Stat>.power
        if (PlayerGameManager.Instance.playerCheck)
        {
            text = GetComponent<Text>();
            text.text = playerDamage.ToString();
            // damage�� string���� ��ȯ
            alpha = text.color;
            // invoke�� �̿��� N�� �Ŀ� ������Ʈ �ı�
            Invoke("DestroyObject", destroyTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0));
        // color.a ���� ���� ������ ���Ѵ�. 0�� ����������� ��������
        // Mathf.Lerp(a,b,t) -> t���� ���ؼ� a�� b ���� ���� ��ȯ
        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaSpeed);
        // text.color ���� alpha������ �ʱ�ȭ.
        text.color = alpha;
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
