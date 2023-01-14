using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashOBJ : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Sprite[] objImage;

    Image image;

    [SerializeField] TrashType TrashType;

    void Start()
    {
        image = GetComponent<Image>();

        int randomNumber = Random.Range(0, objImage.Length);
        image.sprite = objImage[randomNumber];
    }

    public TrashType GetTrashType()
    { 
        return TrashType; 
    }


}
