using UnityEngine;

public enum Mask
{
    INTERACTION,
    ETC
};

public class RayInteractor : MonoBehaviour
{
    [SerializeField] float rayDistacne = 1.2f;
    [SerializeField] LayerMask [] layerMask;

    Ray ray;
    RaycastHit raycastHit;

    void Start()
    {
        CursorManager.ActiveMouse(false, CursorLockMode.Locked);
    }

    private void Update()
    {
        if (CursorManager.interactable == false) return;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out raycastHit, rayDistacne, layerMask[(int)Mask.INTERACTION]))
        {
            Cursor.visible = true;

            if (Input.GetMouseButtonDown(0))
            {
                Interaction interaction = raycastHit.collider.gameObject.GetComponentInParent<Interaction>();

                if (interaction != null) interaction.OnClick(raycastHit.collider);
            }
        }
        else Cursor.visible = false;
    }
}
