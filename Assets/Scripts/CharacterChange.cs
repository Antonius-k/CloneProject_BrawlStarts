using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChange : MonoBehaviour
{
    //프리팹 해논 캐릭터 두마리 Instantiate(prefab)해서 버튼 오른쪽 왼쪽 클릭하면 만들어보자
    //일단 인스턴스 생성 위치
    //
    GameObject allCharacter;
    Vector3 allCharacterPosition;

    // Start is called before the first frame update
    void Start()
    {
        //캐릭터 출력 테스트
        //Getcha();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //이걸로 해보자
    GameObject getCharacter;
    Transform transform;
    
    GameObject[] getPlayers;
    GameObject[] getEnemys;
    Vector3 characterScale;
    void Getcha()
    {
        
        allCharacter = GameObject.Find("Character");
        allCharacterPosition = allCharacter.transform.position;
        //인스턴스화해서 Resourcds폴더내 프리팹 찾아서 Instantiate

        //getCharacter = (GameObject)Instantiate(Resources.Load("Player/Hero_t"));
        //getCharacter = Instantiate(Resources.Load("Player/Hero_t")) as GameObject;

        getPlayers = Resources.LoadAll<GameObject>("Prefabs/Heroes/Player_BasicMale");

        getCharacter = Resources.Load("Prefabs/Heroes/Player_BasicMale") as GameObject;
        //프리팹 크기 조절, 캐릭터 사이즈 변경
        characterScale = new Vector3(7f, 7f, 7f);
        
        
        transform = getCharacter.transform;
        transform.localScale = characterScale;
        transform.position = new Vector3(0, 0, 30);
        

        //화면에 출력(오브젝트이름,위치,회전값)
        //Instantiate(getCharacter, allCharacterPosition, Quaternion.identity);
        Instantiate(getCharacter, allCharacterPosition, Quaternion.Euler(0, 180, 0));

    }
    
}
