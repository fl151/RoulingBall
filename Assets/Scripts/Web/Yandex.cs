using UnityEngine;
using Agava.YandexGames;
using UnityEngine.SceneManagement;
using System.Collections;

public class Yandex : MonoBehaviour
{
    private const int _indexMainScene = 1;

    private void Awake()
    {
        StartCoroutine(YandexInitialize());
    }

    private IEnumerator YandexInitialize()
    {
        yield return YandexGamesSdk.Initialize();

        SceneManager.LoadScene(_indexMainScene);
    }
}
