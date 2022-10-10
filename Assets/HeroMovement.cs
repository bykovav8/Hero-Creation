using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    public float speed = 20f;
    public float rotateSpeed = 20f;
    // control mode
    private bool mode = false;
    public GameObject prefab;
    private bool shoot = true; 

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update() // called around 60 times a second
    {
        
        // mouse control   
        if(Input.GetKeyDown("m"))
        {
            mode = !mode;
        }

        if(mode) //mouse
        {
            Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            p.z = 0f; 
            transform.position = p;
        }
        else // keyboard - w/s
        {
            speed += Input.GetAxis("Vertical");
            transform.position += transform.up * speed * Time.smoothDeltaTime;
        }
        transform.Rotate(Vector3.forward, -1f * Input.GetAxis("Horizontal") * (rotateSpeed * Time.smoothDeltaTime));


        if(Input.GetKey(KeyCode.Space))
        {
            if(shoot)
            {
                StartCoroutine(SpawnPrefab());
            }
            
        }
    }
    protected IEnumerator SpawnPrefab()
    {
        shoot = false;
        GameObject spawnedEgg = Instantiate(prefab);
        spawnedEgg.transform.up = this.transform.up;
        spawnedEgg.transform.position = this.transform.position;
        yield return new WaitForSeconds(.2f);
        shoot = true;
    }

}
