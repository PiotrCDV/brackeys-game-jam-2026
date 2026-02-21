using UnityEngine;

public class FadeInScreen : MonoBehaviour
{
    public static FadeInScreen Instance { get; private set; }

    private Animator _animator;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
            return;
        }

        Instance = this;


        _animator = GetComponent<Animator>();
    }

    public void PlayFadeIn()
    {
        if (_animator != null)
        {
            _animator.Play("fade_in");
        }
    
    }
}