using UnityEngine;

public class MDB : MonoBehaviour
{
    private int[,] map15 = new int[,]
{
    { 0, 0, 0, 1, 1 },
    { 0, 0, 0, 1, 1 },
    { 1, 0, 0, 0, 0 },
    { 0, 0, 0, 0, 0 },
    { 0, 0, 0, 1, 1 }
};
    private int[,] map25 = new int[,]
    {
    { 0, 0, 0, 0, 0 },
    { 0, 0, 1, 1, 0 },
    { 0, 0, 0, 0, 0 },
    { 0, 1, 1, 0, 0 },
    { 0, 0, 0, 0, 0 }
    };
    private int[,] map35 = new int[,]
    {
    { 0, 0, 0, 1, 1 },
    { 0, 0, 0, 0, 0 },
    { 1, 0, 0, 0, 0 },
    { 1, 0, 0, 0, 1 },
    { 1, 0, 0, 0, 1 }
    };
    private int[,] map45 = new int[,]
    {
    { 0, 0, 0, 0, 0 },
    { 0, 0, 0, 1, 0 },
    { 1, 0, 0, 0, 0 },
    { 0, 0, 0, 1, 0 },
    { 0, 0, 0, 0, 0 }
    };
    private int[,] map55 = new int[,]
    {
    { 0, 0, 0, 1, 1 },
    { 0, 0, 0, 0, 0 },
    { 1, 0, 0, 0, 0 },
    { 1, 0, 0, 1, 0 },
    { 1, 0, 0, 0, 0 }
    };
    private int[,] map65 = new int[,]
    {
    { 0, 0, 1, 1, 1 },
    { 1, 0, 0, 0, 0 },
    { 0, 0, 0, 0, 0 },
    { 0, 1, 1, 0, 0 },
    { 0, 0, 0, 0, 0 }
    };

    public int[,] GetMap5x5(int numMap)
    {
        if (numMap == 1)
        {
            return map15;
        }
        else if (numMap == 2)
        {
            return map25;
        }
        else if (numMap == 3)
        {
            return map35;
        }
        else if (numMap == 4)
        {
            return map45;
        }
        else if (numMap == 5)
        {
            return map55;
        }
        return map65;
    }


    private int[,] map16 = new int[,]
{
        { 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 1, 0, 0 },
        { 0, 0, 0, 1, 1, 0 },
        { 1, 1, 0, 0, 0, 0 },
        { 0, 0, 0, 1, 0, 0 },
        { 0, 0, 0, 0, 0, 0 }
};
    private int[,] map26 = new int[,]
{
        { 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0 },
        { 0, 0, 1, 1, 0, 0 },
        { 0, 0, 0, 0, 0, 0 },
        { 0, 0, 1, 1, 0, 0 },
        { 0, 0, 0, 0, 0, 0 }
};
    private int[,] map36 = new int[,]
{
        { 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0 },
        { 1, 1, 0, 1, 1, 0 },
        { 1, 1, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0 }
};
    private int[,] map46 = new int[,]
{
        { 0, 0, 0, 0, 0, 1 },
        { 0, 0, 0, 1, 0, 0 },
        { 0, 0, 0, 0, 0, 0 },
        { 1, 0, 0, 1, 0, 0 },
        { 0, 0, 0, 1, 0, 0 },
        { 0, 0, 0, 1, 0, 0 }
};
    private int[,] map56 = new int[,]
{
        { 0, 0, 0, 0, 0, 1 },
        { 0, 0, 0, 0, 0, 1 },
        { 0, 0, 0, 0, 0, 0 },
        { 1, 1, 0, 0, 0, 0 },
        { 0, 0, 0, 1, 0, 1 },
        { 0, 0, 0, 0, 0, 1 }
};
    private int[,] map66 = new int[,]
{
        { 0, 0, 0, 0, 0, 0 },
        { 0, 1, 0, 1, 0, 0 },
        { 0, 1, 0, 0, 1, 0 },
        { 0, 0, 0, 0, 0, 0 },
        { 0, 0, 1, 1, 0, 0 },
        { 0, 0, 0, 0, 0, 0 }
};
    public int[,] GetMap6x6(int numMap)
    {
        if (numMap == 1)
        {
            return map16;
        }
        else if (numMap == 2)
        {
            return map26;
        }
        else if (numMap == 3)
        {
            return map36;
        }
        else if (numMap == 4)
        {
            return map46;
        }
        else if (numMap == 5)
        {
            return map56;
        }
        return map66;
    }


