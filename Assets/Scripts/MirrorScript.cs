using UnityEngine;

public class MirrorScript : PortalScript
{
    public override void Interact()
    {
        base.Interact();
        GameController.instance.isMirrored = !GameController.instance.isMirrored;
        GameController.instance.isPortable = false;
        Invoke("ResetIsPortable", 3F);
    }

    public void ResetIsPortable()
    {
        GameController.instance.isPortable = true;
    }
}
