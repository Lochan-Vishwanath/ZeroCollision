using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomMovement : MonoBehaviour {
    

    public Transform prefab;
    public RectTransform panel;
	Transform destination;
	public float speed=0.8f;
    //public float Xpos, Ypos;
    Vector3 RandPosition;
    int randnum;

	void Start () {
		Spawnobj();
        
	}
	
	
	void Update () {
        transform.position=Vector2.MoveTowards(transform.position,destination.position,speed*Time.deltaTime);

		if(Vector2.Distance(destination.position,transform.position)==0){
			Destroy(destination.gameObject);
			Spawnobj();
		}
	}

	void Spawnobj(){

        randnum = Random.Range(1,4);
        switch (randnum)
        {
            case 1:
                RandPosition = Camera.main.ViewportToWorldPoint(new Vector3(0.1f, Random.Range(0.2f,0.8f), Camera.main.farClipPlane / 2));
                //RandPosition = Camera.main.ScreenToWorldPoint(new Vector3(30, Random.Range(90, Screen.height - 90), Camera.main.farClipPlane / 2));
                break;
            case 2:
                RandPosition = Camera.main.ViewportToWorldPoint(new Vector3(0.9f, Random.Range(0.2f, 0.8f), Camera.main.farClipPlane / 2));
                //RandPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 30, Random.Range(90, Screen.height - 90), Camera.main.farClipPlane / 2));
                break;
            case 3:
                RandPosition = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0.1f, 0.9f), 0.2f , Camera.main.farClipPlane / 2));
                //RandPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(30, Screen.width - 30), Screen.height - 90, Camera.main.farClipPlane / 2));
                break;
            case 4:
                RandPosition = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0.1f, 0.9f), 0.8f, Camera.main.farClipPlane / 2));
                //RandPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(30, Screen.width - 30), 90, Camera.main.farClipPlane / 2));
                break;
        }

        destination = Instantiate(prefab, RandPosition , Quaternion.identity).GetComponent<Transform>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "GOD") {
            Destroy(gameObject);
            ColoursScript.no_of_objs--;
            AudioManager.playaudiogood = true;
        }

        if (collision.transform.tag == "EnemyA")
        {
            SpriteRenderer renderer = collision.gameObject.GetComponent<SpriteRenderer>();
            if (renderer.color.Equals(GetComponent<SpriteRenderer>().color))
            {
                    Destroy(gameObject);
                    ColoursScript.no_of_objs--;
                    Destroy(collision.gameObject);
                    AudioManager.playaudiogood = true;
            }
            else
            {
                panel.gameObject.SetActive(true);
                AudioManager.playaudiogameover = true;
                speed = 0f;
            }
        }
    }
}