    private int[,] map17 = new int[,]
    {
    { 0, 0, 0, 0, 0, 0, 0 },
    { 0, 0, 0, 0, 1, 1, 0 },
    { 0, 0, 0, 1, 1, 1, 0 },
    { 0, 0, 0, 0, 0, 0, 0 },
    { 1, 1, 0, 0, 0, 0, 0 },
    { 1, 0, 0, 0, 0, 0, 1 },
    { 1, 0, 0, 0, 0, 0, 1 }
    };
    private int[,] map27 = new int[,]
    {
    { 0, 0, 0, 0, 0, 0, 0 },
    { 0, 0, 0, 0, 0, 1, 0 },
    { 0, 0, 0, 0, 0, 0, 0 },
    { 0, 0, 1, 1, 0, 1, 0 },
    { 0, 0, 0, 0, 0, 0, 0 },
    { 1, 0, 1, 1, 0, 0, 0 },
    { 1, 0, 0, 0, 0, 0, 1 }
    };
    private int[,] map37 = new int[,]
    {
    { 0, 0, 0, 1, 1, 0, 1 },
    { 0, 0, 0, 0, 0, 0, 0 },
    { 0, 0, 0, 0, 0, 0, 0 },
    { 1, 1, 0, 1, 1, 0, 0 },
    { 1, 1, 0, 1, 1, 0, 0 },
    { 0, 0, 0, 0, 0, 0, 0 },
    { 0, 0, 0, 0, 0, 0, 1 }
    };
    private int[,] map47 = new int[,]
    {
    { 0, 0, 0, 0, 1, 1, 1 },
    { 0, 0, 0, 0, 1, 0, 0 },
    { 1, 0, 0, 0, 0, 0, 0 },
    { 0, 0, 0, 1, 0, 0, 1 },
    { 0, 0, 1, 1, 0, 0, 1 },
    { 0, 0, 0, 1, 0, 0, 0 },
    { 1, 0, 0, 0, 0, 0, 0 }
    };
    private int[,] map57 = new int[,]
    {
    { 0, 0, 0, 0, 0, 0, 1 },
    { 0, 0, 0, 0, 0, 0, 1 },
    { 0, 0, 0, 0, 0, 0, 0 },
    { 1, 1, 0, 0, 0, 0, 0 },
    { 0, 0, 0, 1, 0, 1, 1 },
    { 0, 0, 0, 1, 0, 1, 1 },
    { 1, 1, 0, 0, 0, 1, 1 }
    };
    private int[,] map67 = new int[,]
    {
    { 0, 0, 0, 0, 0, 0, 0 },
    { 0, 1, 1, 0, 1, 1, 0 },
    { 0, 1, 0, 0, 0, 1, 0 },
    { 0, 1, 0, 0, 0, 0, 0 },
    { 0, 0, 0, 0, 0, 0, 0 },
    { 0, 1, 1, 1, 0, 1, 0 },
    { 0, 0, 0, 0, 0, 0, 0 }
    };
    public int[,] GetMap7x7(int numMap)
    {
        if (numMap == 1)
        {
            return map17;
        }
        else if (numMap == 2)
        {
            return map27;
        }
        else if (numMap == 3)
        {
            return map37;
        }
        else if (numMap == 4)
        {
            return map47;
        }
        else if (numMap == 5)
        {
            return map57;
        }
        return map67;
    }


