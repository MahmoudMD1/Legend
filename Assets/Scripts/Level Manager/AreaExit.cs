using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    [SerializeField] string sceneToLoad;
    [SerializeField] string responseArea;
    [SerializeField] AreaEnter theAreaEnter;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag== "Player")
        {
            PlayerController.instance.responseArea = responseArea;

            UIController.instance.FadeImage();

            StartCoroutine(LoadSceneCorourtine());
        }
        
    }
    void Start()
    {
        theAreaEnter.areaName = responseArea;





    }
    IEnumerator LoadSceneCorourtine()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneToLoad);
    }
}
