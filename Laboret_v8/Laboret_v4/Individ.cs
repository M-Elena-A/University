using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboret_v4
{
    class Individ
    {

       /// private
        public Chromosom[] xrom = new Chromosom[4];
        //, xrom_2;
        //Chromosom xrom_3, xrom_4;
        // переделать в вектор?
        public double Fank_out;

        // Parametrs A
        public Individ(Parametrs A) //double min, double max,
        {
            if (A.Chom == 2)
            { xrom[0] = new Chromosom(A);
              xrom[1] = new Chromosom(A); }
            if (A.Chom == 4)
            {
                xrom[0] = new Chromosom(A);
                xrom[1] = new Chromosom(A);
                xrom[2] = new Chromosom(A);
                xrom[3] = new Chromosom(A);
            }

           // xrom_1 = new Chromosom(A); 
           // xrom_2 = new Chromosom(A);
           // Min = inter0[0,0]; //new float[,] { { inter0[0, 0], inter0[0, 1] } };
           // Max = inter0[0,1]; 
           // Set_chrom(L, Mut, Inv, point, point2);
        }
        /* public Individ(float[,] inter0)
         {
             xrom_1 = new Chromosom();
             xrom_2 = new Chromosom();

             Min = inter0[0, 0];
             Max = inter0[0, 1];
             Set_chrom(L_ind, Mut_ind, Inv_ind, point_ind, point2_ind);
         }
         */

        public string Prin_Ind(Parametrs A)
        {
            if (A.Chom == 2)
            {
                return "1)" + xrom[0].Prin(A) + Environment.NewLine + "2)" + xrom[1].Prin(A) + Environment.NewLine;

            }
            if (A.Chom == 4)
            {
                return "1)" + xrom[0].Prin(A) + Environment.NewLine + "2)" + xrom[1].Prin(A) + Environment.NewLine +
                    "3)" + xrom[2].Prin(A) + Environment.NewLine + "4)" + xrom[3].Prin(A) + Environment.NewLine;
            }
            else return "0_0";
          // return "1)" + xrom[0].Prin(A) + Environment.NewLine + "2)" + xrom[1].Prin(A) + Environment.NewLine;
        }

        /*  private void Set_chrom(int L, float Mut, float Inv, int point, int point2)
          {
              Mut_ind = Mut;
              Inv_ind = Inv;
              point_ind = point;
              point2_ind = point2;
              L_ind = L;
          }
          */


        private void Mutate(Parametrs p)// 1 - 1 хром 2- 2 хром 3> - обе
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
        private void Invers(Parametrs p)// 1 - 1 хром 2- 2 хром 3> - обе
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

        
          public double Fenotip_1(Parametrs a)
        { return Genot_in_Fenotip(xrom[0], a.interM[0, 0], a.interM[0, 1]);  }
          public double Fenotip_2(Parametrs a)
        { return Genot_in_Fenotip(xrom[1], a.interM[1, 0], a.interM[1, 1]);   }
          
          public double Fenotip_3(Parametrs a)
        { return Genot_in_Fenotip(xrom[2], a.interM[2, 0], a.interM[2, 1]); }        
          public double Fenotip_4(Parametrs a)
        { return Genot_in_Fenotip(xrom[3], a.interM[3, 0], a.interM[3, 1]); }
       
        double Genot_in_Fenotip(Chromosom ch, double Min, double Max)
          {
              Int32 gen = 0;
              for (int i = 0; i < Chromosom.Length; i++)
              {
                  if (ch[i])
                      gen += 1 << i;
              }
              return Min + gen*(Max - Min) / (Math.Pow(2.0, Chromosom.Length) - 1);
            // return Aa.interM[0,0] + gen * (Aa.interM[0, 1] - Aa.interM[0, 0]) / (Math.Pow(2.0, Chromosom.Length) - 1);

        }

        public string Prin_Fen(Parametrs a)
        {
            if (a.Chom == 2)
            {
                return "1) " + Fenotip_1(a) + Environment.NewLine + " 2) " + Fenotip_2(a) + Environment.NewLine;
                }
            if (a.Chom == 4)
            {
                return "1) " + Fenotip_1(a) + Environment.NewLine + " 2) " + Fenotip_2(a) + Environment.NewLine+
                       "3) " + Fenotip_3(a) + Environment.NewLine + " 4) " + Fenotip_4(a) + Environment.NewLine;
               }
            return "0_0 "; 
        }


        public static Individ[] PointCrossOver(Parametrs a, Individ A, Individ B)
        {
            Individ[] C = new Individ[] { new Individ(a), new Individ(a) };
            if (a.Chom == 2)
            {
                Chromosom.PointCrossOver(a, A.xrom[0], B.xrom[0], out C[0].xrom[0], out C[1].xrom[0]);
                Chromosom.PointCrossOver(a, A.xrom[1], B.xrom[1], out C[0].xrom[1], out C[1].xrom[1]);
            }
            if (a.Chom == 4)
            {
                Chromosom.PointCrossOver(a, A.xrom[0], B.xrom[0], out C[0].xrom[0], out C[1].xrom[0]);
                Chromosom.PointCrossOver(a, A.xrom[1], B.xrom[1], out C[0].xrom[1], out C[1].xrom[1]);
                Chromosom.PointCrossOver(a, A.xrom[2], B.xrom[2], out C[0].xrom[2], out C[1].xrom[2]);
                Chromosom.PointCrossOver(a, A.xrom[3], B.xrom[3], out C[0].xrom[3], out C[1].xrom[3]);
            }


            //Chromosom.PointCrossOver(a, A.xrom_1, B.xrom_1, out C[0].xrom_1, out C[1].xrom_1);
            //Chromosom.PointCrossOver(a, A.xrom_2, B.xrom_2, out C[0].xrom_2, out C[1].xrom_2);            

            return C;

        }

        public static Individ CopiInd(Parametrs a, Individ A, Individ B)
        {
            B =  new Individ(a);
            if (a.Chom == 2)
            {//CopiCh(Parametrs A, Chromosom chromA,  out Chromosom chromB)
                Chromosom.CopiCh(a, A.xrom[0], out B.xrom[0] );
                Chromosom.CopiCh(a, A.xrom[1], out B.xrom[1] );
            }
            if (a.Chom == 4)
            {
                Chromosom.CopiCh(a, A.xrom[0], out B.xrom[0]);
                Chromosom.CopiCh(a, A.xrom[1], out B.xrom[1]);
                Chromosom.CopiCh(a, A.xrom[2], out B.xrom[2]);
                Chromosom.CopiCh(a, A.xrom[3], out B.xrom[3]);
            }


            //Chromosom.PointCrossOver(a, A.xrom_1, B.xrom_1, out C[0].xrom_1, out C[1].xrom_1);
            //Chromosom.PointCrossOver(a, A.xrom_2, B.xrom_2, out C[0].xrom_2, out C[1].xrom_2);            

            return B;

        }

    }
}
