///? Questão 2: implemente uma função que, dado uma matriz A e uma submatriz B (dimensões menores que A), esta função retorne quantas vezes esta submatriz B pode ser encontrada na matriz A.
using System;

int[][] matrixA = new int[][]
{
    new int[] { 25, 9, 11, 23, 13, 3, 7, 15, 18, 3 },
    new int[] { 0, 20, 18, 12, 7, 18, 21, 20, 11, 4 },
    new int[] { 23, 17, 11, 9, 11, 10, 11, 16, 16, 21 },
    new int[] { 25, 16, 21, 12, 3, 17, 5, 6, 7, 4 },
    new int[] { 15, 3, 13, 20, 2, 16, 19, 9, 22, 14 },
    new int[] { 16, 17, 7, 14, 24, 2, 2, 7, 24, 11 },
    new int[] { 17, 14, 21, 2, 3, 1, 20, 1, 4, 12 },
    new int[] { 10, 23, 22, 14, 19, 19, 23, 5, 2, 4 },
    new int[] { 5, 18, 11, 20, 6, 0, 13, 18, 15, 22 },
    new int[] { 17, 2, 10, 19, 11, 3, 3, 12, 17, 22 }
};

int[][] matrixB = new int[][]
{
    new int[] { 3, 12, 17 },
    new int[] { 16, 19, 9 },
    new int[] { 22, 14, 16 }
};

int countSubMatrix(int[][] matrix, int[][] subMatrix)
{
    int count = 0;
    for (int i = 0; i < matrix.Length; i++)
    {
        for (int j = 0; j < matrix[i].Length; j++)
        {
            if (matrix[i][j] == subMatrix[0][0])
            {
                bool found = true;

                for (int k = 0; k < subMatrix.Length; k++)
                {
                    for (int l = 0; l < subMatrix[k].Length; l++)
                    {
                        int shiftedRow = i + k;
                        int shiftedColumn = j + l;

                        if (
                            shiftedRow >= matrix.Length
                            || shiftedColumn >= matrix[shiftedRow].Length
                            || matrix[shiftedRow][shiftedColumn] != subMatrix[k][l]
                        )
                        {
                            found = false;
                            break;
                        }
                    }
                    if (!found)
                    {
                        break;
                    }
                }
                if (found)
                {
                    count++;
                }
            }
        }
    }

    return count;
}

void printMatrix(ref int[][] matrix)
{
    foreach (int[] row in matrix)
    {
        foreach (int column in row)
        {
            Console.Write($"{column} ");
        }
        Console.WriteLine();
    }
}

void program()
{
    int count = countSubMatrix(matrixA, matrixB);

    Console.WriteLine($"Matrix A:");
    Console.WriteLine();
    printMatrix(ref matrixA);
    Console.WriteLine();
    Console.WriteLine();

    Console.WriteLine($"Matrix B:");
    Console.WriteLine();
    printMatrix(ref matrixB);
    Console.WriteLine();
    Console.WriteLine();

    Console.WriteLine($"Matrix B found {count} times in Matrix A");
}

program();
