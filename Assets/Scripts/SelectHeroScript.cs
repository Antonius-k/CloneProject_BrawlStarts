using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//indexScript
public class SelectHeroScript : MonoBehaviour
{
    //���� ������Ʈ �迭��
    GameObject[] Heroes;
    int HeroIndex;

    // Start is called before the first frame update
    void Start()
    {
        InstantiateHero();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Start���� �������� �ν���Ʈȭ ���ѳ��.
    public void InstantiateHero()
    {
        Instantiate(Heroes[HeroIndex],transform.position, transform.rotation, transform);
    }
}
