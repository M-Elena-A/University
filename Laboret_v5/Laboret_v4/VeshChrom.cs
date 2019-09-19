using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboret_v4
{
    class VeshChrom
    {
       public double chrom;
       
        //возможность измененния длины гена
       
     
        public VeshChrom(Parametrs A, int i)
        {
            
            chrom = A.rnd1.Next(Convert.ToInt32( A.interM[i,0] ) , Convert.ToInt32(A.interM[i, 1]));
            chrom = chrom + A.rnd1.NextDouble();
        }

        public string Prin()
        {
            return chrom.ToString();
        }
     
        // мутация работает
        public void Mutate(Parametrs A)
        {           
                if (A.rnd1.NextDouble() < A.Muttion)
                    chrom = chrom - A.rnd1.NextDouble();

        }
        // инвенсия работает
        public void Invers(Parametrs A)
        {

         //  double iii =  chrom * 100 / (Math.Pow(2.0, VeshChrom.Length) - 1);

            if (A.rnd1.NextDouble() < A.Invtion)
                chrom = chrom + A.rnd1.Next();
        }


        
    }
}
