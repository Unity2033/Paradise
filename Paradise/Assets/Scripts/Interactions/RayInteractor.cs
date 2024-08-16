using UnityEngine;

public enum Mask
{
    INTERACTION,
    ETC
};

public class RayInteractor : MonoBehaviour
{
    [SerializeField] CursorController cursorController;
    [SerializeField] float rayDistacne = 1.2f;
    [SerializeField] LayerMask [] layerMask;

    Ray ray;
    RaycastHit raycastHit;

    void Update()
    {
        if (CursorManager.interactable == false)
        {
            cursorController.SelectCursor(false);
            return;
        }

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out raycastHit, rayDistacne, layerMask[(int)Mask.INTERACTION]))
        {
            cursorController.SelectCursor(false, true);

            if (Input.GetMouseButtonDown(0))
            {
                Interaction interaction = raycastHit.collider.gameObject.GetComponentInParent<Interaction>();

                if (interaction != null) interaction.OnClick(raycastHit.collider);
            }
        }
        else cursorController.SelectCursor(true);
    }
}
