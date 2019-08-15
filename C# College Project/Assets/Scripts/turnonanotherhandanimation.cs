using UnityEngine;

public class turnonanotherhandanimation : MonoBehaviour
{
    public GameObject hand1,hand2;
    private void Update()
    {
        if (!hand1.activeInHierarchy)
            hand2.SetActive(true);
    }


}
