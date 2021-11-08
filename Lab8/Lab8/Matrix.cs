using System;
namespace Lab8
{
    public static class Matrix
    {
        public static int DotProduct(int[] v1, int[] v2)
        {
            int dot = 0;
            for (int i = 0; i < v1.Length; ++i)
            {
                dot += v1[i] * v2[i];
            }
            return dot;
        }

        public static int[,] Transpose(int[,] matrix)
        {
            var transpose = new int[matrix.GetLength(1), matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(1); ++i)
            {
                for (int j = 0; j < matrix.GetLength(0); ++j)
                {
                    transpose[i, j] = matrix[j, i];
                }
            }
            return transpose;

        }

        public static int[,] GetIdentityMatrix(int size)
        {
            var identityMatrix = new int[size, size];

            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    if (i != j)
                    {
                        identityMatrix[i, j] = 0;
                    }
                    else
                    {
                        identityMatrix[i, j] = 1;
                    }
                }
            }

            return identityMatrix;
        }

        public static int[] GetRowOrNull(int[,] matrix, int row)
        {
            int[] designatedRow = new int[matrix.GetLength(1)];

            if (row > matrix.GetLength(0) - 1)
            {
                return null;
            }

            for (int i = 0; i < matrix.GetLength(1); ++i)
            {
                designatedRow[i] = matrix[row, i];
            }

            return designatedRow;
        }

        public static int[] GetColumnOrNull(int[,] matrix, int col)
        {
            int[] designatedColomn = new int[matrix.GetLength(0)];

            if (col > matrix.GetLength(1) - 1)
            {
                return null;
            }

            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                designatedColomn[i] = matrix[i, col];
            }

            return designatedColomn;
        }

        public static int[] MultiplyMatrixVectorOrNull(int[,] matrix, int[] vector)
        {
            if (matrix.GetLength(1) != vector.Length)
            {
                return null;
            }
            int[] product = new int[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                int temp = 0;
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    temp += matrix[i, j] * vector[j];
                }
                if(temp != 0)
                {
                    product[i] = temp;
                }
            }
            return product;
        }

        public static int[] MultiplyVectorMatrixOrNull(int[] vector, int[,] matrix)
        {
            matrix = Transpose(matrix);
            return MultiplyMatrixVectorOrNull(matrix, vector);
        }

        public static int[,] MultiplyOrNull(int[,] multiplicandMatrix, int[,] multiplierMatrix)
        {
            if (multiplicandMatrix.GetLength(1) != multiplierMatrix.GetLength(0))
            {
                return null;
            }

            int[,] product = new int[multiplicandMatrix.GetLength(0), multiplierMatrix.GetLength(1)];

            for (int i = 0; i < multiplicandMatrix.GetLength(0); ++i)
            {
                for (int j = 0; j < multiplierMatrix.GetLength(1); ++j)
                {
                    int temp = 0;
                    for (int k = 0; k < multiplierMatrix.GetLength(0); ++k)
                    {
                        temp += multiplicandMatrix[i, k] * multiplierMatrix[k, j];
                    }
                    product[i, j] = temp;

                }
            }
            return product;

        }

    }
}
