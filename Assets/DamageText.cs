using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    // text 이동속도
    public float moveSpeed;
    // 투명도 변환속도
    public float alphaSpeed;
    public float destroyTime;
    TextMeshProUGUI text;
    // text의 컬러를 담을 변수
    Color alpha;
    public int damage;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = damage.ToString();
        // damage를 string으로 변환
        alpha = text.color;
        // invoke를 이용해 N초 후에 오브젝트 파괴
        Invoke("DestroyObject", destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0));
        // color.a 값에 따라 투명도가 변한다. 0에 가까워질수록 투명해짐
        // Mathf.Lerp(a,b,t) -> t값에 의해서 a와 b 사이 값을 반환
        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaSpeed);
        // text.color 값을 alpha값으로 초기화.
        text.color = alpha;
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
