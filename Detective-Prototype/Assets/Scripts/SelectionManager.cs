using UnityEngine;
using TMPro;


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

    public bool gamePaused = false;             // public due to ThirdPersonMovement using this
    public GameObject dialogBox;                // Assigned in editor for enable/disable
    public TMP_Text textLabel;                  // Assigned in editor for assigning text


    private void Start()
    {
        dialogBox.SetActive(false);
    }


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

                // Assign a value to the text box based upon object

                if (selection.name == "Sphere")
                {
                    //Debug.Log("This is the sphere");
                    textLabel.text = "This is the sphere.";
                } else if (selection.name == "Capsule")
                {
                    //Debug.Log("This is the capsule");
                    textLabel.text = "This is the capsule.";
                } else if (selection.name == "Cylinder")
                {
                    //Debug.Log("This is the cylinder");
                    textLabel.text = "This is the cylinder.";
                }
                _selection = selection;
            }
        }


        // Added to pause the game while dialog box is present on-screen
        if (gamePaused == true)
        {
            Time.timeScale = 0.0f;
            dialogBox.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f;
            dialogBox.SetActive(false);
        }
    }
}
