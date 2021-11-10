using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class CellBehavior : MonoBehaviour
{
    public GameObject SpriteCell;

    [HideInInspector]
    public CellObject cell;
    [HideInInspector]
    public GenerateMesh mesh;
    [HideInInspector]
    public GenerateTask task;

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (mesh.ready)
            {
                if (cell.value == task.currentTask)
                {
                    mesh.ready = false;
                    StartCoroutine(DownAnimation());
                }
                else
                {
                    SpriteCell.transform.DOShakePosition(1.0f, strength: new Vector3(0.5f, 0, 0), vibrato: 4, randomness: 1, snapping: false, fadeOut: true);
                }
            }
        }
    }

    IEnumerator DownAnimation()
    {
        SpriteCell.transform.DOShakePosition(1.0f, strength: new Vector3(0, 0.5f, 0), vibrato: 4, randomness: 1, snapping: false, fadeOut: true);
        yield return new WaitForSeconds(1f);
        mesh.ready = true;
        StartCoroutine(mesh.Mesh());
    }
}