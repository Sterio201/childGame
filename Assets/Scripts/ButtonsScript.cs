using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ButtonsScript : MonoBehaviour
{
    [SerializeField] GameObject panelEnd;
    [SerializeField] Image bg;
    [SerializeField] GenerateMesh generateMesh;
    [SerializeField] Image loadScreen;

    public void ShowPanel()
    {
        panelEnd.SetActive(true);
        bg.DOFade(0.5f, 4f);
    }

    public void Restart()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        loadScreen.gameObject.SetActive(true);
        loadScreen.DOFade(1, 3f);
        bg.DOFade(0f, 3f);
        panelEnd.SetActive(false);
        yield return new WaitForSeconds(4f);
        loadScreen.DOFade(0, 3f);
        loadScreen.gameObject.SetActive(false);

        generateMesh.firstShow = true;
        StartCoroutine(generateMesh.Mesh());
    }

    public void Exit()
    {
        Application.Quit();
    }
}