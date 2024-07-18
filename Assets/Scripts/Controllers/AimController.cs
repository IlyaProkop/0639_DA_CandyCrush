using UnityEngine;
using UnityEngine.UI;

public class AimController : MonoBehaviour
{
    [SerializeField] Image image;
    private NormalItem.eNormalType currentType;
    public void OnEnable()
    {
        SetType();
    }
    private void SetType()
    {
        currentType = Utils.GetRandomNormalType();
        switch (currentType)
        {
            case NormalItem.eNormalType.TYPE_ONE:
                image.sprite = Resources.Load<GameObject>(Constants.PREFAB_NORMAL_TYPE_ONE).GetComponent<SpriteRenderer>().sprite;
                break;
            case NormalItem.eNormalType.TYPE_TWO:
                image.sprite = Resources.Load<GameObject>(Constants.PREFAB_NORMAL_TYPE_TWO).GetComponent<SpriteRenderer>().sprite;
                break;
            case NormalItem.eNormalType.TYPE_THREE:
                image.sprite = Resources.Load<GameObject>(Constants.PREFAB_NORMAL_TYPE_THREE).GetComponent<SpriteRenderer>().sprite;
                break;
            case NormalItem.eNormalType.TYPE_FOUR:
                image.sprite = Resources.Load<GameObject>(Constants.PREFAB_NORMAL_TYPE_FOUR).GetComponent<SpriteRenderer>().sprite;
                break;
            case NormalItem.eNormalType.TYPE_FIVE:
                image.sprite = Resources.Load<GameObject>(Constants.PREFAB_NORMAL_TYPE_FIVE).GetComponent<SpriteRenderer>().sprite;
                break;
            case NormalItem.eNormalType.TYPE_SIX:
                image.sprite = Resources.Load<GameObject>(Constants.PREFAB_NORMAL_TYPE_SIX).GetComponent<SpriteRenderer>().sprite;
                break;
            case NormalItem.eNormalType.TYPE_SEVEN:
                image.sprite = Resources.Load<GameObject>(Constants.PREFAB_NORMAL_TYPE_SEVEN).GetComponent<SpriteRenderer>().sprite;
                break;
            default:
                break;
        }
    }
    public bool Check(NormalItem.eNormalType type)
    {
        bool result = currentType == type;
        if (result) SetType();

        return result;
    }
}
