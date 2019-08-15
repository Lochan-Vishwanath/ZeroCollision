using UnityEngine;

public class turnoffhandanimation : MonoBehaviour
{
    public GameObject hand,obj;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyA" && obj.activeInHierarchy)
        {
            //Debug.Log("active");
            hand.SetActive(false);
        }
    }
    
    
}