    private int[,] map18 = new int[,]
    {
    { 0, 0, 0, 0, 0, 0, 0, 0 },
    { 0, 0, 0, 0, 0, 0, 0, 0 },
    { 1, 0, 0, 0, 1, 1, 0, 0 },
    { 1, 0, 0, 1, 1, 1, 0, 0 },
    { 1, 1, 0, 1, 1, 0, 0, 0 },
    { 1, 1, 0, 1, 1, 0, 0, 0 },
    { 0, 0, 0, 0, 0, 0, 0, 0 },
    { 0, 0, 0, 0, 0, 0, 0, 0 }
    };
    private int[,] map28 = new int[,]
    {
    { 0, 0, 0, 0, 0, 0, 1, 1 },
    { 0, 0, 0, 0, 0, 0, 0, 0 },
    { 1, 0, 0, 0, 0, 0, 0, 0 },
    { 1, 0, 1, 1, 0, 0, 1, 1 },
    { 0, 0, 0, 0, 0, 0, 0, 0 },
    { 0, 0, 1, 1, 0, 0, 0, 0 },
    { 1, 1, 0, 0, 0, 0, 0, 0 },
    { 1, 1, 0, 0, 0, 0, 1, 1 }
    };
    private int[,] map38 = new int[,]
    {
    { 0, 0, 0, 0, 0, 0, 0, 0 },
    { 0, 0, 0, 1, 0, 0, 1, 0 },
    { 0, 0, 0, 0, 0, 0, 0, 0 },
    { 1, 1, 0, 1, 1, 0, 0, 0 },
    { 1, 1, 0, 1, 1, 0, 1, 0 },
    { 1, 0, 0, 1, 1, 0, 0, 0 },
    { 1, 0, 0, 0, 0, 0, 1, 0 },
    { 1, 1, 0, 0, 0, 0, 0, 0 }
    };
    private int[,] map48 = new int[,]
    {
    { 0, 0, 0, 0, 1, 1, 0, 0 },
    { 0, 0, 0, 0, 1, 1, 0, 0 },
    { 0, 0, 0, 0, 0, 0, 0, 0 },
    { 1, 0, 0, 1, 1, 0, 0, 0 },
    { 1, 0, 0, 1, 1, 0, 1, 0 },
    { 1, 0, 1, 1, 1, 0, 1, 0 },
    { 0, 0, 0, 1, 1, 0, 0, 0 },
    { 0, 0, 0, 0, 0, 0, 0, 0 }
    };
    private int[,] map58 = new int[,]
    {
    { 0, 0, 1, 1, 1, 1, 0, 0 },
    { 0, 0, 0, 0, 0, 1, 0, 0 },
    { 0, 0, 0, 0, 0, 0, 0, 0 },
    { 1, 1, 0, 0, 0, 0, 0, 0 },
    { 1, 1, 1, 1, 0, 1, 0, 0 },
    { 0, 0, 0, 0, 0, 1, 0, 0 },
    { 0, 0, 0, 0, 0, 1, 0, 0 },
    { 0, 0, 1, 1, 1, 1, 0, 0 }
    };
    private int[,] map68 = new int[,]
    {
    { 0, 0, 0, 0, 0, 0, 0, 0 },
    { 0, 1, 0, 1, 0, 0, 1, 0 },
    { 0, 1, 0, 1, 1, 0, 0, 0 },
    { 0, 0, 0, 0, 0, 0, 0, 0 },
    { 0, 0, 1, 1, 0, 1, 1, 0 },
    { 0, 1, 1, 1, 0, 1, 1, 0 },
    { 0, 0, 0, 0, 0, 0, 0, 0 },
    { 0, 0, 1, 1, 0, 0, 1, 1 }
    };
    public int[,] GetMap8x8(int numMap)
    {
        if (numMap == 1)
        {
            return map18;
        }
        else if (numMap == 2)
        {
            return map28;
        }
        else if (numMap == 3)
        {
            return map38;
        }
        else if (numMap == 4)
        {
            return map48;
        }
        else if (numMap == 5)
        {
            return map58;
        }
        return map68;
    }
}
