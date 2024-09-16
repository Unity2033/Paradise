using UnityEngine;

public enum Mask
{
    INTERACTION,
    MOUSE,
    EYE,
    ETC
};

public class RayInteractor : MonoBehaviour
{
    [SerializeField] float rayDistance = 1.2f;
    [SerializeField] LayerMask[] layerMask;

    [SerializeField] Outline outLine;

    [SerializeField] GameObject mouseIcon;
    [SerializeField] GameObject eyeIcon;

    Ray ray;

    RaycastHit interactionHit;
    RaycastHit etcHit;
    RaycastHit mouseHit;
    RaycastHit eyeHit;
    
    void Update()
    {
        if (GameManager.Instance.State == false || CursorManager.interactable == false) return;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out interactionHit, rayDistance, layerMask[(int)Mask.INTERACTION]))
        {
            switch (interactionHit.collider.gameObject.layer)
            {
                case 7: SwitchIcon(eyeIcon, interactionHit);
                    break;
                case 8: SwitchIcon(mouseIcon, interactionHit);
                    break;
            }
        }
        else Viewless();
    }

    void SwitchIcon(GameObject icon, RaycastHit hit)
    {
        if (!Physics.Raycast(ray, out etcHit, rayDistance, layerMask[(int)Mask.ETC]) || hit.distance < etcHit.distance)
        {
            icon.SetActive(true);
            
            try
            {
                if (mouseIcon.activeSelf && eyeIcon.activeSelf)
                {
                    Physics.Raycast(ray, out mouseHit, rayDistance, layerMask[(int)Mask.MOUSE]);
                    Physics.Raycast(ray, out eyeHit, rayDistance, layerMask[(int)Mask.EYE]);

                    if (mouseHit.distance < eyeHit.distance)
                    {
                        eyeIcon.SetActive(false);
                        hit = mouseHit;
                    }
                    else
                    {
                        mouseIcon.SetActive(false);
                        hit = eyeHit;
                    }
                }

                outLine = hit.collider.GetComponent<Outline>();

                if (outLine != null)
                {
                    outLine.enabled = true;
                }

                if (Input.GetMouseButtonDown(0))
                {
                    Interaction interaction = hit.collider.gameObject.GetComponentInParent<Interaction>();

                    if (interaction != null) interaction.OnClick(hit.collider);
                }
            }
            catch
            {
                Viewless();
            }
        }
        else Viewless();
    }

    void Viewless()
    {
        mouseIcon.SetActive(false);

        eyeIcon.SetActive(false);

        if (outLine != null)
        {
            outLine.enabled = false;
        }
    }
}
