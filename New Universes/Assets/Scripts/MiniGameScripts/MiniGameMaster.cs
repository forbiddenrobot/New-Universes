using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using TMPro;


public class MiniGameMaster : MonoBehaviour
{
    public static float moneyMadeMiniGame;
    public TextMeshProUGUI moneyMadeText;

    private int NumEnemySpawning;

    private void Start()
    {
        moneyMadeMiniGame = 0;
        spawning = false;
        wave = 1;
    }

    public void UpdateMoneyMade()
    {
        moneyMadeText.text = "Money Made: " + moneyMadeMiniGame; 
    }

    [SerializeField] private List<Transform> spawners;
    [SerializeField] private List<GameObject> Enemys;
    private bool spawning;
    private int wave;

    IEnumerator Delay(float delay)
    {
        new WaitForSeconds(delay);
        yield return new WaitForSeconds(delay);
    }


    // 0 is Trident, 1 is Sniper, 2 is Carrier
    async void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0 && spawning == false)
        {
            spawning = true;
            if(wave == 1)
            {
                Spawn(1, 1);
                Spawn(1, 2);
                await Task.Delay(3000);
                Spawn(1, 3);
                Spawn(1, 4);
                await Task.Delay(5000);
                Spawn(0, 1);
            }
            else if(wave == 2)
            {
                Spawn(1, 4);
                Spawn(0, 3);
                Spawn(0, 1);
                await Task.Delay(5000);
                Spawn(2, 2);
            }
            else if(wave == 3)
            {
                Spawn(2, 1);
                Spawn(2, 2);
                Spawn(1, 3);
                Spawn(0, 4);
                await Task.Delay(5000);
                Spawn(0, 1);
            }
            else
            {
                NumEnemySpawning = Random.Range(wave - 2, wave + 2);
                for (int i = 0; i < NumEnemySpawning; i++)
                {
                    RandSpawn();
                    await Task.Delay(3000);
                }
            }
            wave++;
            spawning = false;
        }
        UpdateMoneyMade();
    }

    void Spawn(int enemy, int spawnNum)
    {
        if (spawners[spawnNum - 1] != null)
        {
            Instantiate(Enemys[enemy], spawners[spawnNum - 1].transform.position, Quaternion.identity);
        }
    }

    void RandSpawn()
    {
        Instantiate(Enemys[Random.Range(0, 3)], spawners[Random.Range(0, 4)].transform.position, Quaternion.identity);
    }
}
