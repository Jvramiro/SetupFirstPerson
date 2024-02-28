using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteraction{
    void Interact();
}

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float distance = 5f;
    [SerializeField] private bool debugRay;
    private GameObject focus;

    void FixedUpdate(){
        RaycastHit hit;
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distance);
        if(hit.collider != null){
            if(focus != hit.collider.gameObject){
                SetOutline(focus, false);
                focus = hit.collider.gameObject;
                SetOutline(focus, true);
            }
        }
        else{
            if(focus != null){
                SetOutline(focus, false);
                focus = null;
            }
        }
        if(debugRay)
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * distance, Color.blue);
    }

    void SetOutline(GameObject gameObject, bool value){
        if(gameObject == null) return;
        if(gameObject.TryGetComponent(out Outline focusOutline)) focusOutline.enabled = value;
    }

    public void Interact(){
        RaycastHit hit;
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distance);
        if(hit.collider != null){
            if(hit.collider.TryGetComponent(out IInteraction interaction))
                interaction.Interact();
        }
    }

}
