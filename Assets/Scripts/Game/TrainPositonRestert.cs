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
        if (train == null)
        {
            Debug.LogError("Train is not assigned in TrainPositonRestert.");
            return;
        }
        train.SetActive(false);
        train.transform.position = gameObject.transform.position;
        train.SetActive(true);
    }
}
