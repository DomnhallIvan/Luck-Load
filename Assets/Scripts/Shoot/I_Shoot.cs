using UnityEngine;

public interface I_Shoot 
{

    public void NormalShoot(Vector3 firePointPosition, Vector3 fireDirection);
    void SecondaryShoot(Vector3 firePointPosition, Vector3 fireDirection);

}
