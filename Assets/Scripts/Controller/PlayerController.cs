using UnityEngine.EventSystems;
using UnityEngine;


[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour
{
    public Interactable focus;

    Camera cam;
    PlayerMotor motor;
    public float speed = 1.5f;

    public LayerMask movementMask;


    void Start()
    {

        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();

    }

    // Update is called once per frame
    void Update()
    {
        //Player is always facing the mouse;

        Plane playerPlane = new Plane(Vector3.up, transform.position);
        
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        float hitDist = 0.0f;

        if(playerPlane.Raycast(ray, out hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 7f * Time.deltaTime);

        }


        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }


        //Movement
        if (Input.GetMouseButton(0))
        {
           
            if(Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.MoveToPoint(hit.point);
                RemoveFocus();

            }

           

        }


        //Move and Interact
        if (Input.GetMouseButtonDown(1))
        {
           

            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if(interactable != null)
                {
                   
                    SetFocus(interactable);
                }
            }
        }

    }
        

    void SetFocus ( Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if(focus != null)
            {
                focus.OnDefocused();
            }
            
            focus = newFocus;
            motor.FollowTarget(newFocus);
        }
        
        newFocus.Onfocused(transform);
        
    }

    

    void RemoveFocus()
    {
        if (focus != null)
        {
            focus.OnDefocused();
        }
        
        focus = null;
        motor.StopFollowingTarget();
    }
}
