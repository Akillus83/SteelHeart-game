using UnityEngine;

public class Coin : MonoBehaviour, ITriggerableMonoBehaviour
{
    public int worth = 1;

    public void Trigger(Transform obj)
    {
        var player = obj.GetComponent<PlayerCoinHolder>();
        if (player == null) return;

        player.coins += worth;
        if (player.coins >= 100)
        {
            Debug.LogWarning("����� ����������� ��� ��������� 100 �����, �� ���� �������� ����� ����������. " +
                             "��������, ����� ������� ��� �� ������� �����");
            player.coins %= 100;
            player.additional_lives += 1;
        }

        gameObject.SetActive(false);
    }
}
