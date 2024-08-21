using UnityEngine;

public enum Mask
{
    INTERACTION,
    ETC
};

public class RayInteractor : MonoBehaviour
{
    [SerializeField] CursorController cursorController;
    [SerializeField] float rayDistance = 1.2f;
    [SerializeField] LayerMask[] layerMask;

    Ray ray;
    RaycastHit interactionHit;
    RaycastHit etcHit;

    void Update()
    {
        if (GameManager.Instance.State == false)
        {
            cursorController.SelectCursor(false);
            return;
        }

        if (CursorManager.interactable == false)
        {
            cursorController.SelectCursor(false);
            return;
        }

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out interactionHit, rayDistance, layerMask[(int)Mask.INTERACTION]))
        {
            if (!Physics.Raycast(ray, out etcHit, rayDistance, layerMask[(int)Mask.ETC]) || interactionHit.distance < etcHit.distance)
            {
                cursorController.SelectCursor(false, true);

                if (Input.GetMouseButtonDown(0))
                {
                    Interaction interaction = interactionHit.collider.gameObject.GetComponentInParent<Interaction>();

                    if (interaction != null) interaction.OnClick(interactionHit.collider);
                }
            }
            else cursorController.SelectCursor(true);
        }
        else cursorController.SelectCursor(true);
    }
}
