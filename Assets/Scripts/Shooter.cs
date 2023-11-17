using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 簡単な飛び道具発射クラス
/// </summary>
public class Shooter : MonoBehaviour
{
    [SerializeField] int _damage = 100;
    [SerializeField] float _power = 3.0f;
    [SerializeField] GameObject _shooter = null;
    
    protected void Shot(Vector3 dir)
    {
        Vector3 muzzle = default;
        if (dir == Vector3.zero) muzzle = transform.forward;
        if (dir == Vector3.up * 180) muzzle = -transform.forward;
        if (dir == Vector3.up * -90) muzzle = -transform.right;
        if (dir == Vector3.up * 90) muzzle = transform.right;

        var shotObj = Instantiate(_shooter, transform.position + muzzle * 2, transform.rotation);
        shotObj.transform.eulerAngles = dir;
        var hitCtrl = shotObj.GetComponent<HitCtrl>();
        hitCtrl.SetParameter(_damage, _power);
    }
}
