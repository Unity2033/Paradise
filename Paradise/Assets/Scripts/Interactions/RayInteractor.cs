using UnityEngine;
using UnityEngine.UI;

public enum Mask
{
    MOUSE,
    MAGNIFIER,
    ETC
};

public class RayInteractor : MonoBehaviour
{
    [SerializeField] float rayDistance = 1.2f;
    [SerializeField] LayerMask[] layerMask;

    [SerializeField] Outline outLine;
    [SerializeField] GameObject mouseIcon;
    [SerializeField] GameObject magnifierIcon;

    Ray ray;
    RaycastHit interactionHit;
    RaycastHit etcHit;

    void Update()
    {
        if (GameManager.Instance.State == false || CursorManager.interactable == false) return;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out interactionHit, rayDistance, layerMask[(int)Mask.MOUSE]))
        {
            SwitchIcon(mouseIcon, interactionHit);
        }
        else if (Physics.Raycast(ray, out interactionHit, rayDistance, layerMask[(int)Mask.MAGNIFIER]))
        {
            SwitchIcon(magnifierIcon, interactionHit);
        }
        else
        {
            mouseIcon.SetActive(false);

            magnifierIcon.SetActive(false);

            if (outLine != null)
            {
                outLine.enabled = false;
            }
        }
    }

    void SwitchIcon(GameObject icon, RaycastHit hit)
    {
        if (!Physics.Raycast(ray, out etcHit, rayDistance, layerMask[(int)Mask.ETC]) || hit.distance < etcHit.distance)
        {
            icon.SetActive(true);

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
            icon.SetActive(false);

            if (outLine != null)
            {
                outLine.enabled = false;
            }
        }
    }
}
