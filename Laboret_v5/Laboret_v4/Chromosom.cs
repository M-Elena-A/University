using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboret_v4
{
    class Chromosom
    {
        private static int length = 15;
        private bool[] chrom;

        //private static int _seed = Environment.TickCount;
        //private static Random rnd1 = new Random( _seed);

        //возможность измененния длины гена
        public static int Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
            }
        }
        //возможность обращаться к к конкретному значению в хромосоме (переопределение)
        public bool this[int i]
        {
            get { return chrom[i]; }
            set { chrom[i] = value; }
        }

        
        public Chromosom(Parametrs A)
        {
            Chromosom.Length = A.Length;

           // int L = BinaryChromosome.Length;
            chrom = new bool[A.Length];
            Randomize(A);
        }


        public string Prin(Parametrs A)
        {
            string tectik=" ";
            char a;
            for (int i = 0; i < Chromosom.Length; i++)
            {
                if (i == A.point1 || i == A.point2 && i!=0)
                    tectik = tectik + '_';
                a = (chrom[i] ? '1' : '0');
                tectik = tectik + a ; }

            return tectik;
        }
        //рандом работает классно
        public void Randomize(Parametrs A)
        {
            for (int i = 0; i < Chromosom.Length; i++)
            {    
                if (A.rnd1.NextDouble() < 0.5)            
                chrom[i]= !chrom[i];
            }
            
            
        }


        // мутация работает
        public void Mutate(Parametrs A)
        {
            for (int i = 0; i < Chromosom.Length; i++)
            {
                if (A.rnd1.NextDouble() < A.Muttion)
                    chrom[i] = !chrom[i];
            }
        }
        // инвенсия работает
        public void Invers(Parametrs A)
        {
            if (A.rnd1.NextDouble() < A.Invtion)
                {
            for (int i = 0; i < Chromosom.Length; i++)
            {
                 chrom[i] = !chrom[i];
                  
                }

            }
        }


        //  кроссенговер
        public static void PointCrossOver(Parametrs A, Chromosom chromA, Chromosom chromB, out Chromosom chromC, out Chromosom chromD)
        {
            if (!A.Ipoint )
            {// однототечный кроссенговер
                chromC = new Chromosom(A);
                chromD = new Chromosom(A);
                for (int i = 0; i < A.point1; i++)
                {
                    chromC[i] = chromA[i];
                    chromD[i] = chromB[i];
                }
                for (int i = A.point1; i < Chromosom.Length; i++)
                {
                    chromC[i] = chromB[i];
                    chromD[i] = chromA[i];
                }
            }
            else
            {// двухточеный кроссенговер
                chromC = new Chromosom(A);
                chromD = new Chromosom(A);
                int i = 0;
                for (i = 0; i < A.point1; i++)
                {
                    chromC[i] = chromA[i];
                    chromD[i] = chromB[i];
                }
                for (i = A.point1; i < A.point2; i++)
                {
                    chromC[i] = chromB[i];
                    chromD[i] = chromA[i];
                }
                for (i = A.point2; i < Chromosom.Length; i++)
                {
                    chromC[i] = chromA[i];
                    chromD[i] = chromB[i];
                }
            }


        }

        public static void CopiCh(Parametrs A, Chromosom chromA,  out Chromosom chromB)
        {
            
                chromB = new Chromosom(A);
            int t0 = A.Length - A.Length / A.Setka;
            // 24/2=12 а надо 24-12
            // 36/3=12 а надо 36-36/3= 24


                for (int i = 0; i < t0; i++)
                {
                    chromB[i] = false;
                   
                }
                for (int i = t0; i < Chromosom.Length; i++)
                {
                    chromB[i] = chromA[i-t0];
                }
            
          


        }

    }

}
