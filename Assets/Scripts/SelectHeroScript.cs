using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//indexScript
public class SelectHeroScript : MonoBehaviour
{
    //영웅 오브젝트 배열로
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

    //Start에서 영웅들을 인스턴트화 시켜논다.
    public void InstantiateHero()
    {
        Instantiate(Heroes[HeroIndex],transform.position, transform.rotation, transform);
    }
}
