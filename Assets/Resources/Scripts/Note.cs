using UnityEngine;

public class Note : MonoBehaviour, ITriggerableMonoBehaviour
{
    public NoteData data;


    private void Awake()
    {
        if (data == null)
            Debug.LogError($"������� {gameObject.name} �� ����� ������");
    }

    public void Trigger(Transform obj)
    {
        if (obj.GetComponent<PlayerMovement>() == null) return;

        if (StaticGameData.AddNote(data))
            Debug.Log("Note: " + data.title + "\n" + "Text: " + data.text);
        else
            Debug.LogError("��� ������� ��� ���� ���������! " +
                "�������, ����� �� ���� ���������� (���� ������ ��� �� ���� ������� ����������)");
        gameObject.SetActive(false);
    }
}
