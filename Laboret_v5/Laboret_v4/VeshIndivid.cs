using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboret_v4
{
    class VeshIndivid
    {
        
        public VeshChrom[] xrom = new VeshChrom[4];
        
        public double Fank_out;

      
        public VeshIndivid(Parametrs A)
        {
            if (A.Chom == 2)
            {
                xrom[0] = new VeshChrom(A, 0);
                xrom[1] = new VeshChrom(A, 1);
            }
            if (A.Chom == 4)
            {
                xrom[0] = new VeshChrom(A, 0);
                xrom[1] = new VeshChrom(A, 1);
                xrom[2] = new VeshChrom(A, 2);
                xrom[3] = new VeshChrom(A, 3);
            }
            
        }      

        public string Prin_Ind(Parametrs A)
        {
            if (A.Chom == 2)
            {
                return "1)" + xrom[0].Prin() + Environment.NewLine + "2)" + xrom[1].Prin() + Environment.NewLine;

            }
            if (A.Chom == 4)
            {
                return "1)" + xrom[0].Prin() + Environment.NewLine + "2)" + xrom[1].Prin() + Environment.NewLine +
                    "3)" + xrom[2].Prin() + Environment.NewLine + "4)" + xrom[3].Prin() + Environment.NewLine;
            }
            else return "0_0";
            
        }
        
        private void Mutate(Parametrs p)
        {
            if (p.Chom == 2)
            {
                xrom[0].Mutate(p);
                xrom[1].Mutate(p);
            }
            if (p.Chom == 4)
            {
                xrom[0].Mutate(p);
                xrom[1].Mutate(p);
                xrom[2].Mutate(p);
                xrom[3].Mutate(p);
            }

            /*switch (i)
            {   case 1:
                    xrom_1.Mutate(p);
                    break;
                case 2:
                    xrom_2.Mutate(p);
                    break;
                default:
                    xrom_1.Mutate(p);
                    xrom_2.Mutate(p);
                    break;
            }*/
        }
        private void Invers(Parametrs p)
        {
            if (p.Chom == 2)
            {
                xrom[0].Invers(p);
                xrom[1].Invers(p);
            }
            if (p.Chom == 4)
            {
                xrom[0].Invers(p);
                xrom[1].Invers(p);
                xrom[2].Invers(p);
                xrom[3].Invers(p);
            }

            /* switch (i)
             {
                 case 1:
                     xrom_1.Invers(p);
                     break;
                 case 2:
                     xrom_2.Invers(p);
                     break;
                 default:
                     xrom_1.Invers(p);
                     xrom_2.Invers(p);
                     break;
             }*/
        }
        public void MutateAll(Parametrs p)
        {
            Mutate(p);
            Invers(p);
        }

        public static VeshIndivid[] PointCrossOver(Parametrs a, VeshIndivid A, VeshIndivid B)
        {
            VeshIndivid[] C = new VeshIndivid[] { new VeshIndivid(a), new VeshIndivid(a) };
            double[] s = new double[2];
            if (a.Chom == 2)
            {
                s=Point_CrossOver(a, A.xrom[0], B.xrom[0]);
                C[0].xrom[0].chrom = s[0];
                C[1].xrom[0].chrom = s[1];

                s = Point_CrossOver(a, A.xrom[1], B.xrom[1]);
                C[0].xrom[1].chrom = s[0];
                C[1].xrom[1].chrom = s[1];
               


            }
            if (a.Chom == 4)
            {
                s = Point_CrossOver(a, A.xrom[0], B.xrom[0]);
                C[0].xrom[0].chrom = s[0];
                C[1].xrom[0].chrom = s[1];

                s = Point_CrossOver(a, A.xrom[1], B.xrom[1]);
                C[0].xrom[1].chrom = s[0];
                C[1].xrom[1].chrom = s[1];

                s = Point_CrossOver(a, A.xrom[2], B.xrom[2]);
                C[0].xrom[2].chrom = s[0];
                C[1].xrom[2].chrom = s[1];

                s = Point_CrossOver(a, A.xrom[3], B.xrom[3]);
                C[0].xrom[3].chrom = s[0];
                C[1].xrom[3].chrom = s[1];
               
            }

            return C;

        }
        //  кроссенговер    VeshChrom
        private static double[] Point_CrossOver(Parametrs A, VeshChrom chromA, VeshChrom chromB)
        {
            // однототечный кроссенговер
            double[] chrom = new double[2];

            chrom[0] = A.point0 * chromA.chrom + (1 - A.point0) * chromB.chrom;

            chrom[1]= (1 - A.point0) * chromA.chrom + A.point0 * chromB.chrom;
            return chrom;

        }



        public double Fenotip_1(Parametrs a)
        { return xrom[0].chrom; }
        public double Fenotip_2(Parametrs a)
        { return xrom[1].chrom; }

        public double Fenotip_3(Parametrs a)
        { return xrom[2].chrom; }
        public double Fenotip_4(Parametrs a)
        { return xrom[3].chrom; }

        

        public string Prin_Fen(Parametrs a)
        {
            if (a.Chom == 2)
            {
                return "1) " + Fenotip_1(a) + Environment.NewLine + " 2) " + Fenotip_2(a) + Environment.NewLine;
            }
            if (a.Chom == 4)
            {
                return "1) " + Fenotip_1(a) + Environment.NewLine + " 2) " + Fenotip_2(a) + Environment.NewLine +
                       "3) " + Fenotip_3(a) + Environment.NewLine + " 4) " + Fenotip_4(a) + Environment.NewLine;
            }
            return "0_0 ";
        }





    }
}
