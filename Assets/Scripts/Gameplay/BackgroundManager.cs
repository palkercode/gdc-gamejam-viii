using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private GameObject gradient;
    [SerializeField] private Camera cam;

    public void ChangeBackgroundAnimation(string name)
    {
        cam.GetComponent<Animator>().Play(name);
    }
}
