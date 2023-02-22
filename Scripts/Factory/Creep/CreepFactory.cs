using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepFactory : EnemyFactory
{
    public override void CreateBoss()
    {
        throw new System.NotImplementedException();
    }

    public override void CreateCreepDanhGan()
    {
        var portalTransformposition = portalTransform.transform.position;
        var fastCreepGameObject = Resources.Load("Prefab/FastCreep") as GameObject;
        if (fastCreepGameObject != null)
        {
            var fastCreep = Instantiate(
                fastCreepGameObject.transform,
                new Vector3(
                    portalTransformposition.x,
                    portalTransformposition.y,
                    portalTransformposition.z
                ),
                Quaternion.identity
            );
        }
        else
        {
            throw new System.ArgumentException("Prefab does not exist.");
        }
    }

    public override void CreateCreepDanhXa()
    {
        var portalTransformposition = portalTransform.transform.position;
        var fastCreepGameObject = Resources.Load("Prefab/FastCreep") as GameObject;
        if (fastCreepGameObject != null)
        {
            var fastCreep = Instantiate(
                fastCreepGameObject.transform,
                new Vector3(
                    portalTransformposition.x,
                    portalTransformposition.y,
                    portalTransformposition.z
                ),
                Quaternion.identity
            );
        }
        else
        {
            throw new System.ArgumentException("Prefab does not exist.");
        }
    }

    public override void CreateCreepGiap()
    {
        var portalTransformposition = portalTransform.transform.position;
        var fastCreepGameObject = Resources.Load("Prefab/FastCreep") as GameObject;
        if (fastCreepGameObject != null)
        {
            var fastCreep = Instantiate(
                fastCreepGameObject.transform,
                new Vector3(
                    portalTransformposition.x,
                    portalTransformposition.y,
                    portalTransformposition.z
                ),
                Quaternion.identity
            );
        }
        else
        {
            throw new System.ArgumentException("Prefab does not exist.");
        }
    }

    public override void CreateCreepKing()
    {
        var portalTransformposition = portalTransform.transform.position;
        var fastCreepGameObject = Resources.Load("Prefab/FastCreep") as GameObject;
        if (fastCreepGameObject != null)
        {
            var fastCreep = Instantiate(
                fastCreepGameObject.transform,
                new Vector3(
                    portalTransformposition.x,
                    portalTransformposition.y,
                    portalTransformposition.z
                ),
                Quaternion.identity
            );
        }
        else
        {
            throw new System.ArgumentException("Prefab does not exist.");
        }
    }

    public override void CreateCreepThaBoom()
    {
        var portalTransformposition = portalTransform.transform.position;
        var fastCreepGameObject = Resources.Load("Prefab/FastCreep") as GameObject;
        if (fastCreepGameObject != null)
        {
            var fastCreep = Instantiate(
                fastCreepGameObject.transform,
                new Vector3(
                    portalTransformposition.x,
                    portalTransformposition.y,
                    portalTransformposition.z
                ),
                Quaternion.identity
            );
        }
        else
        {
            throw new System.ArgumentException("Prefab does not exist.");
        }
    }

    // Start is called before the first frame update

}
