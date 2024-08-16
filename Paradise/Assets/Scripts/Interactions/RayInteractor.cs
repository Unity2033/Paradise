using UnityEngine;

public enum Mask
{
    INTERACTION,
    ETC
};

public class RayInteractor : MonoBehaviour
{
    [SerializeField] GameObject defalutCursor;
    [SerializeField] GameObject interactiveCursor;

    [SerializeField] float rayDistacne = 1.2f;
    [SerializeField] LayerMask [] layerMask;

    Ray ray;
    RaycastHit raycastHit;

    private void Update()
    {
        if (CursorManager.interactable == false)
        {
            SelectCursor(false);
            return;
        }

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SelectCursor(true);
        }

        if (Physics.Raycast(ray, out raycastHit, rayDistacne, layerMask[(int)Mask.INTERACTION]))
        {
            SelectCursor(false, true);

            if (Input.GetMouseButtonDown(0))
            {
                Interaction interaction = raycastHit.collider.gameObject.GetComponentInParent<Interaction>();

                if (interaction != null) interaction.OnClick(raycastHit.collider);
            }
        }
        else SelectCursor(true);
    }

    void SelectCursor(bool defaultCursor, bool interactiveCursor = false)
    {
        this.defalutCursor.SetActive(defaultCursor);
        this.interactiveCursor.SetActive(interactiveCursor);
    } 
}
