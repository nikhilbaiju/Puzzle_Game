using UnityEngine;

public class EndPipeConnection : MonoBehaviour
{
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("filled pipe"))
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision, true);
        }
        else if(collision.CompareTag("filled pipe"))
        {
            Debug.Log("WIN");
            GameEvent.OnEvent.Active_Win();
            
        }


    }
}
