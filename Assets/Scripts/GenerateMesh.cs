using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GenerateMesh : MonoBehaviour
{
    [SerializeField] GameObject cellPrefab;

    [SerializeField] Transform[] positions;

    [SerializeField] GenerateTask task;
    [SerializeField] ButtonsScript buttons;

    [SerializeField] List<CellObject> letters;
    [SerializeField] List<CellObject> numbers;

    List<GameObject> currentMesh;

    [HideInInspector]
    public bool firstShow;
    [HideInInspector]
    public bool ready;

    private void Start()
    {
        ready = true;
        firstShow = true;

        currentMesh = new List<GameObject>();

        StartCoroutine(Mesh());
    }

    public IEnumerator Mesh()
    {
        if (firstShow)
        {
            for (int i = 0; i < currentMesh.Count; i++)
            {
                Destroy(currentMesh[i]);
            }
            currentMesh = new List<GameObject>();
            task.textTask.DOFade(0f, 0f);
        }

        if(currentMesh.Count < 9)
        {
            if (ready)
            {
                int countMesh = currentMesh.Count + 3;

                for (int i = 0; i < currentMesh.Count; i++)
                {
                    Destroy(currentMesh[i]);
                }

                currentMesh = new List<GameObject>();

                int random = Random.Range(1, 3);

                List<CellObject> currentMass = new List<CellObject>();

                if (random == 1)
                {
                    currentMass.AddRange(letters);
                }
                else
                {
                    currentMass.AddRange(numbers);
                }

                for (int i = 0; i < countMesh; i++)
                {
                    GameObject new_cell = Instantiate(cellPrefab, positions[i]);

                    random = Random.Range(0, currentMass.Count);

                    new_cell.GetComponent<CellBehavior>().cell = currentMass[random];
                    new_cell.GetComponent<CellBehavior>().mesh = this;
                    new_cell.GetComponent<CellBehavior>().task = task;
                    new_cell.GetComponent<CellBehavior>().SpriteCell.GetComponent<SpriteRenderer>().sprite = currentMass[random].sprite;

                    currentMesh.Add(new_cell);
                    currentMass.Remove(new_cell.GetComponent<CellBehavior>().cell);

                    if (firstShow)
                    {
                        new_cell.transform.DOShakePosition(1.0f, strength: new Vector3(0, 0.5f, 0), vibrato: 4, randomness: 1, snapping: false, fadeOut: true);
                        yield return new WaitForSeconds(0.3f);
                    }
                }

                task.currentTask = currentMesh[Random.Range(0, currentMesh.Count)].GetComponent<CellBehavior>().cell.value;
                task.textTask.text = "Find " + task.currentTask;

                if (firstShow)
                {
                    task.StartShowTask();
                    firstShow = false;
                }
            }
        }
        else
        {
            buttons.ShowPanel();
        }
    }
}