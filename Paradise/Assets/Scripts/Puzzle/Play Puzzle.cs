using UnityEngine;

public class PlayPuzzle : Interaction
{
    [SerializeField] GameObject puzzleObject;

    private GameObject puzzleObj;

    public override void OnClick(Collider puzzle)
    {
        puzzleObj = Instantiate(puzzleObject);
    }

    private void Update()
    {
        if (puzzleObj == null) return;

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(puzzleObj);
        }
    }
}
