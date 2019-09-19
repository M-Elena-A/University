using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboret_v4
{
    class VeshPopulation
    {
        public VeshIndivid[] Popul_all;
        // private Individual[] pool;
        // private Individual globalBest;

        public VeshPopulation(Parametrs a)
        {
            //Set_pop(Namber_0, nIters_0, fanc_0, tuuuutu);

            Popul_all = Popul_0(a);

            //Select();
        }

        VeshIndivid[] Popul_0(Parametrs a) // новая популяция (прям новая первая)
        {
            VeshIndivid[] Ind_popul = new VeshIndivid[a.Popultion]; //(L, Mut, Inv, point, point2, inter);
            //Individual[] pools = new Individual[N];
            for (int i = 0; i < a.Popultion; i++)
            {
                Ind_popul[i] = new VeshIndivid(a);
                Ind_popul[i].Fank_out = Fank_(Ind_popul[i], a);

            }
            return Ind_popul;
        }

        public double Fank_(VeshIndivid s, Parametrs a)//double Fenotip_01, double Fenotip_02)
        {
            double x1 = 0, x2 = 0, x3 = 0, x4 = 0;

            if (a.Chom == 4)
            {
                x1 = s.Fenotip_1(a);
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
                    ouT = (x2 - x1 * x1) * (x2 - x1 * x1) + (1 - x1) * (1 - x1);
                    break;
                case 4:
                    ouT = 4 * (x1 - 5) * (x1 - 5) + (x2 - 6) * (x2 - 6);
                    break;
                case 5:
                    ouT = (x2 - x1 * x1) * (x2 - x1 * x1) + (1 - x1) * (1 - x1);
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
                        (1 - x3) * (1 - x3) * (1 - x3) + 10.1 * ((x2 - 1) * (x2 - 1) + (x4 - 1) * (x4 - 1)) + 19.8 * (x2 - 1) * (x4 - 1);
                    break;
                default:
                    ouT = 4 * (x1 - 5) * (x1 - 5) + (x2 - 6) * (x2 - 6);
                    break;
            }
            return ouT;
        }


        public VeshIndivid Turnir(VeshIndivid[] Tur)
        {

            if (Tur.Length > 2)
            {
                int i;
                VeshIndivid[] Tur2 = new VeshIndivid[Tur.Length - 1];
                for (i = 0; i < Tur2.Length - 1; i++)
                    Tur2[i] = Tur[i];

                if (Math.Abs(Tur[Tur.Length - 1].Fank_out) > Math.Abs(Tur[Tur.Length - 2].Fank_out))
                    Tur2[i] = Tur[Tur.Length - 2];
                else Tur2[i] = Tur[Tur.Length - 1];

                return Turnir(Tur2);

            }
            else
            {
                if (Math.Abs(Tur[1].Fank_out) > Math.Abs(Tur[0].Fank_out))
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
            VeshIndivid[] Ind_popul = new VeshIndivid[a.Popultion];
            VeshIndivid f, g;
            VeshIndivid[] C = { new VeshIndivid(a), new VeshIndivid(a) };
            //  Individ[] q = new Individ[a.Tutu];

            for (int i = 0; i < (int)Math.Floor(a.Popultion / 2.0); i++)
            {
                f = Turnir(Rand_Turnir(a));
                g = Turnir(Rand_Turnir(a));


                C = VeshIndivid.PointCrossOver(a, f, g);

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

        public VeshIndivid[] Rand_Turnir(Parametrs a)
        {
            VeshIndivid[] Tur = new VeshIndivid[a.Tutu];
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
            for (int i = 0; i <= Popul_all.Length - 1; i++)
            {
                Popul_all[i].MutateAll(a);

            }
        }


    }
}
