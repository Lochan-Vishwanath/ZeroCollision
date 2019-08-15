using UnityEngine;

public class bouncePlatform : MonoBehaviour
{
    Animator myanim;
    private void Start() {
        myanim=GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D coll){
        if(coll.transform.tag=="EnemyA"){
            DragwithMouse.cutoff=true;
            myanim.SetTrigger("bounce");
        }
    }
    //void OnTriggerExit2D(Collider2D other) {
    //    if(other.transform.tag=="EnemyA"){
    //        DragwithMouse.cutoff=false;
    //    }
    //}
}
