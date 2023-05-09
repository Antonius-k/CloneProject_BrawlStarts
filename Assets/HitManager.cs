using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{

    public static HitManager Instance;

    public GameObject imageHit;

    private void Awake()
    {
        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        imageHit.SetActive(false);
    }

    public void Hit()
    {
        StartCoroutine("CoHit");
    }

    IEnumerator CoHit()
    {
        imageHit.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        imageHit.SetActive(false);
    }
}