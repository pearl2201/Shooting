using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Serializable]
public class DataGun : AbstractItem
{
    public int damage;
    public int firerate;
    public int accuracy;
    public int totalBullet;
    public int noBulletPerCharge;
    public int noBulletPerBought;
    public int costBulletPerBought;

}

