using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject player;
    public Transform spawnPoint;
    public List<GameObject> skills;
    public GameObject ceiling;
    public GameObject floor;


    private Vector2 screenBounds;



    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(RegularSpawnItem(1));
    }

    // Update is called once per frame
    void Update()
    {
     
        if(player.transform.position.y <= floor.transform.position.y || player.transform.position.y >= ceiling.transform.position.y)
        {
            Debug.Log("przedupiłeś");
        }

    }


    private void SpawnItem()
    {
        //spawnPoint.position = new Vector3(player.position.x + Screen.width / 2, player.position.y, player.position.z);
        GameObject itemObject = Instantiate(skills[Random.Range(0, skills.Count)]) as GameObject;   

        itemObject.transform.position = new Vector3(player.transform.position.x + screenBounds.x * -2, Random.Range(ceiling.transform.position.y, floor.transform.position.y), player.transform.position.z);
        Destroy(itemObject, 6f);
    }

    IEnumerator RegularSpawnItem(float time)
    {
        while (true)
        {
            if(player.GetComponent<PlayerMovement>().state == "flying")
            {
                SpawnItem();
            }
            yield return new WaitForSeconds(time);
            
        }
        //player.GetComponent<PlayerMovement>().state == "flying"
    }

}
