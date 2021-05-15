using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject player;
    public bool isGamePasued;
    public Transform[] target;
    public GameObject pauseMenu;
    public Text totalNumber;
    int spawnedCubeNumber = 0;

    private void Start()
    {

        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            spawnObject();
        }

        totalNumber.text = "Total Cube : " + spawnedCubeNumber;

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isGamePasued)
            {
                resumeGame();
            }
            else
            {
                pauseGame();
            }
        }
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
        isGamePasued = true;
        pauseMenu.SetActive(true);
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
        isGamePasued = false;
        pauseMenu.SetActive(false);
    }

    public void spawnObject()
    {
        GameObject playerOBJ = Instantiate(player);
        playerOBJ.GetComponent<PlayerMovement>().target = target;
        spawnedCubeNumber += 1;
    }

}
