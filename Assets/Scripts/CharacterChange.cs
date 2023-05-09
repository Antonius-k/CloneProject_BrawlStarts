using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChange : MonoBehaviour
{
    //������ �س� ĳ���� �θ��� Instantiate(prefab)�ؼ� ��ư ������ ���� Ŭ���ϸ� ������
    //�ϴ� �ν��Ͻ� ���� ��ġ
    //
    GameObject allCharacter;
    Vector3 allCharacterPosition;

    // Start is called before the first frame update
    void Start()
    {
        //ĳ���� ��� �׽�Ʈ
        //Getcha();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�̰ɷ� �غ���
    GameObject getCharacter;
    Transform transform;
    
    GameObject[] getPlayers;
    GameObject[] getEnemys;
    Vector3 characterScale;
    void Getcha()
    {
        
        allCharacter = GameObject.Find("Character");
        allCharacterPosition = allCharacter.transform.position;
        //�ν��Ͻ�ȭ�ؼ� Resourcds������ ������ ã�Ƽ� Instantiate

        //getCharacter = (GameObject)Instantiate(Resources.Load("Player/Hero_t"));
        //getCharacter = Instantiate(Resources.Load("Player/Hero_t")) as GameObject;

        getPlayers = Resources.LoadAll<GameObject>("Prefabs/Heroes/Player_BasicMale");

        getCharacter = Resources.Load("Prefabs/Heroes/Player_BasicMale") as GameObject;
        //������ ũ�� ����, ĳ���� ������ ����
        characterScale = new Vector3(7f, 7f, 7f);
        
        
        transform = getCharacter.transform;
        transform.localScale = characterScale;
        transform.position = new Vector3(0, 0, 30);
        

        //ȭ�鿡 ���(������Ʈ�̸�,��ġ,ȸ����)
        //Instantiate(getCharacter, allCharacterPosition, Quaternion.identity);
        Instantiate(getCharacter, allCharacterPosition, Quaternion.Euler(0, 180, 0));

    }
    
}
