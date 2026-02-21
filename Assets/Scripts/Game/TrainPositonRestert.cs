using UnityEngine;

public class TrainPositonRestert : MonoBehaviour
{
    [SerializeField]
    public GameObject train;
    private void OnEnable()
    {
        TrainReset();
    }
    public void TrainReset()
    {
        train.SetActive(false);
        train.transform.position = gameObject.transform.position;
        train.SetActive(true);
    }
}
