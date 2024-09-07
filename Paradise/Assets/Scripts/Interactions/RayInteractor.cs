using UnityEngine;
using UnityEngine.UI;

public enum Mask
{
    INTERACTION,
    ETC
};

public class RayInteractor : MonoBehaviour
{
    [SerializeField] float rayDistance = 1.2f;
    [SerializeField] LayerMask[] layerMask;

    [SerializeField] Outline outLine;
    [SerializeField] GameObject mouseIcon;

    Ray ray;
    RaycastHit interactionHit;
    RaycastHit etcHit;

    void Update()
    {
        if (GameManager.Instance.State == false || CursorManager.interactable == false) return;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out interactionHit, rayDistance, layerMask[(int)Mask.INTERACTION]))
        {
            if (!Physics.Raycast(ray, out etcHit, rayDistance, layerMask[(int)Mask.ETC]) || interactionHit.distance < etcHit.distance)
            {
                mouseIcon.SetActive(true);

                outLine = interactionHit.collider.GetComponent<Outline>();

                if (outLine != null)
                {
                    outLine.enabled = true;
                }
                
                if (Input.GetMouseButtonDown(0))
                {
                    Interaction interaction = interactionHit.collider.gameObject.GetComponentInParent<Interaction>();

                    if (interaction != null) interaction.OnClick(interactionHit.collider);
                }
            }
            else
            {
                mouseIcon.SetActive(false);

                if (outLine != null)
                {
                    outLine.enabled = false;
                }
            }
        }
        else
        {
            mouseIcon.SetActive(false);

            if (outLine != null)
            {
                outLine.enabled = false;
            }
        }
    }
}
