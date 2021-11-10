using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GenerateTask : MonoBehaviour
{
    public Text textTask;

    [HideInInspector]
    public string currentTask;

    public void StartShowTask()
    {
        textTask.DOFade(1f, 3f);
    }
}