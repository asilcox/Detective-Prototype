using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField]
    private string selectableTag = "Selectable";
    [SerializeField]
    private Material selectedMaterial;
    [SerializeField]
    private Material defaultMaterial;

    [SerializeField]
    private ThirdPersonMovement player;

    private Transform _selection;

    public bool gamePaused = false;
    void Update()
    {
        
        
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;

            if (Input.GetKeyDown(KeyCode.Space ))
            {
                if (gamePaused == false)
                {
                    gamePaused = true;
                }
                else
                {
                    gamePaused = false;
                }
            }
        }

        Ray ray = new Ray(player.transform.position, player.transform.forward);//Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawLine(ray.origin, ray.direction * 10);
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = selectedMaterial;
                }
                _selection = selection;
            }
        }

        if (gamePaused == true)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }
}
