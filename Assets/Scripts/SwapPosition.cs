using System.Collections;
using UnityEngine;

public class SwapPosition : MonoBehaviour
{
    public Vector3 initialPosition;
    private Vector3 offset;

    SwapPosition otherSprite;

    private bool isDragging = false;
    


    void Start()
    {
        initialPosition = transform.position;
        
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
          
            Vector2 raycastOrigin = transform.position;

            Vector2 boxSize = new Vector2(0.5f, 0.5f); // Adjust the size of the box as needed

            RaycastHit2D[] hits = Physics2D.BoxCastAll(raycastOrigin, boxSize, 0f, Vector2.zero);

            foreach (var hit in hits)
            {
                if (hit.collider != null && hit.collider.CompareTag("Tile") && !hit.collider.CompareTag("background") && hit.collider.gameObject != gameObject)
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
                else if(hit.collider != null && hit.collider.CompareTag("background") && hit.collider.gameObject != gameObject)
                {
                    Debug.Log("Outside");
                    this.transform.position = initialPosition;
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
