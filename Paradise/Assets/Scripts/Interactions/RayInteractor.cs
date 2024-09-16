using UnityEngine;

public enum Mask
{
    INTERACTION,
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
    RaycastHit mouseHit;
    RaycastHit magnifierHit;
    
    void Update()
    {
        if (GameManager.Instance.State == false || CursorManager.interactable == false) return;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out interactionHit, rayDistance, layerMask[(int)Mask.INTERACTION]))
        {
            switch (interactionHit.collider.gameObject.layer)
            {
                case 7: SwitchIcon(magnifierIcon, interactionHit);
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
                if (mouseIcon.activeSelf && magnifierIcon.activeSelf)
                {
                    Physics.Raycast(ray, out mouseHit, rayDistance, layerMask[(int)Mask.MOUSE]);
                    Physics.Raycast(ray, out magnifierHit, rayDistance, layerMask[(int)Mask.MAGNIFIER]);

                    if (mouseHit.distance < magnifierHit.distance)
                    {
                        magnifierIcon.SetActive(false);
                        hit = mouseHit;
                    }
                    else
                    {
                        mouseIcon.SetActive(false);
                        hit = magnifierHit;
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

        magnifierIcon.SetActive(false);

        if (outLine != null)
        {
            outLine.enabled = false;
        }
    }
}
