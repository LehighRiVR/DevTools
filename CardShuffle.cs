using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardShuffle : MonoBehaviour
{
    //Make a list of Cards
    public List<GameObject> cards;

    GameObject picked = null;

    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine("SceneLoaded");   
    }

    void Update()
    {
        if (Input.anyKey)
        {
            Generator();
        }
    }

    public void Generator()
    {
        //Deactivate other GameObjects
        picked?.SetActive(false);

        // Get a random Card from the list of Card
        picked = cards[Random.Range(0, cards.Count)];

        // Activate only Randomly generated card
        picked.SetActive(true);
    }

    #region SCENE CHANGER

    public int sceneIndex;      

    IEnumerator SceneLoaded()
    {
        yield return new WaitForSeconds(10f);
        
        if(sceneIndex == 0)
        {
            SceneManager.LoadScene(sceneIndex + 1);   //Loads NEXT scene using the buildIndex number (int)
        }

        if (sceneIndex == 1)
        {
            SceneManager.LoadScene(0); //Loads SPECIFIC scene using the buildIndex number (int)

            //SceneManager.LoadScene("Scenes/SampleScene"); //Loads scene using the name/path of the scene file
        }        
    }

    #endregion
}