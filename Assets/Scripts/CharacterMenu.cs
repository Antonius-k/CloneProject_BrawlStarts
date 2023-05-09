using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMenu : MonoBehaviour
{
    int sceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        print("sceneIndex:" + sceneIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickPlay()
    {
        PlayScene();
    }
    
    //플레이씬이동
    public void PlayScene()
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }

    //뒤로가기 함수 다만들어지면 버튼 만들어 주고
    public void PreviousScene()
    {
        //뒤로가기
        SceneManager.LoadScene(sceneIndex - 1);
    }
}
