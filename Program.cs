using System;
internal class Relation
{
    private int row, column;
    public int[][] matrix;

    public int Row
    {
        get { return this.row; }
        set { this.row = value; }
    }
    public int Column
    {
        get { return this.column; }
        set { this.column = value; }
    }
   
    public Relation(int m, int n, int[][] input) 
    {
        this.row = m;
        this.column = n;
        this.matrix = new int[m][];
        for (int i = 0; i < this.row; i++)
            this.matrix[i] = new int[n];

        for (int i = 0; i < this.row; i++)
            for (int j = 0; j < this.column; j++)
                this.matrix[i][j] = input[i][j];
    }
    public void printMatrix()
    {
        for (int i = 0; i < this.row; i++)
        {
            for (int j = 0; j < this.column; j++)
                Console.Write(this.matrix[i][j] + " ");
            Console.WriteLine("");
        }
    }
    public static Relation operator * (Relation matrix1, Relation matrix2)
    {
        int[][] emptyMatrix = new int[matrix1.Row][];
        for (int i = 0; i < matrix1.Row; i++)
            emptyMatrix[i] = new int[matrix2.Column];

        Relation arrMultiply = new Relation(matrix1.Row, matrix2.Column, emptyMatrix);
        for (int i = 0; i < matrix1.Row; i++)
            for (int k = 0; k < matrix1.Column; k++)
                if(matrix1.matrix[i][k] == 1)
                    for (int j = 0; j < matrix2.Column; j++)
                        if (matrix2.matrix[k][j] == 1) arrMultiply.matrix[i][j] = 1;
        return arrMultiply;
    }
    public static Relation operator + (Relation matrix1, Relation matrix2)
    {
        int[][] emptyMatrix = new int[matrix1.Row][];
        for (int i = 0;i < matrix1.Row; i++)
            emptyMatrix[i] = new int[matrix1.Column];

       Relation matrixSum = new Relation(matrix1.Row, matrix2.Column, emptyMatrix);

        for(int i = 0; i < matrix1.Row; i++)
            for(int j = 0; j < matrix2.Column; j++)
                if (matrix1.matrix[i][j] == 1 || matrix2.matrix[i][j] == 1)
                    matrixSum.matrix[i][j] = 1;
        return matrixSum;  
    }

    public Relation Warshall_Algorithm()
    {
        Relation W = new Relation (this.row, this.column, this.matrix);
      
        int k = 1;

        while(k <= this.row)
        {
            W = (W * W) + W;
            k++;
        }
        return W;
    }
}

class Program
{
 
    static void Main()
    {
        /*
        Console.WriteLine("Nhap kich thuoc ma tran bieu dien quan he R: ");
        int n = int.Parse(Console.ReadLine());
        int[][] input = new int[n][];
        for(int i = 0; i < n; i++)
            input[i] = new int[n];

        Console.WriteLine("Nhap ma tran bieu dien quan he R");
        for(int i = 0; i < n; i++)
            for(int j = 0; j < n; j++)
                input[i][j] = int.Parse(Console.ReadLine());

        Relation R = new Relation(n, n, input),
                 Wn = R.Warshall_Algorithm();

        Console.Clear();

        Console.WriteLine("Day la ma tran bieu dien quan he R: ");
        R.printMatrix();

        Console.WriteLine("Day la ma tran bieu dien bao dong bac cau cua quan he R: ");
        Wn.printMatrix();

        */

        int m = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        int[][] input1 = new int[m][];
        for (int i = 0; i < m; i++)
            input1[i] = new int[n];

        Console.WriteLine("Nhap ma tran 1:");
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                input1[i][j] = int.Parse(Console.ReadLine());

        Relation R = new Relation(m, n, input1);

        m = int.Parse(Console.ReadLine());
        n = int.Parse(Console.ReadLine());
        int[][] input2 = new int[m][];
        for (int i = 0; i < m; i++)
            input2[i] = new int[n];

        Console.WriteLine("Nhap ma tran 2:");
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                input2[i][j] = int.Parse(Console.ReadLine());

        Relation S = new Relation(m, n, input2),
                 U = R * S;

        U.printMatrix();

        return;
    }
}
