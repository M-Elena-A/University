using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboret_v4
{
    class Population
    {
        
        public Individ[] Popul_all;
        // private Individual[] pool;
        // private Individual globalBest;

        public Population(Parametrs a)
        {
            //Set_pop(Namber_0, nIters_0, fanc_0, tuuuutu);

            Popul_all = Popul_0(a);

            //Select();
        }
        
       
        public double Fank_(Individ s, Parametrs a)//double Fenotip_01, double Fenotip_02)
        {
            double x1=0, x2=0, x3=0, x4=0;

            if (a.Chom == 4)
            {   x1 = s.Fenotip_1(a);
                x2 = s.Fenotip_2(a);
                x3 = s.Fenotip_3(a);
                x4 = s.Fenotip_4(a);
            }
            else
            {
                x1 = s.Fenotip_1(a);
                x2 = s.Fenotip_2(a);
            }

            double ouT;
           
            switch (a.Fanc)
            {
                case 1:
                    ouT = 100*(x2 - x1 * x1) * (x2 - x1 * x1) + (1 - x1) * (1 - x1);
                    break;
                case 4:
                    ouT= 4 * (x1 - 5) * (x1 - 5) + (x2 - 6) * (x2  - 6);
                    break;
                case 5:
                    ouT = (x2 - x1 * x1) * (x2 - x1 * x1) + (1 - x1) * (1 - x1);
                    break;
                case 8:
                    ouT = x1 * x1 * x1 + x2 * x2 - 3 * x1 - 2 * x2 + 2;
                    break;
                    
                case 12:
                    ouT = 4 * x1 * x1 + 3 * x2 * x2 - 4 * x1 * x2 * x2 + x1;
                    break;
                case 15:
                    ouT = (1.5 - x1 * (1 - x2)) * (1.5 - x1 * (1 - x2)) + (2.25 - x1 * (1 - x2 * x2)) * (2.25 - x1 * (1 - x2 * x2)) + 
                        (2.625 - x1 * (1 - x2 * x2 * x2)) * (2.625 - x1 * (1 - x2 * x2 * x2));
                    break;
                case 17:
                    ouT = 100 * (x2 - x1 * x1) * (x2 - x1 * x1) + (1 - x1) * (1 - x1) + 90 * (x4 - x3 * x3) * (x4 - x3 * x3) + 
                        (1 - x3) * (1 - x3) * (1 - x3) + 10.1*((x2 - 1) * (x2 - 1) + (x4 - 1) * (x4 - 1)) + 19.8*(x2 - 1) * (x4 - 1); 
                    break;
                case 13:
                    ouT = (x1 * x1 + x2 - 11) * (x1 * x1 + x2 - 11) + (x1 + x2 * x2 - 7) * (x1 + x2 * x2 - 7);
                    break;
                case 16:
                    ouT = (x1 + 10 * x2) * (x1 + 10 * x2) + 5 * (x3 - x4) * (x3 - x4) + 
                        (x2 - 2 * x3) * (x2 - 2 * x3) * (x2 - 2 * x3) * (x2 - 2 * x3)
                        + 10 * (x1 - x4) * (x1 - x4) * (x1 - x4) * (x1 - x4);
                    break;
                default:
                    ouT = 4 * (x1 - 5) * (x1 - 5) + (x2 - 6) * (x2 - 6);                
                    break;
            }
            return ouT;
        }

        Individ[] Popul_0(Parametrs a) // новая популяция (прям новая первая)
        {
            Individ[] Ind_popul = new Individ[a.Popultion]; //(L, Mut, Inv, point, point2, inter);
            //Individual[] pools = new Individual[N];
            for (int i = 0; i < a.Popultion; i++)
            {
                Ind_popul[i] = new Individ(a);
                Ind_popul[i].Fank_out = Fank_( Ind_popul[i], a );

            }
            return Ind_popul;
        }

       
        public Individ Turnir(Individ[] Tur)
        {

            if (Tur.Length > 2)
            {
                int i;
                Individ[] Tur2 = new Individ[Tur.Length - 1];
                for (i = 0; i < Tur2.Length - 1; i++)
                    Tur2[i] = Tur[i];

                if (Tur[Tur.Length - 1].Fank_out > Tur[Tur.Length - 2].Fank_out)
                    Tur2[i] = Tur[Tur.Length - 2];
                else Tur2[i] = Tur[Tur.Length - 1];

                return Turnir(Tur2);

            }
            else
            {
                if (Tur[1].Fank_out > Tur[0].Fank_out)
                    return Tur[0];
                else return Tur[1];

            }
        }
          //?     
        public string Print(Parametrs A)
        {
            string s = "";
            for (int i = 0; i < A.Popultion; i++)
            {
                s = s +// Popul_all[i].Prin_Ind(point, point2)  +
                       // Popul_all[i].Prin_Fen()  +
                Popul_all[i].Fank_out + Environment.NewLine; // Fank_(Ind_popul[i].Fenotip_1, Ind_popul[i].Fenotip_2);

            }
            return s;
        }

        public void Select(Parametrs a)
        {
            Individ[] Ind_popul = new Individ[a.Popultion];
            Individ f, g;
            Individ[] C = { new Individ(a), new Individ(a) };
          //  Individ[] q = new Individ[a.Tutu];

            for (int i = 0;  i  < (int)Math.Floor(a.Popultion/2.0); i++)
            {
                f = Turnir2(Rand_Turnir(a));
                g = Turnir2(Rand_Turnir(a)); 


                C = Individ.PointCrossOver(a, f, g);

                C[0].MutateAll(a);
                C[1].MutateAll(a);

                Ind_popul[2 * i] = C[0];
                Ind_popul[2 * i + 1] = C[1];
                Ind_popul[2 * i].Fank_out = Fank_(Ind_popul[2 * i], a);
                Ind_popul[2 * i + 1].Fank_out = Fank_(Ind_popul[2 * i + 1], a);

            }

            Popul_all = Ind_popul;
           // Mut_all(Mut, Inv, 3);
        }

        public Individ[] Rand_Turnir(Parametrs a)
        { 
            // Random rnd11 = new Random();
            Individ[] Tur = new Individ[a.Tutu];
            int ii = 0;
            for (int i = 0; i < a.Tutu; i++)
            {
                ii = a.rnd1.Next(0, a.Popultion - 1);
                Tur[i] = Popul_all[ii];
            }
            return Tur;
        }


        public void Mut_all(Parametrs a)
               {
                   for (int i = 0; i < Popul_all.Length; i++)
                   {
                       Popul_all[i].MutateAll(a);
                       
                   }
               }


        public Individ Turnir2(Individ[] Tur)
        {

            if (Tur.Length > 2)
            {
                int i;
                Individ[] Tur2 = new Individ[Tur.Length - 1];
                for (i = 0; i < Tur2.Length - 1; i++)
                    Tur2[i] = Tur[i];

                if (Math.Abs(Tur[Tur.Length - 1].Fank_out) > Math.Abs(Tur[Tur.Length - 2].Fank_out))
                    Tur2[i] = Tur[Tur.Length - 2];
                else Tur2[i] = Tur[Tur.Length - 1];

                return Turnir2(Tur2);

            }
            else
            {
                if (Math.Abs(Tur[1].Fank_out) > Math.Abs(Tur[0].Fank_out))
                    return Tur[0];
                else return Tur[1];

            }
        }
        public Individ TurnirMax(Individ[] Tur)
        {

            if (Tur.Length > 2)
            {
                int i;
                Individ[] Tur2 = new Individ[Tur.Length - 1];
                for (i = 0; i < Tur2.Length - 1; i++)
                    Tur2[i] = Tur[i];

                if (Tur[Tur.Length - 1].Fank_out < Tur[Tur.Length - 2].Fank_out)
                    Tur2[i] = Tur[Tur.Length - 2];
                else Tur2[i] = Tur[Tur.Length - 1];

                return TurnirMax(Tur2);

            }
            else
            {
                if (Tur[1].Fank_out < Tur[0].Fank_out)
                    return Tur[0];
                else return Tur[1];

            }
        }


        public void Copi(Parametrs a, Population c)
        {
            for (int i = 0; i < a.Popultion; i++)
                Popul_all[i] = Individ.CopiInd(a, c.Popul_all[i], Popul_all[i]);

        }
    }
}
