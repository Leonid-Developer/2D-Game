using UnityEngine;
public class SpawnBonus : MonoBehaviour
{
    private float startTime = 1;
    private float time = 0.3f;

    public GameObject bonusSquare;

    private bool bonus = false;

    private void Update()
    {
        if(startTime > 0)
        {
            startTime -= time * Time.deltaTime;
        }
        if(startTime <= 0)
        {
            print("EEEEEEE");
            bonus = true;
            startTime = 1;
        }
        if (bonus)
        {
            bonus = false;
            SpawBonus();
        }
    }

    public void SpawBonus()
    {
        Instantiate(bonusSquare);
    }
}

