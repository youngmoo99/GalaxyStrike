using UnityEngine;

public class Enemy : MonoBehaviour
{   
    [SerializeField] GameObject destroyedVFX;
    void OnParticleCollision(GameObject other) //Non-trigger 콜라이더가있는 게임오브젝트에 부착될때 호출
    {   
        Instantiate(destroyedVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
