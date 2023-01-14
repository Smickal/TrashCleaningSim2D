using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashCan : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Sprite closedTrash;
    [SerializeField] Sprite openedTrash;

    [SerializeField] TrashType type;

    TakeGarbage takeGarbage;
    Image image;
    private void Start()
    {
        image = GetComponent<Image>();
        takeGarbage = GetComponentInParent<TakeGarbage>();
        image.sprite = closedTrash;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        image.sprite = openedTrash;
        TrashOBJ trash = collision.GetComponent<TrashOBJ>();

        TrashType trashType = trash.GetTrashType();


        //Debug.Log(trashType);

        if(type == trashType)
        {
            //Accept Trash
            takeGarbage.IncreaseGarbageCounted();
            Destroy(collision.gameObject, 0.2f);
            StartCoroutine(AcceptTrash());

        }
        else
        {
            //Denied Trash
            collision.GetComponent<DragBehaviour>().ResetPosition();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        image.sprite = closedTrash;
    }

    IEnumerator AcceptTrash()
    {
        yield return new WaitForSeconds(0.5f);
        image.sprite = closedTrash;
    }
}
