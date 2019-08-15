using UnityEngine;

public class TutorialObj : MonoBehaviour
{
    public Animator myanimator;
    public GameObject hand;
    public string animationParameterName;

    private void OnMouseDown()
    {
        myanimator.SetBool(animationParameterName, true);
    }
}
