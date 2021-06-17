using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jacobi
{
    class Jacobi
    {
        public double[,] matrix { get ; set ; }
        public Jacobi(Double [ , ] matrix) {
            this.matrix = matrix;
        }

        public Double [,] PMatrix() {
            Double [ , ] PMatrix = new Double [ this.matrix.GetLength(0) , this.matrix.GetLength(1) ];
            Index MaxPoint = Max ( this.matrix );
            Console.WriteLine(MaxPoint.i);
            if ( this.matrix [ MaxPoint.i , MaxPoint.i ] == this.matrix [ MaxPoint.j, MaxPoint.j ] )
            {
                Console.WriteLine("Ato");
                PMatrix [ MaxPoint.i , MaxPoint.i ] = Math.Sqrt(2) / 2;
                PMatrix [ MaxPoint.j , MaxPoint.j ] = Math.Sqrt(2) / 2;
                PMatrix [ MaxPoint.i , MaxPoint.j ] = Math.Sqrt(2) / 2;
                PMatrix [ MaxPoint.j , MaxPoint.i ] = -Math.Sqrt(2) / 2;
            }
            else {
                Double b = Math.Abs( this.matrix [ MaxPoint.i , MaxPoint.i ] - this.matrix [ MaxPoint.j , MaxPoint.j ] );
                Double c = 2 * this.matrix [ MaxPoint.i , MaxPoint.j ] * Math.Sign ( this.matrix [ MaxPoint.i , MaxPoint.i ] - this.matrix [ MaxPoint.j , MaxPoint.j ] );
                Double Racine= Math.Sqrt ( Math.Pow ( b , 2) + Math.Pow ( c , 2 ) ) ;
                Double Calcul = 1 + ( b / Racine );
                PMatrix [ MaxPoint.i , MaxPoint.i ] =  Math.Sqrt ( 0.5 * Calcul );
                PMatrix[MaxPoint.j, MaxPoint.j] = Math.Sqrt(0.5 * Calcul);
                PMatrix [ MaxPoint.j , MaxPoint.i ] = c / ( 2 * this.matrix [ MaxPoint.i , MaxPoint.i ] * Racine ) ;
                PMatrix [ MaxPoint.i , MaxPoint.j ] = - PMatrix [ MaxPoint.j , MaxPoint.i ] ;
            }
            return PMatrix;
        }

        public Index Max(double[,] Matrix) {
            Double max=0;
            Index MaxIndex = new Index();
            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(1); j++) 
                {
                    if (this.matrix[i, j] > max) {
                        max = this.matrix[i, j];
                        MaxIndex.i = i;
                        MaxIndex.j = j;
                    }
                }
            }
            return MaxIndex;
        }

        public Double [,] ScalarMultiplication(Double [ , ] FirstMatrix , Double [ , ] SecondMatrix) {
            Double [,] ScalarMultiply = new Double[ FirstMatrix.GetLength(0) , FirstMatrix.GetLength(1) ];
            for ( int i = 0; i < FirstMatrix.GetLength(0); i++ )
            {
                for (int j = 0; j < FirstMatrix.GetLength(1); j++) {
                    Double Sum = 0;
                    for (int k = 0; k < FirstMatrix.GetLength(1); k++)
                        Sum += FirstMatrix[i, k] * SecondMatrix[k, j];
                    ScalarMultiply[i, j] = Sum;
                }
            }
            return ScalarMultiply;
        }

        public Double[,] TransposeMatrix(Double[,] NormalMatrix)
        {
            Double[,] MatrixTranspose= new Double[NormalMatrix.GetLength(0) , NormalMatrix.GetLength(1)];
            for (int i = 0; i < NormalMatrix.GetLength(0); i++) 
                for (int j = 0; j < NormalMatrix.GetLength(1); j++)
                    MatrixTranspose[i, j] = NormalMatrix[j, i];
            return MatrixTranspose;
        }

        public Double[,] Algorithm() {
            this.matrix = ScalarMultiplication( this.matrix, ScalarMultiplication( TransposeMatrix (PMatrix () ) , PMatrix () ) );
            return this.matrix;
        }
    }
}
