using UnityEngine;

public class Example : MonoBehaviour
{
  void Start()
  {
    StartCoroutine(FindObjectOfType<SubtitleDisplayer>().Begin());
  }
}
