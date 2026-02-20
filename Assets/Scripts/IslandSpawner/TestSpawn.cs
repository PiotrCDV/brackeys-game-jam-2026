using System.Threading.Tasks;
using UnityEngine;

public class TestSpawn : MonoBehaviour
{
    [SerializeField]
    private IslandMenager islandMenager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        islandMenager.RoundStart();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    
}
