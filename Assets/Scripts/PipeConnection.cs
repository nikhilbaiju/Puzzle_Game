using System.Collections;
using UnityEngine;

public class PipeConnection : MonoBehaviour
{
    public GameObject filledPipe;

    public Collider2D filledPipe_Col;

    private void Start()
    {
        filledPipe_Col = filledPipe.GetComponent<BoxCollider2D>(); 
        filledPipe_Col.enabled = false;
       
        filledPipe.SetActive(false); // Ensure the second child starts inactive
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("filled pipe"))
        {
            filledPipe.SetActive (true);
            StartCoroutine(EnableCollider());
        }
        else
        {
            // Ignore the collision for other tags
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision, true);
        }
    }

   
     private void OnTriggerExit2D(Collider2D collision)
     {
         if (collision.CompareTag("filled pipe"))
        {
            filledPipe.SetActive (false);
        }
        else
        {
            // Ignore the collision for other tags
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision, true);
        }
     }

    IEnumerator EnableCollider()
    {
        yield return new WaitForSeconds(1.5f);

        filledPipe_Col.enabled = true;
    }


}
