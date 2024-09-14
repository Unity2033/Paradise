using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LockPattern : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject linePrefab;
    [SerializeField] GameObject clearImage;
    [SerializeField] GameObject failImage;
    [SerializeField] PlayPuzzle parents;

    private Dictionary<int, CircleId> circles;

    private List<CircleId> lines;
    private Image lineImage;

    private GameObject lineOnEdit;
    private RectTransform lineOnEditRcTs;
    private CircleId circleOnEdit;

    private List<int> rightPattern;
    private List<int> myPattern;

    private bool unlocking;
    private bool block;

    void Start()
    {
        parents = GameObject.Find("FOB_LOD").transform.Find("Windows").transform.Find("phone1k").GetComponent<PlayPuzzle>();
        if (parents.clear)
        {
            ClearGame();
            return;
        }

        rightPattern = new List<int> { 2, 4, 8, 9, 5, 7 };
        myPattern = new List<int>();

        circles = new Dictionary<int, CircleId>();
        lines = new List<CircleId>();

        for (int i = 0; i < transform.childCount; i++)
        {
            var circle = transform.GetChild(i);

            var circleID = circle.GetComponent<CircleId>();

            circleID.id = i;

            circles.Add(i, circleID);
        }

        clearImage.SetActive(false);
        failImage.SetActive(false);
    }

    void Update()
    {
        if (block) return;

        if (unlocking)
        {
            Vector3 mousePos = canvas.transform.InverseTransformPoint(Input.mousePosition);

            lineOnEditRcTs.sizeDelta =
                new Vector2(lineOnEditRcTs.sizeDelta.x, Vector3.Distance(mousePos, circleOnEdit.transform.localPosition));
            lineOnEditRcTs.rotation =
                Quaternion.FromToRotation(Vector3.up, (mousePos - circleOnEdit.transform.localPosition).normalized);
        }
    }

    public GameObject CreateLine(Vector3 position, int id)
    {
        var line = GameObject.Instantiate(linePrefab, canvas.transform);

        line.transform.position = position;

        var lineID = line.AddComponent<CircleId>();

        lineID.id = id;

        lines.Add(lineID);

        return line;
    }

    public void TrySetLineEdit(CircleId circle)
    {
        foreach (var line in lines)
        {
            if (line.id == circle.id)
            {
                return;
            }
        }

        lineOnEdit = CreateLine(circle.transform.position, circle.id);
        lineOnEditRcTs = lineOnEdit.GetComponent<RectTransform>();
        circleOnEdit = circle;
        myPattern.Add(circle.id + 1);
    }

    public void OnMouseEnterCircle(CircleId idf)
    {
        if (block) return;

        if (unlocking)
        {
            lineOnEditRcTs.sizeDelta = new Vector2(lineOnEditRcTs.sizeDelta.x, Vector3.Distance(circleOnEdit.transform.localPosition, idf.transform.localPosition));
            lineOnEditRcTs.rotation = Quaternion.FromToRotation(Vector3.up, (idf.transform.localPosition - circleOnEdit.transform.localPosition).normalized);

            TrySetLineEdit(idf);
        }
    }
    public void OnMouseExitCircle(CircleId cID)
    {
        if (block) return;

    }
    public void OnMouseDownCircle(CircleId cID)
    {
        if (block) return;

        unlocking = true;

        TrySetLineEdit(cID);
    }
    public void OnMouseUpCircle(CircleId cID)
    {
        if (block) return;

        unlocking = false;

        Destroy(lines[lines.Count - 1].gameObject);
        lines.RemoveAt(lines.Count - 1);

        if (Enumerable.SequenceEqual(rightPattern, myPattern))
        {
            RemovePattern();

            ClearGame();

            return;
        }

        StartCoroutine(IERelease());
    }
    public void ChangeColor(Color color)
    {
        foreach (var circle in circles)
        {
            circle.Value.ImageChange(color);
        }

        foreach (var line in lines)
        {
            lineImage = line.GetComponent<Image>();

            lineImage.color = color;
        }
    }

    public void RemovePattern()
    {
        foreach (var line in lines)
        {
            Destroy(line.gameObject);
        }

        lines.Clear();
        myPattern.Clear();

        lineOnEdit = null;
        lineOnEditRcTs = null;
        circleOnEdit = null;
    }

    private IEnumerator IERelease()
    {
        block = true;

        failImage.SetActive(true);

        ChangeColor(Color.red);

        yield return new WaitForSeconds(2f);

        failImage.SetActive(false);

        ChangeColor(Color.green);

        RemovePattern();

        block = false;
    }

    private void ClearGame()
    {
        parents.clear = true;
        clearImage.SetActive(true);
    }
}
