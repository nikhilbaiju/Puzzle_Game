using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapPosition : MonoBehaviour
{
    public Vector3 initialPosition;
    SwapPosition otherSprite;
    private Vector3 offset;
    private bool isDragging = false;

    public Camera mainCamera;

    


    void Start()
    {
        initialPosition = transform.position;

        mainCamera = Camera.main;
        
    }

    private void OnMouseDown()
    {
        // Record the offset between the mouse position and the tile's position
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;

       

    }

    private void OnMouseUp()
    {
        if (isDragging)
        {
            // Check if we released the mouse over another sprite
            // RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,Mathf.Infinity,layerMask);
            //RaycastHit2D hit = Physics2D.Raycast(mainCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.NegativeInfinity);

            Vector2 raycastOrigin = transform.position;

            // Perform the hit test with a raycast from the object's position
            //RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, Vector2.zero,Mathf.Infinity);

            Vector2 boxSize = new Vector2(0.5f, 0.5f); // Adjust the size of the box as needed

            RaycastHit2D[] hits = Physics2D.BoxCastAll(raycastOrigin, boxSize, 0f, Vector2.zero);

            foreach (var hit in hits)
            {
                if (hit.collider != null && hit.collider.CompareTag("Tile") && hit.collider.gameObject != gameObject)
                {
                    Debug.Log("hit");
                    // Get the SpriteController component of the collided object
                    otherSprite = hit.collider.gameObject.GetComponent<SwapPosition>();

                    // Store the initial position of this sprite and the collided sprite
                    Vector3 thisInitialPosition = initialPosition;
                    Vector3 otherInitialPosition = otherSprite.initialPosition;


                    // Swap positions
                    otherSprite.transform.position = thisInitialPosition;
                    this.transform.position = otherInitialPosition;


                    StartCoroutine(ChangeInitialPosition());

                }
                if (hit.collider != null)
                {
                    Debug.Log(hit.collider.name);
                }
            }
               
            
        }
        isDragging = false;
    }
    private void Update()
    {
        // Only update the position if dragging
        if (isDragging)
        {
            // Calculate the new position based on the mouse position and offset
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            newPosition.z = transform.position.z; // Keep the same z position
            transform.position = newPosition;
        }

    }


  
    IEnumerator ChangeInitialPosition()
    {
        yield return new WaitForSeconds(.5f);
        // Update initial positions
        initialPosition = this.transform.position;
        otherSprite.initialPosition = otherSprite.transform.position;
    }
}
