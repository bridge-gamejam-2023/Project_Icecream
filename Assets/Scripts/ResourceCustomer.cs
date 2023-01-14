using UnityEngine;
using System.Collections.Generic;

public class ResourceCustomer : MonoBehaviour
{
    public Dictionary<BodyBaseType, List<(int, Sprite)>> Sprites { get; set; } 

    /// <summary>
    /// �մ��� BodyBaseType�� ���� �̹��� �ε�
    /// ������ �۾��ϱ� ���� Resources�� ���� �Űܼ� ���
    /// </summary>
    public void LoadResources()
    {
        Sprites = new Dictionary<BodyBaseType, List<(int, Sprite)>>();

        var dataList = DataManager.Instance.InGameData.customerTypeEntityList;

        foreach (var data in dataList)
        {
            var resource = Resources.Load<Sprite>($"customer/{data.BodyType}_{data.BodyBaseType}_{data.Index}");
            if (resource != null)
            {
                if (!Sprites.ContainsKey(data.BodyBaseType))
                {
                    Sprites.Add(data.BodyBaseType, new List<(int, Sprite)>());
                }

                Sprites[data.BodyBaseType].Add((data.Index, resource));
            }
        }
    }
}
