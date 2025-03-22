using System.Collections.Generic;

public class EggModelPool
{
    public Queue<Egg> lstModelEgg;
    public int sizeEggModelPool = 10;
    public int index = 0;

   public EggModelPool()
   {
        lstModelEgg = new Queue<Egg>();
        for (int i = 0; i < sizeEggModelPool; i++)
        {
            Egg eggModel = new Egg();
            eggModel.InitEggModel();
            lstModelEgg.Enqueue(eggModel);
        }
   }

    public Egg GetEggModel()
    {
        if (lstModelEgg.Count > 0)
        {
            Egg eggModel = lstModelEgg.Dequeue();
            eggModel.InitEggModel();
            return eggModel;
        }
        else
        {
            Egg eggModel = new Egg();
            eggModel.InitEggModel();
            return eggModel;
        }
    }

    public void ReturnObject(Egg eggModel)
    {
        eggModel.InitEggModel();
        lstModelEgg.Enqueue(eggModel);
    }
}
