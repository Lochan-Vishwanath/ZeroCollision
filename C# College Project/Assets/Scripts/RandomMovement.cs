using UnityEngine;

public class RandomMovement : MonoBehaviour {

    public GameObject[] sprite;
    public Transform prefab;
    //public 
    
	Transform destination;
	public float speed=0.8f;
    //public float Xpos, Ypos;
    Vector3 RandPosition;
    int randnum;
    public GameObject ParticleEffectOBJ;
    GameObject[] objs;
    //RippleEffect RippleEffectOBJ;
    public AudioManager au;
    ScreenShake ss;
    public static bool notPaused = true;

	void Start () {
        //RippleEffectOBJ = GameObject.Find("Main/Main Camera").GetComponent<RippleEffect>();
        notPaused = true;
        ss = Camera.main.GetComponent<ScreenShake>();
		Spawnobj();
        objs = GameObject.FindGameObjectsWithTag("EnemyA");
	}
	
	
	void Update () {
        if(notPaused)
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
                RandPosition = Camera.main.ViewportToWorldPoint(new Vector3(0.1f, Random.Range(0.12f,0.88f), Camera.main.farClipPlane / 2));
                //RandPosition = Camera.main.ScreenToWorldPoint(new Vector3(30, Random.Range(90, Screen.height - 90), Camera.main.farClipPlane / 2));
                break;
            case 2:
                RandPosition = Camera.main.ViewportToWorldPoint(new Vector3(0.86f, Random.Range(0.12f, 0.88f), Camera.main.farClipPlane / 2));
                //RandPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 30, Random.Range(90, Screen.height - 90), Camera.main.farClipPlane / 2));
                break;
            case 3:
                RandPosition = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0.1f, 0.86f), 0.12f , Camera.main.farClipPlane / 2));//14 16:9
                //RandPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(30, Screen.width - 30), Screen.height - 90, Camera.main.farClipPlane / 2));
                break;
            case 4:
                RandPosition = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0.1f, 0.86f), 0.88f, Camera.main.farClipPlane / 2));//82 16:9
                //RandPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(30, Screen.width - 30), 90, Camera.main.farClipPlane / 2));
                break;
        }

        destination = Instantiate(prefab, RandPosition , Quaternion.identity).GetComponent<Transform>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "GOD") {
            ColoursScript.no_of_objs--;
            AudioManager.playaudiogood = true;
            ss.shakeScreen();
            //Destroy(gameObject,au.good.length);
            Destroy(gameObject);
            GameObject splater = Instantiate(sprite[Random.Range(0,sprite.Length)],transform.position,Quaternion.Euler(0,0,Random.Range(0,360)));
            splater.GetComponent<SpriteRenderer>().color=GetComponent<SpriteRenderer>().color;
        }

        if (collision.transform.tag == "EnemyA")
        {
            SpriteRenderer renderer = collision.gameObject.GetComponent<SpriteRenderer>();
            if (renderer.color.Equals(GetComponent<SpriteRenderer>().color))
            {
                //RippleEffectOBJ.RippleMain();
                //RippleEffectOBJ.rippleNow();
                GameObject splater = Instantiate(sprite[Random.Range(0,sprite.Length)],transform.position,Quaternion.Euler(0,0,Random.Range(0,360)));
                splater.GetComponent<SpriteRenderer>().color=renderer.color;
                AudioManager.playaudiogood = true;
                ColoursScript.no_of_objs--;
                ss.shakeScreen();
                Destroy(collision.gameObject);
                Destroy(gameObject,au.good.length);
                CancelInvoke();
                //StartCoroutine(au.playgood());  
            }
            else
            {
                ss.shakeScreenHard();
                foreach (GameObject obj in objs)
                {
                    if(obj==null) continue;
                    obj.GetComponent<RandomMovement>().speed=0;
                }
                //if(!GameObject.Find("ParticleEffectOBJ"))
                Instantiate(ParticleEffectOBJ, transform.position,Quaternion.identity);
                //x.transform.position = transform.position;
                //StartCoroutine(wait());
                ColoursScript.GameOver = true;
                AudioManager.playaudiogameover = true;
                //StartCoroutine(au.playGameover());                                                                          
                StageLoad.stageloading = false;
                //DragwithMouse.takemouseinput=false;
                //Dragable.taketouchinput=false;
                CancelInvoke();
                speed = 0f;
                gameObject.SetActive(false);
            }
        }
    }
   
}
/* if(nextPanel.gameObject.activeInHierarchy){
            foreach (GameObject obj in objs)
            {
                obj.GetComponent<RandomMovement>().speed=0;
            }
        }
        */